using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._07_Operators_and_Casts
{
    static class BoxUnBox
    {
        internal static Boolean Box(bool byPass)
        {
            if (!byPass)
            {
                try
                {
                    int myInt = 20;
                    object intBoxed = myInt;

                    long myLongNumber = 3333333333333;
                    object mObj = (object) myLongNumber;
                    int mInt = (int) mObj;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            //More Boxing
            Cur cur = new Cur(100, 10);
            object oCur = cur;
            object nObj = new object();
            
            Cur dCur = (Cur) oCur;
            try
            {
                Cur eCur = (Cur) nObj;
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }
    }
}
