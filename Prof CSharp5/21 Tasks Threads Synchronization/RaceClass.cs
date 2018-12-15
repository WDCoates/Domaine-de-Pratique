using System.Diagnostics;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    public class RaceClass
    {
        public void RaceCondition(object o)
        {
            Trace.Assert(o is StateObject, $"o must be of type StateObject");
            StateObject sO = o as StateObject;

            int i = 0;
            while (true)
            {
                    sO.UpState(i++);
            }
        }

        public void RaceConditionLock(object o)
        {
            Trace.Assert(o is StateObject, $"o must be of type StateObject");
            StateObject sO = o as StateObject;

            int i = 0;
            while (true)
            {
                lock (sO) //Stops the Race Condition.
                {
                    sO.UpState(i++);
                }
            }
        }

        public void RaceConditionSyncObject(object o)
        {
            Trace.Assert(o is StateObjectWithLock, $"o must be of type StateObjectWithLock");
            StateObjectWithLock sO = o as StateObjectWithLock;

            int i = 0;
            while (true)
            {
                sO.UpState(i++);
            }
        }
    }
}
