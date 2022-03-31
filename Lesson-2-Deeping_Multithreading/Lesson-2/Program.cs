using Lesson_2;

for (int i = 0; i < 10; i++)
{
    MyThreadPool.Run(WaitCallback);
    
}

static void WaitCallback()
{
    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(1000);
}



