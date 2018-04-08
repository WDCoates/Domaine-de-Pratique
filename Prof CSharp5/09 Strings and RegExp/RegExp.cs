using Cons = System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleA1._09_Strings_and_RegExp
{
    public struct RegExp
    {
        const string myTest = @"Anything you can do I can do aswell...";
        const string pat = "ing";

        public static void runReg ()
        {
            MatchCollection matches = Regex.Matches(myTest, pat, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);


            foreach (Match m in matches)
            {
                Cons.WriteLine(@"Match {i} ");
            }
        }
    }
}
