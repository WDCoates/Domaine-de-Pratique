using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ConsoleA1._00_Common;
using Cons = System.Console;

namespace ConsoleA1._12_Dynamic_Language_Extensions
{
    class _12Main
    {
        public static void Main(string[] args)
        {
            Cons.WriteLine("Start Dynamic Language Extensions! - Checking only done at runtime.");

            var sPerson = new Person();
            dynamic dyPerson = new Person();

            //sPerson.GetFullName("John", "Smithes");   //would not get past compiler.
            try
            {
                var fName = dyPerson.GetFullName("This", "Is!");
            }
            catch (Exception ex)
            {
                Cons.WriteLine($"No method: {ex.Message}");
            }

            //Changing Type completly not just casting it!

            dynamic dyn;
            dyn = 100;
            Cons.WriteLine($"dyn type: {dyn.GetType()}, Value: {dyn}");

            dyn = "I'm a changling, see me change!";
            Cons.WriteLine($"dyn type: {dyn.GetType()}, Value: {dyn}");

            Person p = new Person() {FirstName = "Fme", LastName = "Lme"};
            var f = p.FullNameToString();
            var t = p.ToString();
            
            dyn = new Person() {FirstName = "Dave", LastName = "Testy"};
            try
            {
                Cons.WriteLine($"dyn type: {dyn.GetType()}, Value: {dyn.FullNameToString()}");
            }
            catch (Exception ex)
            {
                Cons.WriteLine($"dyn type: {dyn.GetType()}, Value: {dyn.ToString()}");
            }



            Cons.ReadKey();
        }
    }
}
