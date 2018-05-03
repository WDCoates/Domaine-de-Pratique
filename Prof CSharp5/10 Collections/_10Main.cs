﻿using System;
using Col = System.Collections;
using System.Collections.Generic;
using System.Threading;
using Common;
using ConsoleA1._00_Common;
using Cons = System.Console;

namespace ConsoleA1._10_Collections
{
    class _10Main
    {
        public static void Main()
        {
            Cons.WriteLine($"Chapter 10 - Collections...");

            //Play._Time(1);
            //Play._Time(2);

            //Collection Initializers
            var intList = new List<int>() {1, 2, 3, 4, 5};

            //Racers
            Racer GHill = new Racer(2,"Graham","Hill", "UK", 10);
            Racer DHill = new Racer(7,"Dameon","Hill", "UK", 14);

            var racers = new List<Racer>(10) {GHill, DHill};

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

            Racer R1 = new Racer(22, "Ayrton", "Senna", "Brazil", 41);

            if (!racers.Remove(R1))
            {
                Cons.WriteLine($"Racer {R1.Id} not found to remove.");
            }

            R1 = DHill;
            if (!racers.Remove(R1))
            {
                Cons.WriteLine($"Racer {DHill.Id} not found to remove.");
            }
            
            racers.Add(R1);
            //Using Find Predicate
            //int i2 = racers.FindIndex(new FindCountry("Finland").FindCountryPredicate);   This works but has a bugget, not my code!
            int i3 = racers.FindIndex(r => r.Country == "UK"); //Sane as line above and more likely to be used...
            i3 = racers.FindLastIndex(r => r.Country == "UK"); //Sane as line above and more likely to be used...

            var R2 = racers.FindLast(r => r.LastName == "Louder");
            var someWins = racers.FindAll(r => r.Wins < 20);
            someWins.Sort();

            var bigWiners = racers.FindAll(r => r.Wins > 20);
            bigWiners.Sort();
            
            racers.Sort(new RacerComp(RacerComp.CompareType.LastName));

            racers.Sort(new RacerComp(RacerComp.CompareType.Country));

            //Sort using delagte and Lambda expression.
            racers.Sort((r1, r2) => r2.Wins.CompareTo(r1.Wins));
            racers.Reverse();

            //Type Conversion...
            var rPeople = racers.ConvertAll<Person>(r => new Person(r.FirstName +','+ r.LastName));

            //Read-Only Collections
            var roRacers = racers.AsReadOnly();
          
            //Queues
            var dm = new DocsManager();
            ProcessDocs.Start(dm);
            //Create docs and add too dm
            for (int i = 0; i < 100; i++)
            {
                var doc = new Doc("Doc" + i.ToString(), "AID" + new Random().Next(20).ToString());
                dm.AddDoc(doc);
                Console.WriteLine($"Added Document: {doc.Title} by {doc.Auther} to queue.");
                Thread.Sleep(new Random().Next(20));
            }
            
            Thread.Sleep(2000);
            ProcessDocs.Stop();

            //Stacks Quick one...
            var lets = new Stack<char>();
            lets.Push('A');
            lets.Push('B');
            lets.Push('C');

            foreach (var l in lets)
            {
                Cons.Write(l);
            }
            Cons.WriteLine();
           
            while (lets.Count > 0)
            {
                Cons.Write(lets.Pop());
            }
            Cons.WriteLine();

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