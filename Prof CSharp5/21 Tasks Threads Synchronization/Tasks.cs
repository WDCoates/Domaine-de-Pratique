using System;
using System.Threading;
using System.Threading.Tasks;
using con = System.Console;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    
    public class Tasks
    {
        private static readonly object TaskMethodLock = new object();

        public static void TaskMethod(object title)
        {
            lock (TaskMethodLock)
            {
                con.WriteLine($"{title}");
                con.WriteLine($"Task ID: {Task.CurrentId ?? 0}, Thread: {Thread.CurrentThread.ManagedThreadId}");
                con.WriteLine($"Pooled Thread: {Thread.CurrentThread.IsThreadPoolThread}");
                con.WriteLine($"Background Thread: {Thread.CurrentThread.IsBackground}");
                con.WriteLine();
            }
        }

        public static Tuple<int, int> TaskWithRes(object divObj)
        {
            Tuple<int, int> div = (Tuple<int, int>)divObj;
            var res = div.Item1 / div.Item2;
            var rem = div.Item1 % div.Item2;

            con.WriteLine("Task creates a result....");

            return Tuple.Create<int, int>(res, rem);
        }


    }
}
