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
            int doCase = 4;

            switch (doCase)
            {
                case 1:
                    con.WriteLine($"Start Looping with Parallel.For!");

                    ParallelLoopResult pRes = Parallel.For(0, 10, i =>
                    {
                        Thread.Sleep(10000 - i * 1000); //Old Way of doing it... 
                        con.WriteLine(
                            $"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                    });

                    con.WriteLine($"First set completed? {pRes.IsCompleted}");
                    break;

                case 2:
                    //Adding the async and wait key words
                    ParallelLoopResult pRes2 = Parallel.For(100, 110, async i =>
                    {
                        try
                        {
                            con.WriteLine(
                                $"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                            await Task.Delay(10000 - i * 10);
                        }
                        catch (Exception e)
                        {
                            con.WriteLine($"Error: {e.Message}!");
                        }

                        con.WriteLine(
                            $"Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                    });

                    con.WriteLine($"All Threads completed! {pRes2.IsCompleted}");
                    break;
                
                case 3:
                    //Adding the Break method which dose not quite work like the documentation seems to be telling me! Break must be before await keyword!          
                    var brk = 15;
                    ParallelLoopResult pRes3 = Parallel.For(10, 20, async (i, pLS) =>
                    {
                        if (i >= brk)
                            pLS.Break();

                        try
                        {
                            con.WriteLine(
                                $"3rd Loop Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                            await Task.Delay(10);
                        }
                        catch (Exception e)
                        {
                            con.WriteLine($"Iteration {i}, Error: {e.Message}!");
                        }

                        con.WriteLine(
                            $"3rd Loop Iteration {i}, Task: {Task.CurrentId}, Thread: {Thread.CurrentThread.ManagedThreadId}");

                    });

                    con.WriteLine($"3rd Loop - All Threads completed! {pRes3.IsCompleted}");
                    con.WriteLine($"Last iteration: {pRes3.LowestBreakIteration}"); //This is null 
                    break;

                case 4:
                    //Getting funky now...
                    con.WriteLine($"Lets get funky when you are ready hit a key!");
                    con.ReadLine();
                    Parallel.For<string>(0, 2, () =>
                        {
                            // Invoked once for each thread...
                            con.WriteLine(
                                $"Init for thread {Thread.CurrentThread.ManagedThreadId}, task {Task.CurrentId}");

                            return String.Format($"t{Thread.CurrentThread.ManagedThreadId}");
                        }, (i, pLs, str1) =>
                        {
                            // Invoked for each member.
                            con.WriteLine(
                                $"Body i {i}, str {str1}, thread {Thread.CurrentThread.ManagedThreadId}, task {Task.CurrentId}");
                            Thread.Sleep(10);
                            return $"i {i}";
                        },
                        (str1) =>
                        {
                            //Final action on each thread
                            con.WriteLine($"Finally {str1}");
                        });

                    con.WriteLine($"What happened there!");
                    break;
            }

            con.ReadLine();
        }
    }
}
