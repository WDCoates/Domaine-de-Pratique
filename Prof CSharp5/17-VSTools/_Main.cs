using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;

namespace ConsoleA1._17_VSTools
{
    class _Main
    {
        public static void Main(string [] args)
        {
            Console.WriteLine("Some refactoring!");
            Console.WriteLine($"Some Unit testing");

            string wine = "Red";
            WineSampler wSam = new WineSampler(wine);
            var res = wSam.GetWineSample("Leather", "Blackberry");

            var wines = wSam.WinesByCountry("Italy");

            IChampionLoader iChaps = new IChaps();

        }
    }


    class WineSampler
    {
        public WineSampler(string wine)
        {
            if (wine.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException($"Wine can not be empty!");
            }   
            this.wine = wine;
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

        public XElement WinesByCountry(string country)
        {
            XElement vintages = XElement.Load("http://www.cninnovation.com/downloads/racers.xml");
            var q = from r in vintages.Elements("Racer")
                where r.Element("Country").Value == country
                select new XElement("Wines",
                    new XAttribute("Name", r.Element("Firstname").Value + " " + r.Element("Lastname").Value));

            return new XElement("Wines", q.ToArray());

        }

        private readonly IChampionLoader cLoader;

        public WineSampler(IChampionLoader loader)
        {
            this.cLoader = loader;
        }

        public XElement ChampionsByCountry(string country)
        {
            XElement vintages = cLoader.GetChampions();
            var q = from r in vintages.Elements("Racer")
                where r.Element("Country").Value == country
                select new XElement("Racers",
                    new XAttribute("Name", r.Element("Firstname").Value + " " + r.Element("Lastname").Value));

            return new XElement("Driver", q.ToArray());

        }


    }

    public interface IChampionLoader
    {
        XElement GetChampions();
    }

    public class TIhaps : IChampionLoader
    {
        public XElement GetChampions()
        {
            return XElement.Load("http://www.cninnovation.com/downloads/racers.xml");
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
