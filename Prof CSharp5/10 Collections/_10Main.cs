using System;
using System.CodeDom;
using Col = System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using Common;
using ConsoleA1._00_Common;
using Cons = System.Console;

namespace ConsoleA1._10_Collections
{
    internal class _10Main
    {
        public _10Main()
        {
        }

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
            Cons.WriteLine($"Next...");

            //Linked Lists...
            var pDM = new PDocManager();

            pDM.AddPDoc(new PDoc("Adoc", "AAAdams", 4));
            pDM.AddPDoc(new PDoc("Bdoc", "BBabs", 8));
            pDM.AddPDoc(new PDoc("Cdoc", "CCock", 4));
            pDM.AddPDoc(new PDoc("Ddoc", "AAAdams", 8));
            pDM.AddPDoc(new PDoc("Edoc", "CCock", 8));

            pDM.DisplayAllNodes();

            //Simple Sorted List
            var boots = new SortedList<int, string>();
            boots.Add(18, "Knee High");
            boots.Add(27, "Thigh Length");
            boots[12] = "Calfe";
            boots[6] = "Ankle";

            foreach (var b in boots)
            {
                Cons.WriteLine($"{b.Key}, {b.Value}");
            }

            boots[27] = "Thigh High";
            
            foreach (var b in boots)
            {
                Cons.WriteLine($"{b.Key}, {b.Value}");
            }

            //What Next....for DCoates
            var employees = new Dictionary<EmployeeId, DicEmployee>();
            
            var idCat = new EmployeeId("A000001");
            var eCat = new DicEmployee(idCat, "Cat", 100000.00m);
            employees.Add(idCat, eCat);
            
            var idAnt = new EmployeeId("A012345");
            var eAnt = new DicEmployee(idAnt, "Ant", 23000.00m);
            employees.Add(idAnt, eAnt);

            var idBee = new EmployeeId("B000001");
            var eBee = new DicEmployee(idBee, "Bee", 40000.00m);
            employees.Add(idBee, eBee);

            var idDog = new EmployeeId("A000002");
            var eDog = new DicEmployee(idDog, "Dog", 10000.00m);
            employees.Add(idDog, eDog);

            foreach (var e in employees)
            {
                Cons.WriteLine(e.ToString());
            }

            while (true)
            {
                Cons.Write("Enter am Empolyee Id: (X to exit)>");
                var uIn = Cons.ReadLine();
                if (uIn.ToLower() == "x") break;

                EmployeeId eId;
                try
                {
                    eId = new EmployeeId(uIn);

                    DicEmployee dEmp;
                    if (!employees.TryGetValue(eId, out dEmp))
                    {
                        Cons.WriteLine($"Employee with {eId} does not exist.");
                    }
                    else
                    {
                        Cons.WriteLine(dEmp);
                    }

                }
                catch (EmployeeIdException ee)
                {
                    Cons.WriteLine(ee.Message);
                }

            }

            //Lookups from System.core
            //Use the racers list from above

            var lookupRacers = racers.ToLookup(r => r.Country);
            foreach (var r in lookupRacers["UK"])
            {
                Cons.WriteLine($"name:{r.LastName}, {r.FirstName}");
            }
            //Nice but not sorted!

            //Sorted Dics....
            //Simple Sorted List
            var sdBoots = new SortedDictionary<int, string> {{18, "Knee High"}, {27, "Thigh Length"}};
            sdBoots[12] = "Calfe";
            sdBoots[6] = "Ankle";

            foreach (var b in sdBoots)
            {
                Cons.WriteLine($"{b.Key}, {b.Value}");
            }

            //Sets...
            var allTeams = new HashSet<string>() { "Ferrari", "Lotus", "McLaren", "Honda", "BRM", "Aston Martin", "Red Bull", "Force India", "Sauber", "Williams" };
            var coTeams = new HashSet<string>() { "Ferrari", "Lotus", "McLaren", "Honda" };
            var oldTeams = new HashSet<string>() { "Ferrari", "Lotus", "BRM", "Aston Martin"};
            var newTeams = new HashSet<string>() { "Red Bull", "Force India", "Sauber" };

            var res = coTeams.Add("Williams");
            res = coTeams.Add("Williams");

            res = coTeams.IsSubsetOf(allTeams);
            res = allTeams.IsSupersetOf(coTeams);
            res = oldTeams.Overlaps(coTeams);
            res = newTeams.Overlaps(coTeams);
            
            var allTeams2 = new SortedSet<string>(coTeams);
            allTeams2.UnionWith(oldTeams);
            allTeams2.UnionWith(newTeams);

            res = allTeams2.SetEquals(allTeams);

            var tTeams = new SortedSet<string>(allTeams);
            tTeams.SymmetricExceptWith(oldTeams);
            var yTeams = new SortedSet<string>(allTeams);
            var yI = new SortedSet<string>(yTeams.Intersect(oldTeams));

            //Observable Collections
            Cons.Clear();
            Cons.WriteLine("Observable Collections....");
            var data = new ObservableCollection<string>();
            data.CollectionChanged += Data_CollectionChanged;
            data.Add("First");
            data.Add("Second");
            data.Insert(1, "Three");
            data.Remove("Three");

            //Bits and bobs....
            Cons.WriteLine("Bits and Bobs....");
            var bitsA = new Col.BitArray(8);
            bitsA.SetAll(true);
            bitsA.Set(1, false);
            DisplayBits(bitsA);

            Cons.WriteLine();
            bitsA.Not();
            DisplayBits(bitsA);
            
            byte[] aI = {22};
            var bitsB = new Col.BitArray(aI);
            DisplayBits(bitsB);
            
            bitsA.Or(bitsB);
            DisplayBits(bitsA);

            //BitVector32 Struct
            var vBits = new Col.Specialized.BitVector32();
            int m1 = BitVector32.CreateMask();
            int m2 = BitVector32.CreateMask(m1);
            int m3 = BitVector32.CreateMask(m2);
            int m4 = BitVector32.CreateMask(m3);
            int m5 = BitVector32.CreateMask(128);

            vBits[m1] = true;
            vBits[m3] = true;
            vBits[m4] = true;
            vBits[m5] = true;
            
            Cons.WriteLine(vBits);

            int rec = 0x88abcde;
            var vBitRSet = new BitVector32(rec);
            Cons.WriteLine(vBitRSet);

            //Immutable Collections
            ImmutabeThings.ImmutableTing1();

            Cons.ReadKey();
        }

        static void DisplayBits(Col.BitArray bitArray)
        {
            foreach (bool bit in bitArray)
            {
                Cons.Write($"{(bit? 1 : 0)}");
            }
            Cons.WriteLine();
        }
        public static void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs eArgs)
        {
            Cons.WriteLine($"Action: {eArgs.Action}.");
            if (eArgs.OldItems != null)
            {
                foreach (var itm in eArgs.OldItems)
                {
                    Cons.WriteLine($"Item {itm} removed.");
                }
            }
            if (eArgs.NewItems != null)
            {
                foreach (var itm in eArgs.NewItems)
                {
                    Cons.WriteLine($"Item {itm} added.");
                }
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public struct Play
    {
        public static void _Time(int step)
        {
            switch (step)
            {
                case 1:
                    ISet<string> sSet = new SortedSet<string>();
                    sSet.Add("Test");
                    sSet.Add("Set");

                    ISet<string> sSet2 = new SortedSet<string>();
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
