namespace Lesson_2
{
    internal class MyThreadPool
    {
        private static readonly Queue<Thread> _queue = new Queue<Thread>();
        
        public static readonly int _maxThreads = 10;
        
        public static void AddThread(Action func)
        {
            if (_queue.Count > _maxThreads)
            {
                throw new Exception($"MyThreadPool is full. Max threads {_maxThreads}");
            }
            _queue.Enqueue(new Thread(new ThreadStart(func)) { IsBackground = false });
        }
        
        public static void ClearMyThreadPool()
        {
            _queue.Clear();
        }

        public static void Run()
        {
            if (_queue.Count > 0)
            {
                foreach (var thread in _queue)
                {
                    thread.Start();                    
                }
            }            
            else
            {
               Console.WriteLine("ThreadPool is emty");
            }
        }
    }
}
