using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    public class MutexesNSemaphores
    {
        public static void MainMutex()
        {
            // Already created?
            bool createdNew;
            Mutex mutex = new Mutex(false, "MyMutex", out createdNew);

            //Or you can try this..
            if (mutex.WaitOne(10))
            {
                try
                {
                    // Some synched stuff...
                    Console.WriteLine("This is the start and the end.....");
                    Console.ReadLine();
                }
                finally 
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                //Some problem handling shit. Un problème de teaitement de la merde. Merci.
                Console.WriteLine("Already started, bye bye....");
                Thread.Sleep(1000);

            }

        }

        public static void MainSemephore()
        {
            int tCount = 6;
            int sCount = 3;     //Semaphore count

            var semaphore = new SemaphoreSlim(sCount, sCount);
            var tasks = new Task[tCount];

            for (int i = 0; i < tCount; i++)
            {
                tasks[i] = Task.Run(() => Tasks.SemaphoreMain(semaphore));
            }

            Task.WaitAll(tasks);

            Console.WriteLine("All tasks finished!");
        }

    }
}
