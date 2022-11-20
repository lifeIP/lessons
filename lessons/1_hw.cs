using System;
using System.Threading;


namespace lessons
{
    /// <summary>
    /// 5. Написать консольное приложение, которое выводит на экран символы в разных потоках. 
    /// Использовать Thread. (по аналогии с примером из лекции)
    /// </summary>
    class Program
    {
        public static void ThreadProc()
        {
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("\t\tThreadProc: {0}", i);
                // Yield the rest of the time slice.
                Thread.Sleep(300);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread.");
            Thread thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();

            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine("Main thread: {0}", i);
                Thread.Sleep(300);
            }

            thread.Join();

            Console.WriteLine("Push some button!");
            Console.ReadLine();
        }
    }




    /// <summary>
    /// 6. Написать консольное приложение, в котором реализована обертка над пулом потоков – 
    /// ThreadPoolWorker (два варианта, без результата выполнения операции и с результатом 
    /// выполнения асинхронной операции).
    /// </summary>

}