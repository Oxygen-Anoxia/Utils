using System;
using System.Threading;

namespace ProcessThreadProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DoWork();
            Console.ReadLine();
        }

        static void Sing()
        {
            while (true)
            {
                Console.WriteLine("**********唱歌***********");
                Thread.Sleep(1000);
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("**********唱歌***********");
            //    Thread.Sleep(1000);
            //}
        }

        static void Dance()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("**********跳舞***********");
                //Thread.Sleep(1000);
            }
        }

        static void DoWork()
        {
            Thread SingThread = new Thread(new ThreadStart(Sing));
            Thread DanceThread = new Thread(new ThreadStart(Dance));
            SingThread.IsBackground = true;
            SingThread.Start();
            DanceThread.Start();
        }


    }

    public interface Executor
    {

    }
}
