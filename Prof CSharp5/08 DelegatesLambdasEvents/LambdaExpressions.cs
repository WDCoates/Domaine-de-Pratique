using System;
using System.Collections.Generic;
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

        public static void lambdaExamples()
        {
            int sVal = 1;
            Func<int, int> f1 = x => x + sVal;  //Builds an anonymouse Class with constructor using sVal each call creates a new instance built with new sVal 

            int res = f1(10);
            Cons.WriteLine($"Res 1:{res}");

            sVal = 2;
            res = f1(10);
            Cons.WriteLine($"Res 2:{res}");

            //Foreach Statements
            var values = new List<int>() {10, 20, 30};
            var funcs = new List<Func<int>>();

            foreach (var val in values)
            {
                funcs.Add(() => val);
            }

            foreach (var f in funcs)
            {
                Cons.WriteLine((f()));
            }
        }
    }

    public class AnonymouseClass
    {
        private int sVal;

        public AnonymouseClass(int sVal)
        {
            this.sVal = sVal;
        }

        public int AnonymouseMethod(int x)
        {
            return x + sVal;
        }
    }
}
