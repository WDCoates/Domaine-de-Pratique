using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using con = System.Console;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    class _Main1
    {
        public static void Main(string[] args)
        {
            con.WriteLine($"Start Looping with Parallel.For!");

            ParallelLoopResult pRes = Parallel.For(0, 10, i =>
            {
                Thread.Sleep(10000 - i*1000);
                con.WriteLine($"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
            });

            con.WriteLine($"Completed All Treads! {pRes.IsCompleted}");

            con.ReadLine();
        }
    }
}
