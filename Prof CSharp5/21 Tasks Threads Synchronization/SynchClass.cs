using System.Threading.Tasks;
using ConsoleA1._21_Tasks_Threads_Synchronization;
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


        //Examples with locks, but locks takes time...
        public void DoThis()
        {
            lock (this)
            {
                //ToDo: Add Code
            }
        }
        public void DoThat()
        {
            lock (this)
            {
                //ToDo: Add Code
            }
        }

        private readonly object _syncRoot = new object();

        public void DoThisSyncRoot()
        {
            lock (_syncRoot)
            {
                //ToDo: Add Code
                // Only one thread at a time can access these two methods 
            }
        }
        public void DoThatSyncRoot()
        {
            lock (_syncRoot)
            {
                //ToDo: Add Code
                // Only one thread at a time can access these two methods 
            }
        }
        //Examples with locks.
    }

    /// <summary>
    /// Example using the SyncRoot Pattern, but this only synchronizes methods.
    /// </summary>
    public class SyncDemo
    {
        private class SynchronizedDemo : SyncDemo
        {
            private object syncRoot = new object();
            private SyncDemo sD;

            public SynchronizedDemo(SyncDemo sD)
            {
                this.sD = sD;
            }

            protected override bool IsSynchronised => true;

            protected override void DoThis()
            {
                lock (syncRoot)
                {
                    sD.DoThis();
                }
            }

            protected override void DoThat()
            {
                lock (syncRoot)
                {
                    sD.DoThat();
                }
            }            
        }

        protected virtual bool IsSynchronised => false;

        public static SyncDemo Synchronized(SyncDemo sD)
        {
            if (!sD.IsSynchronised)
            {
                return new SynchronizedDemo(sD);
            }

            return sD;
        }

        protected virtual void DoThis(){}
        protected virtual void DoThat(){}
    }

    public class SharedState2
    {
        private int state = 0;
        private readonly object syncRoot = new object();

        public int State => state;

        public int IncrementState()
        {
            lock (this.syncRoot)
            {
                return ++state;
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
