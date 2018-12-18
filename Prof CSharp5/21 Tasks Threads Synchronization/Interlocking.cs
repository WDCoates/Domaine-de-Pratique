using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    /// <summary>
    /// i++ is not thread safe so try this only for simple operations.
    /// </summary>

    public class Interlocking
    {
        private int tValue = 0;

        public int Total => tValue;

        public int AddToValue(int addValue)
        {
            int iValue, cValue;
            do
            {
                iValue = tValue;
                cValue = iValue + addValue;

            } while (iValue != Interlocked.CompareExchange(ref tValue, cValue, iValue));

            return cValue;
        }

    }
}
