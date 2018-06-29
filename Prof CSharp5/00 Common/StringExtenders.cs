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
    }
}
