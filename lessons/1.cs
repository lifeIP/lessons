using System;
using System.Threading;

namespace lessons
{
    //class Program
    //{
    //    public delegate void DelegateName(object id);
    //    static void Main(string[] args)
    //    {
    //        //Thread thread = new Thread();
    //        Console.WriteLine("Hello World!");
    //        Thread thread = new Thread(WriteString);
    //        DelegateName _delegate = WriteString;

    //        Console.WriteLine("Для запуска нажмителюбую клавишу");
    //        Console.ReadKey();

    //        thread.Start("task_2");
    //        for (int i = 0; i < 80; i++)
    //        {
    //            Console.WriteLine("task_1");
    //            Thread.Sleep(300);
    //        }
    //        Console.ReadLine();
    //    }
    //    private static void WriteString(object arg)
    //    {
    //        for (int i = 0; i < 80; i++)
    //        {
    //            Console.WriteLine($"\t{arg}");
    //            Thread.Sleep(300);
    //        }
    //    }
    //    private static void SomeMethod(DelegateName _delegateParam)
    //    {
    //        _delegateParam(1);
    //    }
    //}
    class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Id потока Main{Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Для запускаа нажмите любую клавишу");
            Console.ReadKey();

            Report();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Example1));
            Report();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Example1));
            Report();

            Console.ReadKey();
            Report();
        }

        private static void Example1(object state)
        {
            Console.WriteLine($"Метод 1 начал выполняться в потоке {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"Метод 1 закончил выполнение в потоке {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Example2(object state)
        {
            Console.WriteLine($"Метод 2 начал выполняться в потоке {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
            Console.WriteLine($"Метод 2 закончил выполнение в потоке {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Report()
        {
            ThreadPool.GetMaxThreads(out int maxWorkerThread, out int maxPortThread);
            ThreadPool.GetAvailableThreads(out int workerThreads, out int portThreads);

            Console.WriteLine($"Рабочие потоки {workerThreads} из {maxWorkerThread}");
            Console.WriteLine($"IO потоки {portThreads} из {maxPortThread}");
            Console.WriteLine(new string('-', 80));
        }
    }
}
