using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using con = System.Console;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    public class BarrierStuff
    {
        public static int[] CalcInTask(int jNo, int pSize, Barrier bar, IList<string> coll)
        {
            if (jNo == 1)
            {
                Thread.Sleep(6000);
            }

            List<string> data = new List<string>(coll);

            int start = jNo * pSize;
            int end = start + pSize;
            con.WriteLine($"Task {Task.CurrentId}: Partition from {start} to end {end}");
            int[] cCount = new int[26];

            for (int j = start; j < end; j++)
            {
                char c = data[j][0];
                cCount[c - 97]++;
            }

            con.WriteLine($"Calculation completed from task {Task.CurrentId}. {cCount[0]} times a, {cCount[25]} times z");

            bar.RemoveParticipant();
            con.WriteLine($"Task {Task.CurrentId} removed from Barrier, remaining participants {bar.ParticipantsRemaining}");

            return cCount;
        }
    }
}
