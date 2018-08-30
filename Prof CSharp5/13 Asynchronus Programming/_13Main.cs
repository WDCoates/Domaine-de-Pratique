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

            AFoundationsOfAsync.GetGreetingAsync("Dave");

            while (AFoundationsOfAsync._result == null)
            {
                Thread.Sleep(1000);
            }

            Cons.WriteLine("Phew!");

            Cons.ReadKey();
        }
    }
}
