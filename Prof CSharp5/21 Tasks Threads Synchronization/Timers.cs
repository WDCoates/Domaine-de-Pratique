using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    internal class Timers
    {
        internal static void ThreadingTimer()
        {
            var tt1 = new System.Threading.Timer(TAction, null, TimeSpan.FromSeconds(4), TimeSpan.FromSeconds(4));
            Thread.Sleep(15000);
            tt1.Dispose();
        }

        internal static void TAction(object o)
        {
            Console.WriteLine($"System.Threading.Timer {DateTime.Now:T}");
        }

        internal static void TTimer()
        {
            var t1 = new System.Timers.Timer(1000); //1s sec
            t1.AutoReset = true;
            t1.Elapsed += TAction2;
            t1.Start();
            Thread.Sleep(10000);
            t1.Stop();

            t1.Dispose();
        }

        private static void TAction2(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($"System.Threading.Timer {DateTime.Now:T}");
        }
    }
}
