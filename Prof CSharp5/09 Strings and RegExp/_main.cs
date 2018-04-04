using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cons = System.Console;

namespace ConsoleA1._09_Strings_and_RegExp
{
    public class _Main
    {
        public static void Main()
        {
            Cons.WriteLine($@"Chapter 09 Strings and Regular Expressions");

            var test = "Test";
            StringBuilder sbGreetings = new StringBuilder($@"Just A little note to say hello...{test}.", 150);
            sbGreetings.AppendFormat($" This goes on the end.");

            Cons.WriteLine($"The Greeting: {sbGreetings}");

            //Now Encrypt
            for (int i = 'A'; i <= 'z'; i++)
            {
                char f = (char)i;
                char w = (char) (i-1);  //Ensure the sign is opposite to the loop.
                sbGreetings = sbGreetings.Replace(f, w);
            } 
            Cons.WriteLine($"After Encryption: {sbGreetings}");

            
            
            Cons.ReadKey();
        }
    }
}
