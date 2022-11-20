using System;
using System.Threading;

namespace lessons
{
    class Program
    {
        public delegate void DelegateName(object id);
        static void Main(string[] args)
        {
            //Thread thread = new Thread();
            Console.WriteLine("Hello World!");
            Thread thread = new Thread(WriteString);
            DelegateName _delegate = WriteString;

            Console.WriteLine("Для запуска нажмителюбую клавишу");
            Console.ReadKey();

            thread.Start("task_2");
            for (int i = 0; i < 80; i++)
            {
                Console.WriteLine("task_1");
                Thread.Sleep(300);
            }
            Console.ReadLine();
        }
        private static void WriteString(object arg)
        {
            for (int i = 0; i < 80; i++)
            {
                Console.WriteLine($"\t{arg}");
                Thread.Sleep(300);
            }
        }
        private static void SomeMethod(DelegateName _delegateParam)
        {
            _delegateParam(1);
        }
    }
}
