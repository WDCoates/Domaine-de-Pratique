using System;
using System.Diagnostics;
using System.Threading;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    internal class StateObject
    {
        private int state = 0;

        public void UpState(int loop)
        {
            Console.WriteLine($"Loop {loop}");
            if (state == 0)
            {
                state++;
                Trace.Assert(state == 1, $"Race condition occurred after {loop} loops");
            }

            state = 0;

        }
    }
    
    internal class StateObjectWithLock
    {
        private int state = 0;
        private readonly object sync = new object();

        public void UpState(int loop)
        {
            lock (sync)
            {
                Console.WriteLine($"Loop {loop}");
                if (state == 0)
                {
                    state++;
                    Trace.Assert(state == 1, $"Race condition occurred after {loop} loops");
                }

                state = 0;

            }
        }
    }

    internal class DeadLock
    {
        private StateObjectWithLock s1;
        private StateObjectWithLock s2;

        public DeadLock(StateObjectWithLock s1, StateObjectWithLock s2)
        {
            this.s1 = s1;
            this.s2 = s2;
        }

        public void DeadLock1()
        {
            int i = 0;
            while (true)
            {
                lock (s1)
                {
                    lock (s2)
                    {
                        s1.UpState(i);
                        s2.UpState(i++);
                        Console.WriteLine($"Still running, L1 loop{i}");
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void DeadLock2()
        {
            int i = 0;
            while (true)
            {
                lock (s2)       //Bad lock order causes the deadlock issue. Design a good lock order on the out set of projects.
                {
                    lock (s1)
                    {
                        s1.UpState(i);
                        s2.UpState(i++);
                        Console.WriteLine($"Still running, L2 loop{i}");
                    }
                }
            }
        }
    }
}
