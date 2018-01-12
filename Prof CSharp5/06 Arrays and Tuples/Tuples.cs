using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._06_Arrays_and_Tuples
{
    class Tuples
    {
        public static Tuple<int, int> tDiv(int what, int by)
        {
            int res = what / by;
            int rem = what % by;

            return Tuple.Create<int, int>(res, rem);
        }

        public static Tuple<string, string, string, string, int, int, int, Tuple<Tuple<string, int>>> mTuples()
        {
            var tM = Tuple.Create("UK", "England", "Surrey", "Astead", 1, 2, 3, Tuple.Create<string, int>("Knee", 10));

            return tM;
        }

        internal static object tM()
        {
            throw new NotImplementedException();
        }
    }

    public class TupleComp : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
}
