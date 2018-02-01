using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ConsoleA1._07_Operators_and_Casts
{
    static class TypeSafe
    {
        public static Boolean sTypeSafe()
        {
            Person x = null, y = null;
            bool T1 = ReferenceEquals(x, y);
            if (T1)
            {
                x = new Person();
                y = new Person();

                T1 = ReferenceEquals(x, y);

                bool b1 = (x == y); //Compares References



            }
            return T1;
        }
    }
}
