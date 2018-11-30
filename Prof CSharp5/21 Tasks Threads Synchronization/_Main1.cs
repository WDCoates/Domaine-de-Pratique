using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
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
                Thread.Sleep(10000 - i*1000);  //Old Way of doing it... 
                con.WriteLine($"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
            });

            con.WriteLine($"First set completed? {pRes.IsCompleted}");

            //Adding the async and wait key words
            ParallelLoopResult pRes2 = Parallel.For(100, 110, async i =>
            {
                try
                {
                    con.WriteLine($"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                    await Task.Delay(10000 - i * 10); 
                }
                catch (Exception e)
                {
                    con.WriteLine($"Error: {e.Message}!");
                }

                con.WriteLine($"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
            });

            con.WriteLine($"All Threads completed! {pRes2.IsCompleted}");

            //Adding the Break method which dose not quite work like the documentation seems to be telling me! Break must be before await keyword!          
            var brk = 15;
            ParallelLoopResult pRes3 = Parallel.For(10, 20, async (i, pLS) =>
            {               
                if (i >= brk)
                    pLS.Break();

                try
                {
                    con.WriteLine($"3rd Loop Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                    await Task.Delay(10); 
                }
                catch (Exception e)
                {
                    con.WriteLine($"Iteration {i}, Error: {e.Message}!");
                }
                con.WriteLine($"3rd Loop Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");

            });

            con.WriteLine($"3rd Loop - All Threads completed! {pRes3.IsCompleted}");
            con.WriteLine($"Last iteration: {pRes3.LowestBreakIteration}");     //This is null 

            con.ReadLine();
        }
    }
}
