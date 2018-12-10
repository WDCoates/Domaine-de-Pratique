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
            Tuple<int, int> div = (Tuple<int, int>) divObj;
            var res = div.Item1 / div.Item2;
            var rem = div.Item1 % div.Item2;

            con.WriteLine("Task creates a result....");

            return Tuple.Create<int, int>(res, rem);
        }

        public static void DoOnFirst()
        {
            con.WriteLine($"Called from task {Task.CurrentId}. Do Something like sleep!");
            Thread.Sleep(3000);
        }

        public static void DoOnSecond(Task t)
        {
            con.WriteLine($"task {t.Id} finished");
            con.WriteLine($"This is now task id {Task.CurrentId}... Some Cleanup stuff follows");
            Thread.Sleep(3000);
        }

        internal static void ParentAndChild()
        {
            var par = new Task(ParentTask);
            par.Start();
            Thread.Sleep(2000);
            con.WriteLine($"Par Status {par.Status}");
            Thread.Sleep(4000);
            con.WriteLine($"Par Status {par.Status}");
        }

        static void ParentTask()
        {
            con.WriteLine($"Task Id: {Task.CurrentId}");
            var child = new Task(ChildTask);
            child.Start();
            var detChild = new Task(ChildTask, TaskCreationOptions.DenyChildAttach);            
            Thread.Sleep(1000);
            detChild.Start();
            con.WriteLine($"Parent started child...");
        }

        static void ChildTask()
        {
            con.WriteLine($"Child...");
            Thread.Sleep(5000);
            con.WriteLine($"Brat Stop!");
        }
    }
}
