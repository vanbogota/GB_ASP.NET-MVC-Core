using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    internal class MyThreadPool
    {
        private static readonly Queue<Thread> _queue = new Queue<Thread>();

        public static void AddThread(Action func)
        {
            _queue.Enqueue(new Thread(new ThreadStart(func)));
        }

        public static void Run()
        {
            if (_queue.Count != 0)
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
