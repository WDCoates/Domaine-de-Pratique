using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            var test = "111";
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

            var test2 = Int32.Parse(test);

            var test3 = test2 is IFormattable;

            FVector v1 = new FVector(1, 22, 333);
            FVector v2 = new FVector(482.5, 54.3, -17.18);

            Cons.WriteLine($"\nIn default format, \nV1 is {v1} \nv2 is {v2}.");
            Cons.WriteLine($"\nIn IJK format, \nV1 is {v1, 30:Ijk} \nv2 is {v2, 30:iJk}");
            Cons.WriteLine($"\nIn VE format, \nV1 is {v1, 50:ve}\nv2 is {v2, 50:ve}");
            Cons.WriteLine($"\nIn N format, \nV1 is {v1, -30:n}\nv2 is {v2, -30:N}");

            Cons.ReadKey();

            //Change A everywhere
            //Change B Commited to Local Repository
        }
    }
}
