using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleA1._00_Common;
using Cons = System.Console;

namespace ConsoleA1._11_LINQ
{
    internal class _11Main
    {
        public static void Main(string[] args)
        {
            Cons.WriteLine($"Start the LINQ Stuff.....{args?[0]}");
            var champs = Formula1.GetChampions();
            var q1 = from r in Formula1.GetChampions() where r.Country == "UK" orderby r.Wins descending select r;

            foreach (Racer r in q1)
            {
                Cons.WriteLine($"{r:A}");
            }

            //Extension Method! Just another way to get at static classes!
            var s = "All";
            s.Boots();

            //Q1 using extensions methods to for show...
            var champs2 = new List<Racer>(Formula1.GetChampions());
            IEnumerable<Racer> Brits = champs2.Where(c => c.Country == "UK").OrderBy(o => o.LastName)
                .Select(r => r);

            DeferredDemo.DeferredEx1();

            //LINQ query examples

            var wins10plus = from r in champs2 where r.Wins >= 10 select r;
            var wins10Plus2 = Formula1.GetChampions().Where(r => r.Wins >= 10).Select(r => r).ToList();

            //Example where one can't use LINQ and have to use the extension method.
            var r1 = champs2.Where((r, Index) => r.LastName.StartsWith("A") || Index % 2 != 0);

            //Type Filtering
            object[] data = {"One", 1, 2, 3, 4, "Five", "Six"};
            var int1 = data.OfType<int>().OrderBy(n => n);
            foreach (var i in int1.Reverse())
            {
                Cons.WriteLine($"{i}");
            }

            //Compound froms
            var ferrariDrives = from r in Formula1.GetChampions()
                from c in r.Cars
                where c == "Ferrari"
                select r.LastName + " " + r.LastName + " => " + c;

            var Drives1950s = from r in Formula1.GetChampions()
                from y in r.Years
                where y >=1950 && y <= 1959
                orderby y 
                select r.LastName + " " + r.LastName + " => " + y;

            //Using Exstensions
            var Drivers1960s = Formula1.GetChampions().SelectMany(r => r.Years, (r, y) => new {Racer = r, Year = y})
                .Where(r => r.Year >= 1960 && r.Year <= 1969).OrderBy(r => r.Year).Select(r =>
                    r.Racer.LastName + " " + r.Racer.FirstName + " " + r.Year);
            
            //OrderBy and Take...
            var oRacers = (from r in Formula1.GetChampions() orderby r.Country, r.LastName, r.FirstName descending select r).Take(10);
            //And With Exrensions
            oRacers = Formula1.GetChampions().OrderBy(r => r.Wins).ThenBy(r => r.LastName)
                .ThenByDescending(r => r.FirstName).Take(10);

            //Now some grouping
            var gRacers = from r in Formula1.GetChampions()
                group r by r.Country
                into c
                orderby c.Key
                select c;

            var gRacers2 = from r in Formula1.GetChampions()
                group r by r.Country
                into c
                orderby c.Key, c.Count() descending
                where c.Count() >= 2
                select new {Country = c.Key, Count = c.Count()};

            //Grouping with Nested Objects basicaly c from gRacers
            var gRacers3 = from r in Formula1.GetChampions()
                group r by r.Country
                into c
                orderby c.Key, c.Count() descending
                where c.Count() >= 2
                select new {Country = c.Key, Count = c.Count(), Racers = from r2 in c orderby r2.Wins select new {r2.LastName, r2.Wins}};

            //Inner Joins
            var ijRacers = from r in Formula1.GetChampions()
                from y in r.Years
                select new {Year = y, Name = r.LastName + ", " + r.FirstName};

            var ijTeams = from t in F1_Teams.GetConstructorChampions()
                from y in t.Years
                select new {Year = y, Name = t.Name};

            var ijRacerAndTeam =
                (from r in ijRacers
                    join t in ijTeams on r.Year equals t.Year
                    orderby r.Year
                    select new {r.Year, Champion = r.Name, Constructor = t.Name}
                ).Take(10);

            var loRacerAndTeam =
                (from r in ijRacers
                    join t in ijTeams on r.Year equals t.Year into rt
                    from a in rt.DefaultIfEmpty()
                    orderby r.Year
                    select new {r.Year, Champion = r.Name, Constructor = a == null ? "Not One": a.Name}
                ).Take(10);
            
            //Group Join Step 1 flattern! 
            var gjRacers = Formula1.GetChampionships().SelectMany(c => new List<RacerInfo>()
            {
                new RacerInfo
                {
                    Year = c.Year,
                    Position = 1,
                    FirstName = c.Champion.FirstName(),
                    LastName = c.Champion.LastName()
                },
                new RacerInfo
                {
                    Year = c.Year,
                    Position = 2,
                    FirstName = c.Second.FirstName(),
                    LastName = c.Second.LastName()
                },
                new RacerInfo
                {
                    Year = c.Year,
                    Position = 3,
                    FirstName = c.Third.FirstName(),
                    LastName = c.Third.LastName()
                }
            }).ToArray();
            
            //Step 2 Join
            var q = (from r in Formula1.GetChampions()
                    join ts in gjRacers on new {FirstName = r.FirstName, LastName = r.LastName} equals new
                    {
                        FirstName = ts.FirstName,
                        LastName = ts.LastName

                    } into yrResults
                    select new
                    {
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        Wins = r.Wins,
                        Starts = r.Starts,
                        Results = yrResults
                    }
                ).ToArray();


            //Using Set Operators
            //Using a static method
            var ferrariDrivers = GetDrives("Ferrari");
            var mcLarebDrivers = GetDrives("McLaren");
            
            //Better way to use delegates!
            Func<string, IEnumerable<Racer>> racersByCar =
                car => from r in Formula1.GetChampions() from c in r.Cars where c == car orderby r.LastName select r;

            foreach (var r in racersByCar("Ferrari").Intersect(racersByCar("McLaren")))
            {
                Cons.WriteLine(r.LastName);
            }

            //Zip method!
            var rNames = from r in Formula1.GetChampions()
                where r.Country == "Italy"
                orderby r.Wins descending
                select new { Name = r.FirstName + "," + r.LastName};

            var rNameStarts = from r in Formula1.GetChampions()
                where r.Country == "Italy"
                orderby r.Wins descending 
                select new {LastName = r.LastName, Starts = r.Starts};

            var zRacers = rNames.Zip(rNameStarts, (a, b) => a.Name + ", Starts: " + b.Starts);
            foreach (var a in zRacers)
            {
                Cons.WriteLine(a.ToString());
            }

            //Why the selections and order are so important!
            rNameStarts = from r in Formula1.GetChampions()
                where r.Country == "UK"
                orderby r.Wins
                select new {LastName = r.LastName, Starts = r.Starts};
            zRacers = rNames.Zip(rNameStarts, (a, b) => a.Name + ", Starts: " + b.Starts);
            foreach (var a in zRacers)
            {
                Cons.WriteLine(a.ToString());
            }
            //Complete crap lol

            //Partitioning
            int pSize = 20;
            int nPages = (int) Math.Ceiling(Formula1.GetChampions().Count / (double)pSize);
            for (int p = 0; p < nPages; p++)
            {
                Cons.WriteLine($"Page {p+1} of {nPages}:");
                var pR = (from r in Formula1.GetChampions()
                    orderby r.LastName, r.FirstName
                    select r.LastName + ", " + r.FirstName).Skip(p * pSize).Take(pSize);
                foreach (var r in pR)
                {
                    Cons.WriteLine(r);
                }

                Cons.ReadKey();
            }

            //Aggregate Operators Count, Sum, Min, Max, Average and Aggregate return single values.
            //Count
            var aQ1 = from r in Formula1.GetChampions()
                let nYears = r.Years.Count()
                orderby nYears descending , r.LastName, r.FirstName
                select new {Name = r.LastName, Initials = r.FirstName.Initials(),  Years = nYears};
            foreach (var r in aQ1)
            {
                Cons.WriteLine($"{r.Name}, {r.Initials} Wins = {r.Years}");
            }
            //Sum
            var t1 = from c in
                from r in Formula1.GetChampions()
                group r by r.Country
                select new {Key1 = c.Key};

            var aS1 = (from c in 
                    from r in Formula1.GetChampions() 
                    group r by r.Country into c
                    select new {Country = c.Key, Wins = (from r2 in c select r2.Wins).Sum()}
                orderby c.Wins descending, c.Country select c).Take(5);

            //Conversion Operators
            var lRacers = (from r in Formula1.GetChampions()
                    from c in r.Cars
                    select new {Car = c, Racer = r}
                ).ToLookup(cr => cr.Car, cr => cr.Racer);
            var lr = lRacers["Williams"];   //Gives us a lookup of just Williams drives

            //Using the Cast method!
            var oList = new System.Collections.ArrayList(Formula1.GetChampions() as System.Collections.ICollection ?? throw new InvalidOperationException());
            var q2 = from r in oList.Cast<Racer>() where r.Country == "USA" select r;
            //Not sure what this is doing but it must be good!!!!

            //Generation Operators
            var vRange = Enumerable.Range(1, 20);
            var vRange2 = Enumerable.Range(1, 20).Select(i => i > 1? (i > 2? i * 2: i): i);

            //Parallel LINQ
            Cons.WriteLine($"Loading large dataset, please wait.");
            var lsData = LargeSample().ToList();
            var watch = new Stopwatch();
            
            watch.Start();
            var pRes = (from x in lsData.AsParallel() where Math.Log(x) < 4 select x
                ).Average();
            watch.Stop();
            Cons.WriteLine($"Parallel run: {watch.Elapsed}");
            
            watch.Reset();
            watch.Start();
            var nRes = (from x in lsData where Math.Log(x) < 4 select x
                ).Average();
            watch.Stop();
            Cons.WriteLine($"Normal run: {watch.Elapsed}");

            watch.Reset();
            watch.Start();
            var mpRes = lsData.AsParallel().Where(x => Math.Log(x) < 4).Select(x => x).Average();
            watch.Stop();
            Cons.WriteLine($"Working Average with Parallel run: {watch.Elapsed}");
            //Parallel LINQ

            //Partitions
            watch.Reset();
            watch.Start();
            var ppRes = (from x in Partitioner.Create(lsData, true).AsParallel().WithDegreeOfParallelism(4)
                        where Math.Log(x) < 4
                        select x
                        ).Average();
            watch.Stop();
            Cons.WriteLine($"Average with Degree of Parallelism  set to 4: {watch.Elapsed}");
            watch.Reset();
            watch.Start();
            var ppRes2 = (from x in Partitioner.Create(lsData, true).AsParallel().WithDegreeOfParallelism(8)
                         where Math.Log(x) < 4
                         select x
                        ).Average();
            watch.Stop();
            Cons.WriteLine($"Avergare Degree of Parallelism  set to 8: {watch.Elapsed}");
            watch.Reset();
            watch.Start();
            //Partitions


            // Candellations and how to do it....
            var cts = new CancellationTokenSource();        //From using System.Threading;
            Task.Factory.StartNew(() =>
            {
                try
                {
                   Cons.WriteLine();
                   Cons.WriteLine("Cancellable Query Started!");
                    var cRes = (from x in lsData.AsParallel().WithCancellation(cts.Token)
                                where Math.Log(x) < 4
                                select x).Average();
                    Cons.WriteLine($"Query not cancelled result: {cRes}");
                }
                catch (OperationCanceledException cex)
                {
                    Cons.WriteLine();
                    Cons.Write($"Cancell message, {cex.Message}");
                }
            });

            Cons.WriteLine("Cancell Query!");
            cts.Cancel();

            //Cons.Write($"Cancel ?");
            //string input = Cons.ReadLine();
            //if (input.ToLower().Equals("y"))
            //    cts.Cancel();

            // Candellations and how to do it....

            Cons.Write($"Press anykey to finish and close.");
            Cons.ReadKey();
        }

        private static IEnumerable<Racer> GetDrives(string car)
        {
            var drives = from r in Formula1.GetChampions()
                from c in r.Cars
                where c == car 
                orderby r.LastName
                select r;
            return drives;
        }

        private static IEnumerable<int> LargeSample()
        {
            const int arraySize = 100000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
        }
    }
}