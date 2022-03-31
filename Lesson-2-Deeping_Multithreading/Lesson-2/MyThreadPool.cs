using System.Collections.Concurrent;
namespace Lesson_2
{
    internal class MyThreadPool
    {
        private static readonly ConcurrentQueue<Thread> _queue = new();
        
        public static readonly int _maxThreads = 10;
        
        public static Thread GetThread(Action func)
        {
            if (!_queue.IsEmpty)
            {
                if (!_queue.ElementAt(0).IsAlive)
                {
                    _queue.TryDequeue(out Thread thread);
                    return thread;
                }
            }
            if (_queue.Count >= _maxThreads)
            {
                throw new ArgumentOutOfRangeException($"MyThreadPool overloaded. Max limit {_maxThreads}");
            }
            var newThread = new Thread(new ThreadStart(func));
            _queue.Enqueue(newThread);
            return newThread;
        }

        public static void ReleaseThread(Thread thread)
        {            
            if (thread.IsAlive)
            {
                return;              
            }
            _queue.Enqueue(thread);            
        }       
              

        public static void Run(Action func)
        {
            var newThread = GetThread(func);
            newThread.Start();
            foreach (var thread in _queue)
                {
                    ReleaseThread(thread);                    
                }
            
        }
    }
}
