using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using con = System.Console;

namespace ConsoleA1._00_Common
{
    public static class Statics
    {
        public static System.Action bonjour(string s)
        {
            con.WriteLine($"Hello {s}");
            return null;
        }

        public static Action bienvenue(string s)
        {
            con.WriteLine($"Welcome {s}");
            return null;
        }

        public static Action au_revoir(string s)
        {
            con.WriteLine($"Goodbye {s}");
            return null;
        }
    }
}
