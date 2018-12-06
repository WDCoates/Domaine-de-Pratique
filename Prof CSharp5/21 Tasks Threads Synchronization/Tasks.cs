
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



    }
}
