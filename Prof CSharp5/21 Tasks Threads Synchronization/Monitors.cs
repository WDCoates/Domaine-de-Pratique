using System;
using System.Data;
using System.Threading;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    internal class Monitors
    {
        readonly object _mLock = new object();
        private int _status;


        public void AddToStatus()
        {
            lock (_mLock)
            {
                _status++;
            }

            bool _looked = false;
            //Monitor.Enter(_mLock);
            Monitor.TryEnter(_mLock, 500, ref _looked);
            if (_looked)
            {
                try
                {
                    //This is now a synchronised region of the obj/instance.
                }
                finally
                {
                    Monitor.Exit(_mLock);
                }
            }
            else
            {
                //Not sure what to do....
            }
        }

        //SpinLock what is it...Avoid holding more than one, don't call anything that might block.
        //IsHeld and IsHeldByCurrentThread
        //SpinLock is a struct so always pas as ref or you will be passing a copy!

        //WaitHandle
        internal static void WMain()        
        {
            
            TakesAWhileDelegate del1 = TakesAWhile;

            IAsyncResult aR = del1.BeginInvoke(1, 3000, null, null);
            while (true)
            {
                Console.WriteLine(".");
                if (aR.AsyncWaitHandle.WaitOne(50, false))
                {
                    Console.WriteLine("Can see the result now.");
                    break;
                }
            }

            int res = del1.EndInvoke(aR);
            Console.WriteLine($"Result: {res}");
        }

        
        //Common stuff
        static int TakesAWhile(int data, int ms)
        {
            Console.WriteLine("This Takes A While: Start");
            Thread.Sleep(ms);
            Console.WriteLine("That was a while: finish");
            return ++data;
        }

        private delegate int TakesAWhileDelegate(int data, int ms);
    }

}
