using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._08_DelegatesLambdasEvents;

namespace ConsoleA1._11_LINQ
{
    static class DeferredDemo
    {
        internal static void DeferredEx1()
        {
            var names = new List<string> {"Ann", "Bob", "Jimmy", "Tess" };
            var Js1 = from n in names where n.StartsWith("J") orderby n select n;
            var Js2 = names.Where(n => n.StartsWith("J")).OrderBy(n => n).Select(n =>n).ToList();

            foreach (var n in Js1)
            {
                Console.WriteLine($"{n}");
            }

            names.Add("Dave");
            names.Add("Jean");
            names.Add("June");
            names.Add("Jan");

            foreach (var n in Js1)
            {
                Console.WriteLine($"{n}");
            }
        }
    }
}
