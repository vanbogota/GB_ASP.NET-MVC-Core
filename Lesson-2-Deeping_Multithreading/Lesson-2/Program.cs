using Lesson_2;

MyThreadPool.AddThread(() => Console.WriteLine("Added in MyThreadPool"));

MyThreadPool.Run();

