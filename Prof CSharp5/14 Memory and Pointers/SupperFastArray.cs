using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleA1._14_Memory_and_Pointers
{
    class SupperFastArray
    {
        public static unsafe void SFastArray(int size)
        {
            double* pDouble = stackalloc double[size+1];    //Without this you get a STATUS_STACK_BUFFER_OVERRUN at the end!

            var r = new Random();

            for (var i = 0; i <= size; i++)
            {
                pDouble[i] = r.NextDouble();
            }

            Write($"Array:");
            for (var i = 0; i < size; i++)
            {
                Write($"[{i}] {pDouble[i]}");
                Write(i < size-1 ? ',' : '.');
            }

        }
    }
}
