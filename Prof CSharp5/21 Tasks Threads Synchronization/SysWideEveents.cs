using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using con = System.Console;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    internal class SysWideEvents
    {
        private ManualResetEventSlim mEvent;

        internal int Result { get; set; }

        internal SysWideEvents (ManualResetEventSlim mE)
        {
            this.mEvent = mE;
        }

        internal void Calc(int x, int y)
        {
            con.WriteLine($"Task {Task.CurrentId} starts to calculate!");
            Thread.Sleep(new Random().Next(3000));
            Result = x + y;

            con.WriteLine($"Task {Task.CurrentId} has completed calculation!");
            
            //The Signal ;-)
            mEvent.Set();   
        }
        
        internal static void SWEMain()
        {
            con.WriteLine("System Wide Event stuff....");

            const int taskCount = 4;

            var mEvents = new ManualResetEventSlim[taskCount];
            var wHandles = new WaitHandle[taskCount];
            var calcs = new SysWideEvents[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                int i1 = i;
                mEvents[i] = new ManualResetEventSlim(false);
                wHandles[i] = mEvents[i].WaitHandle;
                calcs[i] = new SysWideEvents(mEvents[i]);

                Task.Run(() => calcs[i1].Calc(i1 + 1, i1 + 3));
            }
            //...
            for (int i = 0; i < taskCount; i++)
            {
                int index = WaitHandle.WaitAny(wHandles);
                if (index == WaitHandle.WaitTimeout)
                {
                    con.WriteLine("Timeout!!!");
                }
                else
                {
                    mEvents[index].Reset();
                    con.WriteLine($"Finished task for {index}, result is {calcs[index].Result}");
                }
            }

        }
    }
}
