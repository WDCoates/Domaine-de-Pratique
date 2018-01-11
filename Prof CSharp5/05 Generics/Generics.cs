using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleA1._05_Generics
{
    class Generics
    {
        public class Person: IComparable<Person>
        {
            public string Name;

            public int CompareTo(Person toP)
            {
                return String.Compare(Name, toP.Name, StringComparison.Ordinal);
            }
        }

        public class Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public override string ToString()
            {
                return String.Format($"Width: {Width:F}, Height: {Height:#####.######}");
            }

            public Square CreateSquare(double side)
            {
                return new Square(side);
            }
        }

        public class Box : Shape
        {
            
        }


        public class Square : Shape
        {
            public Square(double side)
            {
                Width = side;
                Height = side;
            }
            public override string ToString()
            {
                return String.Format($"Side: {Width:#####.######}");
            }
        }

        public interface IIndex<out T>
        {
            T this[int index] { get; }
            int Count { get; }
        }

        public class SquareCollection: IIndex<Square>
        {
            private readonly Square[] _data = new Square[]
            {
                new Square(1223.33),
                new Square(1223.33),
                new Square(1223.33)
            };

            private static SquareCollection _sColl;

            public static SquareCollection GetReSquares()
            {
                return _sColl ?? (_sColl = new SquareCollection());
            }

            public Square this[int index]
            {
                get
                {
                    if (index < 0 || index > _data.Length)
                        throw new ArgumentOutOfRangeException(nameof(index));
                    return _data[index];
                }
            }

            public int Count => _data.Length;
        }

        public static void Main()
        {
            var gracePeriod = new TimeSpan(1, 0, 0);
            var date = DateTime.Now;
            var date1 = date.AddDays(-1);
            var date2 = date1 + TimeSpan.Parse("17:00");
            var date3 = date2 - gracePeriod;

            var aList = new ArrayList();
            //Example of Boxing
            for (var i = 1; i <= 10; i++)
            {
                aList.Add(i);
            }

            for (var i = 0; i < aList.Count; i++)
            {
                // Unboxing....
                var iV = (int) aList[i];
                WriteLine($"This is a list {i}={iV}");
            }

            //Better loop but also unboxing in i2
            foreach (var i2 in aList)
            {
                WriteLine($"{i2}");
            }

            //Better Use of Generics
            var bList = new List<int>();
            for (var i = 1; i <= 10; i++)
            {
                bList.Add(i);
                WriteLine($"Added {bList[i-1],-2:D} to bList position {i-1}");
            }


            //Generic LinkedList <T>
            var llList2 = new LinkedList<int>();
            llList2.AddLast(1);
            llList2.AddFirst(100);
            llList2.AddLast(10);

            foreach (var llint in llList2)
            {
                WriteLine($"{llint, -4} Item.");
            }

            var p1 = new Person();
            var p2 = new Person();
            p1.Name = "Dave";
            p2.Name = p1.Name;

            if (p1.CompareTo(p2) == 0)
            {
                p2.Name = "Chrissie";
            }

            /*
             * Covariance with classes
             */

            var s1 = new Shape
            {
                Width = 101.45,
                Height = 25.25
            };

            WriteLine(s1.ToString());
            var q1 = new Square(s1.Width);
            WriteLine(q1.ToString());

            Shape s2 = s1.CreateSquare(s1.Width);
            WriteLine(s2.ToString());

            var ans = GiveIt("Do It ");
            WriteLine(ans);

            /*
             * Covariance with Generic Interfaces
             */

            IIndex<Square> squares = SquareCollection.GetReSquares();
            IIndex<Shape> shapes = squares;

            for (int i=0; i < shapes.Count; i++)
            {
                WriteLine(shapes[i]);
            }

            var nShapeDisplay = new ShowShape();
            nShapeDisplay.Show(s1);
            IDisplay<Shape> nSqIDisplay = new ShowShape();
            var nBox = new Square(1.111);
            nSqIDisplay.Show(nBox);

            IDisplay<Shape> iDisplayShape = new ShowShape();
            IDisplay<Square> iDisplaySq = iDisplayShape;
            iDisplaySq.Show(q1);

            // Generic Struct
            Nullable<int> n;
            n = 1;
            if (n.HasValue) WriteLine($"This is good. {n}");

            int? n1 = 0;
            n1 = null;
            var msg = "";
            msg = (n1 == null ? $"n1 is null" : $"n1 is not null!");


            ReadKey();
        }

        private static string GiveIt(string s)
        {
            return s + "100%";
        }

        public interface IDisplay<in T>
        {
            void Show(T thing);
        }

        public class ShowShape : IDisplay<Shape>
        {
            public void Show(Shape s)
            {
                WriteLine($"Shape width: {s.Width}; height:{s.Height}");
            }
        }
    }
}
