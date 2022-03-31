using System;
using System.Threading;

namespace Lesson_1_3
{
    class Program
    {
        /*Текст задания:
         * Изучите внимательно статичный класс Thread и не статичный класс. 
         * Найдите метод, который может прервать выполняющийся поток
         * и зафиксируйте ту ошибку, которая формируется при отмене.*/

        static void Main(string[] args)
        {
            Thread newThread = new Thread(Method);
            newThread.Start();
            
            newThread.Interrupt();

            Console.WriteLine("Main thread calls Interrupt on newThread.");

            newThread.Join();
        }

        private static void Method()
        {            
            try
            {
                Console.WriteLine("newThread going to sleep.");

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
