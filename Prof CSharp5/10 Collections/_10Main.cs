using System;
using System.Collections.Concurrent;
using Col = System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._00_Common;
using Cons = System.Console;

namespace ConsoleA1._10_Collections
{
    class _Main
    {
        static void Main()
        {
            Cons.WriteLine($"Chapter 10 - Collections...");

            //Play._Time(1);
            //Play._Time(2);

            //Collection Initializers
            var intList = new List<int>() {1, 2, 3, 4, 5};

            //Racers
            Racer DHill = new Racer(2,"Graham","Dameon", "UK", 10);
            Racer GHill = new Racer(7,"Graham","Hill", "UK", 14);

            var racers = new List<Racer>(10) {DHill, GHill};

            Cons.WriteLine($"{racers.Count} racers so far.");

            racers.Add(new Racer(24, "Michael", "Schumacher", "Germany", 91));
            racers.Insert(0, new Racer(22, "Ayrton", "Senna", "Brazil", 41));

            //Accessing elements
            var a1 = racers[0];
            Cons.WriteLine("Print list with a foreach loop.........................................");
            foreach (var r in racers)
            {
                Cons.WriteLine(r.ToString("N", null));
            }

            //Delagates again!
            Cons.WriteLine("Now using a delegate.........................................");
            racers.ForEach(Cons.WriteLine);
            Cons.WriteLine("Now using lambda to format.........................................");
            racers.ForEach(r => Cons.WriteLine($"{r:w}"));

            Cons.ReadKey();
        }

    }

    public struct Play
    {
        public static void _Time(int Step)
        {
            switch (Step)
            {
                case 1:
                    Col.Generic.ISet<string> sSet = new SortedSet<string>();
                    sSet.Add("Test");
                    sSet.Add("Set");

                    Col.Generic.ISet<string> sSet2 = new SortedSet<string>();
                    sSet2.Add("Test");
                    sSet2.Add("Something");

                    sSet.IntersectWith(sSet2);
                    break;

                //Thread Safe collections!
                case 2:
                    //Col.Concurrent.BlockingCollection<string> bC = new BlockingCollection<string>();
                    var intList = new List<int>(10);
                    Cons.WriteLine($"intList's capacity is {intList.Capacity}, used {intList.Count}.");
                    intList.Add(444);
                    Cons.WriteLine($"intList's capacity is {intList.Capacity}, used {intList.Count}.");
                    intList.TrimExcess();
                    Cons.WriteLine($"intList's capacity is {intList.Capacity}, used {intList.Count}.");
                    intList.Add(22);
                    intList.Add(33);
                    Cons.WriteLine($"intList's capacity is {intList.Capacity}, used {intList.Count}.");
                    break;
            }

        }
    }

}
