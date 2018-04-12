using System;
using System.Collections.Concurrent;
using Col = System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cons = System.Console;

namespace ConsoleA1._10_Collections
{
    class _Main
    {
        static void Main()
        {
            Cons.WriteLine($"Chapter 10 - Collections...");

            Play._Time(1);
            Play._Time(2);

            return;
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
