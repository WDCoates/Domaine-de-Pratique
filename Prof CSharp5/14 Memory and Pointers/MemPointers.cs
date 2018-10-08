using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cons = System.Console;

namespace ConsoleA1._14_Memory_and_Pointers
{
    public class MemPointers
    {
        public static void MemPo()
        {
            unsafe
            {
                //Simple Pointer Syntax
                int* pWidth, pHeight;
                double* pRes;
                byte*[] pFlags;

                int width = 100;
                int height = 200;

                pWidth = &width;
                Cons.WriteLine($"pWidth = {pWidth->ToString()}");
                pWidth = &height + 0x00000001;  //Why one!?
                Cons.WriteLine($"pWidth = {*pWidth}");  

            }
        }
    }
}
