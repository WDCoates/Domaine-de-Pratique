using System;
using System.Diagnostics;

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
}
