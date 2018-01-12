using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ConsoleA1._00_Common;
using System.Collections;

namespace ConsoleA1._06_Arrays_and_Tuples
{
    internal class Program
    {
        public static void Main()
        {
            //Simple array
            int[] intArray = new int[4] { 1, 2, 3, 4 };
            int[] intArray2 = { 1, 1, 1, 1, 1, 1, 4 };
            int[,] int2D = { { 1, 2 }, { 3, 4 } };
            int [] [] intJag = new int[2] [];
            intJag[0] = new int[3] { 1,2,3 };
            intJag[1] = new int[] { 1,2,3 };

            intArray.GetEnumerator().Reset();
            var intSect = intArray.Intersect(intArray2).ToList();

            //Create an array but imagine the type is not known

            var aV = 10;

            if (aV.GetType() == typeof(int))
            {
                Array aArray1 = Array.CreateInstance(typeof(int), aV);
                for (int i = 0; i < aV; i++)
                {
                    aArray1.SetValue(i^2, i);
                }

            }

            //Multi none zero based arrays
            int[] dims = {10, 2};
            int[] lowerBounds = {1, 101};
            Array racers = Array.CreateInstance(typeof(Person), dims, lowerBounds);

            racers.SetValue(new Person { FirstName = "Alice",LastName = "Bean"}, index1:1, index2: 101);
            racers.SetValue(new Person { FirstName = "Bridge", LastName = "Over" }, index1: 1, index2: 101);

            //Copy and Clone the same when accessing ref types still point to same object!
            Person[] beatles = {new Person() {FirstName = "Paul"}, new Person(){FirstName = "John"} };
            Person[] bootlegBeats = (Person [])beatles.Clone();
            bootlegBeats[0].FirstName = "Anna";
            Person[] b = new Person[10];
            beatles.CopyTo(b,0);
            b[0].FirstName = "Betty";
            
            //Sorting
            string[] stars = {"Chrissie", "Dave", "Chris", "Louise"};
            Array.Sort(stars);

            Person[] plebs =
            {
                new Person() {FirstName = "Zak", LastName = "Adamson"}, new Person() {FirstName = "Adam", LastName = "Zeener"},
                new Person() {FirstName = "Deedee", LastName = "Jones"}, new Person() {FirstName = "Ajoie", LastName = "Jones"}
            };
            Array.Sort(plebs);

            Array.Sort(plebs, new PersonComparer(PersonCompareType.FirstName));
            Array.Sort(plebs, new PersonComparer(PersonCompareType.LastName));

            //Array Passing
            Person[] team = GetTeam();

            PrintTeamNames(team);

            //Example of Covariance Person - Object - Person
            PrintTeamO(team);

            //ArraySegments
            int[] iA1 = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            int[] iA2 = { 12, 22, 32, 42, 52, 62, 72, 82, 92 };

            var segments = new ArraySegment<int>[2]
            {
                new ArraySegment<int>(iA1, 0, 4),
                new ArraySegment<int>(iA2, 0, 1),
            };

            var sum = Segments.SumOfSegments(segments);

            //what foreach really does...
            var enume = plebs.GetEnumerator();
            //IEnumerator<Person> enume = plebs.GetEnumerator();    //Not Sure why this does not work!
            while (enume.MoveNext())
            {
                Person p = (Common.Person)enume.Current;
                Console.WriteLine($"{p.FirstName}, {p.LastName}");
            }

            //usinf old methods for yeild...
            var sColl = new ShoeCollection();
            foreach (var shoe in sColl)
            {
                Console.WriteLine($"Shoe: {shoe}");
            }
            var bColl = new BootCollection();
            foreach (var boot in bColl)
            {
                Console.WriteLine($"Boot: {boot}");
            }

            //Game Client
            var game = new GameOX();
            IEnumerator<object> gEnumerator = game.Naught();

            while (gEnumerator != null && gEnumerator.MoveNext())
            {
                gEnumerator = gEnumerator.Current as IEnumerator<object>;
            }


            //Finally Tuples 
            var res = Tuples.tDiv(77, 3);
            Console.WriteLine();
            Console.WriteLine($"{res}...{res.Item1}...{res.Item2}");

            var tm = Tuples.mTuples();

            //Structural Comparison
            var p1 = new Person { FirstName = "Jane", LastName = "Girl" };
            Person[] aP1 =
            {
                new Person { FirstName = "John", LastName = "Boy" },
                p1
            };
            Person[] aP2 =
            {
                new Person { FirstName = "Adam", LastName = "Ant" },
                p1
            };

            Person[] aPC1 =
            {
                new Person { FirstName = "John", LastName = "Boy" },
                p1
            };
            Person[] aR1 = aP1;

            if (aP1 != aP2)
                Console.WriteLine("not the same reference!");

            if (aP1 == aR1)
                Console.WriteLine("Same reference!");

            if (aP1 == aPC1)
                Console.WriteLine("Same reference!");

            if ((aP1 as IStructuralEquatable).Equals(aPC1, EqualityComparer<Person>.Default))
            {
                Console.WriteLine("What the fuck!!!!!!");
            }


            //Now compareing tuples!
            var t1 = Tuple.Create<int, string>(1, "Steve");
            var t2 = Tuple.Create<int, string>(1, "Steve");

            if (t1 != t2)
                Console.WriteLine("t1 does not have the sane reference as t2");

            //Test Content
            if (t1.Equals(t2))
                Console.WriteLine($"t1 has same content as t2");
            //use my new TupleComp 

            
            //Error but don't know why!!!!!!!!!!!
            //if (t1.Equals(t2, new TupleComp()))
              //  Console.WriteLine("!");


        }

        static Person[] GetTeam()
        {
            return new Person[]
            {
                new Person {FirstName = "Dave", LastName = "Dee"},
                new Person {FirstName = "Ellenor", LastName = "Rigby"},
                new Person {FirstName = "Geoff", LastName = "Nowhere"},
                new Person {FirstName = "Zak", LastName = "Johnsson"}
            };
        }

        static void PrintTeamNames(Person[] team)
        {
            foreach (var t in team)
            {
                Console.WriteLine($"First name {t.FirstName}");
            }
        }

        static void PrintTeamO(object[] objects)
        {
            Console.WriteLine("");
            Console.WriteLine("Passed Object Print");
            Person[] team = (Person[])objects.Clone();
            foreach (var t in team)
            {
                Console.WriteLine($"First name {t.FirstName}");
            }
        }
    }
}
