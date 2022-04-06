using System;
using System.Threading;

namespace Lesson_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            ListCover<int> listCover = new();

            Console.WriteLine("Programm start");

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        listCover.MyAdd(j);                        
                    }
                });
                thread.IsBackground = true;
                thread.Start();
                thread.Join();
            }
            Console.WriteLine("Program finish");
            var count = listCover.ThreadList.Count;
            Console.WriteLine(count);
        }      
        
    }
}
