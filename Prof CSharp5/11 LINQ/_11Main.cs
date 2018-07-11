using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._00_Common;
using Cons = System.Console;

namespace ConsoleA1._11_LINQ
{
    internal class _11Main
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

            //Extension Method! Just another way to get at static classes!
            var s = "All";
            s.Boots();

            //Q1 using extensions methods to for show...
            var champs2 = new List<Racer>(Formula1.GetChampions());
            IEnumerable<Racer> Brits = champs2.Where(c => c.Country == "British").OrderBy(o => o.LastName)
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
            
            Cons.ReadKey();
        }
    }
}
