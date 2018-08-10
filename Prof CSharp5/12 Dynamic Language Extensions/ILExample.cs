using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._12_Dynamic_Language_Extensions
{
    class IlExample
    {
        static void Main(string[] args)
        {
            StaticClass sClass = new StaticClass();
            //DynamicClass dClass = new DynamicClass();

            Console.WriteLine($"Static Class Value: {sClass.IntValue}");
            //Console.WriteLine($"Dynamic Class Value: {dClass.DynValue}");
            var test = Console.ReadLine();
        }
    }

    class StaticClass
    {
        public int IntValue = 100;
    }

    class DynamicClass
    {
        public dynamic DynValue = 100;
    }
}
