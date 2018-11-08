using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._17_VSTools
{
    class _Main
    {
        public static void Main(string [] args)
        {
            Console.WriteLine("Some refactoring!");



        }
    }

    public class car
    {
        private string colour;
        public string Style { get; }

        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public int Go()
        {
            int speed = 100;
            return speed;
        }
    }
}
