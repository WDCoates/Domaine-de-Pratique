using System;
using Con = System.Console;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    delegate string GetAString();

    class MathOps
    {
        public static double TimesTwo(double val)
        {
            return val * 2;
        }

        public static double Sqr(double val) => val * val;
    }


    delegate double DoubleOp(double x);
    public struct Delegates
    {
        public static void DemoDelegates()
        {
            int x = 40;
            GetAString fStringMethod = new GetAString(x.ToString);
            GetAString sStringMethod = x.ToString;                      //Also can be done like this...


            Con.WriteLine($"x String is {fStringMethod()}");
            Con.WriteLine($"x String is {sStringMethod()}");

            //Simple Delagte Example
            DoubleOp[] ops =
            {
                MathOps.TimesTwo,
                MathOps.Sqr
            };


            for (int i = 0; i < ops.Length; i++)
            {
                Con.WriteLine($"Using ops[{ops[i].Method}]:");
                ProAndDis(ops[i], 2.0);
                ProAndDis(ops[i], 7.35);
                ProAndDis(ops[i], 1.555);
            }

            //Now with a Func to it.
            Func<double, double>[] fOps =
            {
                MathOps.TimesTwo,
                MathOps.Sqr
            };

            foreach (var o in fOps)
            {
                ProAndDispFunc(o, 3.0);
            }

            //ToDo: A bubble Sort!

        }

        static void ProAndDis(DoubleOp action, double val)
        {
            double res = action(val);
            Con.WriteLine($"Value is {val}, result of operation is {res}");
        }

        static void ProAndDispFunc(Func<double, double> action, double val)
        {
            double res = action(val);
            Con.WriteLine($"Value is {val}, result of operation is {res}");
        }
    }

    
}
