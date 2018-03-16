using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cons = System.Console;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    delegate string Stringify();

    struct SandPit
    {
        public static void Test()
        {
            int x = 4040;
            Stringify getTheString = new Stringify(x.ToString);


            Cons.WriteLine($"This is what stringify does but you have to us it as a method ()...{getTheString()}");

        }
    }
}
