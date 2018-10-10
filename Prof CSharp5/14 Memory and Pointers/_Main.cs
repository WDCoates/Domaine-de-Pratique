using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Cons = System.Console;

namespace ConsoleA1._14_Memory_and_Pointers
{
    class _Main
    {
        public static void Main()
        {
            Cons.WriteLine($"What is Memoery Management and all these MemPointers all about!");

            GC.Collect();
            
            Scope1 s = new Scope1();
            s.level1();

           
            GC.Collect();
            GC.Collect(); //~Destructors need two passes!


            GC.Collect(10, mode: GCCollectionMode.Forced);

            //Looking at MemPointers
            MemPointers.MemPo();

            //Stack-based Arrays
            Cons.WriteLine($"How Many?");
            var input = Cons.ReadLine();
            int len;
            if (int.TryParse(input, out len))
                MemPointers.Stack_Based_Array(len);
            else
            {
                Cons.WriteLine($"That was not an integer!");
            }

            Cons.WriteLine($"Press anykey to exit!");
            Cons.ReadKey();
        }
    }
}
