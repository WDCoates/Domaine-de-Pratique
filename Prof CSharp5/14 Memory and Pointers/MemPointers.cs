using System;
using Cons = System.Console;

namespace ConsoleA1._14_Memory_and_Pointers
{
    internal class MmeClass
    {
        internal long x, y;
        internal int count;
    }
    public class MemPointers
    {
        private struct MemStruct
        {
            internal char N;
            internal int Number;
        }
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

                MemStruct mS = new MemStruct();
                mS.N = 'A';
                mS.Number = 1;

                MemStruct* pMemStruct;
                pMemStruct = &mS;

                (*pMemStruct).Number = 101;
                pMemStruct->N = 'B';

                int* pMsNo = &pMemStruct->Number;

                //Pointers to class members!
                MmeClass mClass = new MmeClass();
                //long* pX = &(mClass->x);    //Wrong wrong wrong!!!
                mClass.x = 1;
                fixed (long* pObject = &(mClass.x))
                fixed (long* pY = &mClass.y)            //Can be stacked or nested....
                {
                    Cons.WriteLine($"Address fixed: {(ulong)pObject}");
                    Cons.WriteLine($"Address fixed: {(ulong)pY}");

                    MmeClass mClass2 = new MmeClass();
                    fixed (long* pY2 = &mClass.y, pX2 = &mClass2.x)
                    fixed(int* pC2 = &mClass.count)
                    {
                        //Do something with pY2, pX2, pC2
                    }
                }
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
                //throw;
            }
            return (ulong)res;
        }

        public static unsafe void Stack_Based_Array(int len)
        {
            int* pInt = stackalloc int[len];

        }
    }

}
