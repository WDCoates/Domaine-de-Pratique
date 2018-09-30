using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cons = System.Console;

namespace ConsoleA1._14_Memory_and_Pointers
{
    class _Main
    {
        public static void Main()
        {
            Cons.WriteLine($"What is Memoery Management and all these Pointers all about!");

            GC.Collect();

            Cons.WriteLine($"Press anykey to exit!");
            Cons.ReadKey();
        }
    }
}
