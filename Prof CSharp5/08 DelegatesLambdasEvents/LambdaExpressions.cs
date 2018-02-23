using System;
using Cons = System.Console;
namespace ConsoleA1._08_DelegatesLambdasEvents
{
    class LambdaExpressions
    {
        //Good way of assigning code implementation to delegates.

        public static void MidL()
        {
            string mid = ", middle bit, ";
            Func<string, string> lambda = parm =>
            {
                parm += mid;
                parm += " the end.";
                return parm;
            };
            Cons.WriteLine(lambda("The start"));
        }

        public static string StringToUpper(string str)
        {
            Func<string, string> oneParm = s => String.Format("Change uppercase {0}", s.ToUpper());
            return oneParm(str);
        }
        public static string twoToUpper(string str)
        {
            Func<string, string, string> twoParm = (s, f) => String.Format($"From:{s} => To: {f.ToUpper()}");
            return twoParm(str, str);
        }
    }
}
