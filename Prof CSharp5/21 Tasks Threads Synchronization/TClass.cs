using System;
using System.Threading;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    internal class TClass
    {
        private readonly string _tdata;

        public TClass(string msg)
        {
            this._tdata = msg;
        }

        public void TSend()
        {
            var tType = Thread.CurrentThread.IsBackground ? "Background": "Foreground";
            Console.Write($"From a {tType} class {_tdata}");
        }
    }
}
