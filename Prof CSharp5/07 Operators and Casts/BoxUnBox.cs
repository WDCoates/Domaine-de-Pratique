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
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
