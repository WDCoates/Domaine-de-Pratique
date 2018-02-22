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
    }
}
