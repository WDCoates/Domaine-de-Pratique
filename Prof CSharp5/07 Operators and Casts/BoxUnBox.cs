using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._07_Operators_and_Casts
{
    static class BoxUnBox
    {
        internal static Boolean Box()
        {
            try
            {
                int myInt = 20;
                object intBoxed = myInt;

                long myLongNumber = 3333333333333;
                object mObj = (object) myLongNumber;
                int mInt = (int) mObj;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
