using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._00_Common
{
    public static class StringExtenders
    {
        public static void Boots(this string b)
        {
            Console.WriteLine($"Crotch, Thigh, Knee, Calf, Ankle:{b}.");
        }

        public static string FirstName(this string name)
        {
            int ix = name.LastIndexOf(' ');
            return name.Substring(0, ix);
        }

        public static string LastName(this string name)
        {
            int ix = name.LastIndexOf(' ');
            return name.Substring(ix + 1);
        }
    }
}
