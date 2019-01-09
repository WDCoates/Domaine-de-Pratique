using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    internal class DataFlowStuff
    {
        internal static BufferBlock<string> bBlock = new BufferBlock<string>();

        internal static void Producer()
        {
            bool exit = false;
            while (!exit)
            {
                string inPut = Console.ReadLine();
                if (string.Compare(inPut, "exit", ignoreCase: true) == 0)
                {
                    exit = true;
                }
                else
                {
                    bBlock.Post(inPut);
                }
            }
        }

        internal static async void Consumer()
        {
            while (true)
            {
                string bBlockData = await bBlock.ReceiveAsync();
                Console.Write($"DataFrom bBlck: {bBlockData}");
            }
        }
    }
}
