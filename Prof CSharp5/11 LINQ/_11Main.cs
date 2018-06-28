using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._00_Common;
using Cons = System.Console;

namespace ConsoleA1._11_LINQ
{
    class _11Main
    {
        public static void Main(string[] args)
        {
            Cons.WriteLine($"Start the LINQ Stuff.....{args[0]}");
            var champs = Formula1.GetChampions();
            var q1 = from r in Formula1.GetChampions() where r.Country == "British" orderby r.Wins descending select r;

            foreach (Racer r in q1)
            {
                Cons.WriteLine($"{r:A}");
            }

            Cons.ReadKey();
        }
    }
}
