using System.Threading.Tasks;
using con = System.Console;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    class SharedState
    {
        internal int State { get; set; }
    }

    static class sLock
    {
        internal static int sState { get; set; }
    }

    internal class SynchClass
    {
        private SharedState sharedState;

        public SynchClass(SharedState sharedState)
        {
            this.sharedState = sharedState;
        }

        internal SynchClass()
        {
        }

        internal void DoIt()
        {

            lock (sharedState)
            {
                for (int i = 0; i < 5000; i++)
                {
                    sharedState.State += 1;
                } 
            }
        }

        internal void DoItStaticLock()
        {

            lock (typeof(sLock))
            {
                for (int i = 0; i < 5000; i++)
                {
                    sLock.sState += 1;
                } 
            }
        }
    }

    internal static class SyncWorker
    {
        internal static void main()
        {
            int nTasks = 20;
            var state = new SharedState();
            var tasks = new Task[nTasks];

            for (int i = 0; i < nTasks; i++)
            {
                tasks[i] = Task.Run(() => new SynchClass(state).DoIt());
            }

            for (int i = 0; i < nTasks; i++)
            {
                tasks[i].Wait();
            }

            con.WriteLine($"End State = {state.State}");

            int nTasks2 = 50;
            var tasks2 = new Task[nTasks2];
            for (int i = 0; i < nTasks2; i++)
            {
                tasks2[i] = Task.Run(() => new SynchClass().DoItStaticLock());
            }

            for (int i = 0; i < nTasks2; i++)
            {
                tasks2[i].Wait();
            }

            con.WriteLine($"End State = {sLock.sState}");
        }
    }
}
