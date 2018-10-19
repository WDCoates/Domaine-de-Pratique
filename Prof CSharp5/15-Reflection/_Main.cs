using System;
using System.Reflection;
using ConsoleA1._00_Common;
using MyVectors; 
using Cons = System.Console;



namespace ConsoleA1._15_Reflection
{
    class _Main
    {
        public static void Main()
        {
            Cons.WriteLine($"Lets look at Reflection...");

            double d = 44.4d;
            Type t = d.GetType();

            Cons.WriteLine(t);
            Cons.WriteLine(t.FullName);

            Employee e = new Employee(1, 100000);
            t = e.GetType();
            Cons.WriteLine(t);
            Cons.WriteLine(t.BaseType);
            Cons.WriteLine(t.UnderlyingSystemType);
            Cons.WriteLine(t.IsClass);
            Cons.WriteLine(t.IsPrimitive);

            t = typeof( MyVector);
            // var containingAssembly = new Assembly(t);   this I could not get to work first time!

            //Methods...



            Cons.WriteLine($"Press any key to exit.");
            Cons.ReadKey();
        }
    }
}
