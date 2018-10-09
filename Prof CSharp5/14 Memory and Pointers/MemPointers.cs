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
                pHeight = &height;
                Cons.WriteLine($"pWidth = {pWidth->ToString()}");
                Cons.WriteLine($"p Diff = {((uint)pWidth) - ((uint)pHeight)}");  
                pWidth = &height + 0x00000001;  //Why one!? for 1 int or 4 bytes compiler knows its a pointer to 32bit int...
                pHeight = &width - (uint) 4; 
                Cons.WriteLine($"pWidth = {*pWidth}");  

                Cons.WriteLine($"pWidth using uint <= {(uint)pWidth}");     //32bit processing
                Cons.WriteLine($"pWidth using ulong <= {(ulong)pWidth}");   //64bit processing

                var x = CheckedExample(1);
                
                x = CheckedExample(10);

            }
        }

        private static int maxInt = 2147483647;

        private static ulong CheckedExample(int add)
        {
            int res = 0;
            try
            {
                res = checked(maxInt + add);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Got you using checked: {e.Message}");
                throw;
            }
            return (ulong)res;
        }
    }
}
