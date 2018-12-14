using System.Threading.Tasks;
using con = System.Console;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    class SharedState
    {
        internal int State { get; set; }
    }

    internal class Synchronisation
    {
        private SharedState sharedState;

        public Synchronisation(SharedState sharedState)
        {
            this.sharedState = sharedState;
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
                tasks[i] = Task.Run(() => new Synchronisation(state).DoIt());
            }

            for (int i = 0; i < nTasks; i++)
            {
                tasks[i].Wait();
            }

            con.WriteLine($"End State = {state.State}");
        }
    }
}
