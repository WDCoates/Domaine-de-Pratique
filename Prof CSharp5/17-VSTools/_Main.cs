using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;

namespace ConsoleA1._17_VSTools
{
    class _Main
    {
        public static void Main(string [] args)
        {
            Console.WriteLine("Some refactoring!");
            Console.WriteLine($"Some Unit testing");

            
        }
    }


    class WineSampler
    {
        public WineSampler(string wine)
        {
            if (wine.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException($"Wine can not be empty!");
                this.wine = wine;
            }
        }

        private string wine;

        public string GetWineSample(string nose, string mouth)
        {
            if (nose.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException($"Nose must smell something!");
            }
            if (mouth.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException($"Mouth must taste something!");
            }

            return wine + nose + mouth;
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

    public class Deep
    {
        public static bool IsTheSeaDeep()
        {
            return true;
        }
    }


}
