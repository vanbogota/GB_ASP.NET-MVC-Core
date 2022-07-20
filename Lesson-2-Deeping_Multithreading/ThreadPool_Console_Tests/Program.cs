using Lesson_2_MultiThreading;

namespace ThreadPool_Console_Tests
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> messages = Enumerable.Range(1, 1000).Select(i => $"Message - {i}");

            using (MyThreadPool myThreadPool = new(10, name: "Messager worker"))
            {
                foreach (var message in messages)
                {
                    myThreadPool.Execute(message, fun =>
                    {
                        var temp = (string)fun;
                        Console.WriteLine($"Working {message} strart...");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Working {message} done");
                    });
                }
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}