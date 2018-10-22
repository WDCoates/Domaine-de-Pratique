using System;
using System.Linq;
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
            t = typeof(string);
            MethodInfo[] methods = t.GetMethods();
            foreach (var m in methods)
            {
                Cons.WriteLine($"{m.Name} => {m.Attributes}");
            }

            Cons.WriteLine($"Press any key to see events.");
            Cons.ReadKey();
            EventInfo[] events = t.GetEvents();
            if (events.Any())
            {
                foreach (var ev in events)
                {
                    Cons.WriteLine($"{ev.Name} => {ev.Attributes}");
                } 
            }
            else
            {
                Cons.WriteLine($"No Events for {t.FullName}");
            }

            TypeViewMessages.DispTypeView();

            Cons.WriteLine($"Press any key Lookup Whats New...");
            Cons.ReadKey();

            LookupWhatsNew.LookWhatsNew();

            Cons.WriteLine($"Press any key to exit.");
            Cons.ReadKey();
        }
    }
}
