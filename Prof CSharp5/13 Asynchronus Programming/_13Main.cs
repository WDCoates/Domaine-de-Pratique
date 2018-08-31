using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cons = System.Console;

namespace ConsoleA1._13_Asynchronus_Programming
{
    class _13Main
    {
        public static void Main(string[] args)
        {
            Cons.WriteLine($"Start Chapter 13 Asynchronus Programming");

            AFoundationsOfAsync.GetGreetingAs("Dave");
            AFoundationsOfAsync.CallerWithContinuation("Caroline");
            Cons.Write("Tick.");
            while (AFoundationsOfAsync._result == null)
            {
                Cons.Write(".");
                Thread.Sleep(500);
            }

            Cons.WriteLine("Phew!");
            Cons.WriteLine($"What _result is: {AFoundationsOfAsync._result}");

            Cons.ReadKey();
        }
    }
}
