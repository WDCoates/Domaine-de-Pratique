using System;

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
            Console.Write($"From a class {_tdata}");
        }
    }
}
