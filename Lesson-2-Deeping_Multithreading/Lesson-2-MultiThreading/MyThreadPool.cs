/// Создаем собственный пул потоков без использования static
/// с блокировкой критической секции в очереди

using System.Collections.Concurrent;
using System.Diagnostics;

namespace Lesson_2_MultiThreading
{
    public class MyThreadPool : IDisposable
    {
        private readonly ConcurrentQueue<Thread> _threads;
        private readonly int _maxThreads;
        private readonly ThreadPriority _priority;
        private readonly string? _name;
        private readonly AutoResetEvent _workingEvent = new(false);
        private readonly AutoResetEvent _executeEvent = new(true);
        private readonly Queue<(Action<object> Work, object? parameter)> _works = new();
        private volatile bool _canWork = true;
        private const int _disposeThreadJoinTimeout = 100;

        public MyThreadPool(
            int maxThreadsCount,
            ThreadPriority priority = ThreadPriority.Normal,
            string? name = null)
        {
            if (maxThreadsCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxThreadsCount), maxThreadsCount, "Number of threads in pool must be more then 0");

            _maxThreads = maxThreadsCount;
            _priority = priority;
            _name = name;
            _threads = new ConcurrentQueue<Thread>();
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 1; i <= _maxThreads; i++)
            {
                string name = $"{nameof(MyThreadPool)}[{_name ?? GetHashCode().ToString()}]-Thread[{i}]";
                Thread thread = new Thread(WorkingThread)
                {
                    Name = name,
                    IsBackground = true,
                    Priority = _priority
                };
                _threads.Enqueue(thread);
                thread.Start();
            }
        }

        private void WorkingThread()
        {
            var threadName = Thread.CurrentThread.Name;
            try
            {
                while (_canWork)
                {
                    _workingEvent.WaitOne();
                    if (!_canWork)
                        break;

                    _executeEvent.WaitOne(); //запрашиваем доступ к очереди

                    while (_works.Count == 0) //ждем пока появится хоть одно задание
                    {
                        _executeEvent.Set(); //освобождаем очередь
                        _workingEvent.WaitOne(); //дожидаемся разрешения на выполнение
                        if (!_canWork)
                            break;
                        _executeEvent.WaitOne(); //вновь заправшиваем доступ к очереди
                    }

                    var (Work, parameter) = _works.Dequeue();
                    if (_works.Count > 0) //если после изъятия из очереди задания там осталось еще задание...
                    {
                        _workingEvent.Set(); //...то запускаем еще поток на выполнение
                    }

                    _executeEvent.Set(); //разрешаем доступ к очереди

                    try
                    {
                        Work(parameter);
                    }
                    catch (Exception e)
                    {
                        Trace.TraceError($"Error while doing work in thread {threadName} : {e}");
                    }
                }
            }
            catch (ThreadInterruptedException)
            {
                Trace.TraceWarning($"Thread {threadName} was terminated with threadpoll {_name ?? GetHashCode().ToString()}.");
            }
            finally
            {
                Trace.TraceInformation($"Thread {threadName} finished work.");
                _workingEvent.Set();
            }
        }

        public void Execute(Action Work) => Execute(null, _ => Work());

        public void Execute(object? parametr, Action<object> Work)
        {
            if (!_canWork)
                throw new InvalidOperationException("Trying to start work in terminated ThreadPool");

            _executeEvent.WaitOne(); //запрашиваем доступ к очереди

            if (!_canWork)
                throw new InvalidOperationException("Trying to start work in terminated ThreadPool");

            _works.Enqueue((Work, parametr));
            _executeEvent.Set(); //разрешаем доступ к очереди

            _workingEvent.Set();
        }

        public void Dispose()
        {
            _canWork = false;

            _workingEvent.Set();  //разрешаем выполняться очередному потоку

            foreach (var thread in _threads)
            {
                if (!thread.Join(_disposeThreadJoinTimeout))
                {
                    thread.Interrupt();
                }
            }

            _executeEvent?.Dispose();
            _workingEvent?.Dispose();

            Trace.TraceInformation($"Threadpool {_name ?? GetHashCode().ToString()} disposed.");
        }
    }
}
