using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._00_Common;

namespace ConsoleA1._11_LINQ
{
    public static class Formula1
    {
        private static List<Racer> racers;
            
        internal static IList<Racer> GetChampions()
        {
            if (racers == null)
            {
                racers = new List<Racer>(40);
                racers.Add(new Racer(1, "Giuseppe", "Farina", "Italy", 33, 5, new int[] {1950}, new string[] {"Alfa Romeo"}));
                racers.Add(new Racer(2, "Alberto", "Ascari", "Italy", 32, 10, new int[] {1952, 1953}, new string[] {"Ferrari"}));
                racers.Add(new Racer(3, "Juan Manuel", "Fangio", "Argentina", 51, 24, new int[] {1951, 1954, 1955, 1956, 1957}, new string[] {"Alfa Romeo", "Maserati", "Mercedes", "Ferrari"}));
                racers.Add(new Racer(4, "Mike", "Hawthorn", "British", 45, 3, new int[] {1958}, new string[] {"Ferrari"}));
                racers.Add(new Racer(5, "Jack", "Brabham", "Australia", 125, 14, new int[] {1959, 1960, 1966}, new string[] {"Cooper", "Bragham"}));
                racers.Add(new Racer(6, "Phil", "Hill", "USA", 48, 3, new int[] {1961}, new string[] {"Ferrari"}));
                racers.Add(new Racer(7, "Jim", "Clark", "British", 72, 25, new int[] {1963, 1965}, new string[] {"Lotus"}));
                racers.Add(new Racer(8, "John", "Surtees", "British", 111, 6, new int[] {1964}, new string[] {"Ferrari"}));
                racers.Add(new Racer(9, "Denny", "Hulme", "New Zeland", 112, 8, new int[] {1967}, new string[] {"Brabham"}));
                racers.Add(new Racer(10, "Graham", "Hill", "British", 176, 14, new int[] {1962, 1968}, new string[] {"BRM", "Lotus"}));
                racers.Add(new Racer(11, "Jochen", "Rindt", "Austria", 60, 6, new int[] {1970}, new string[] {"Lotus"}));
                racers.Add(new Racer(12, "Jackie", "Stewart", "British", 99, 27, new int[] {1969, 1971, 1973}, new string[] {"Matra", "Tyrrell"}));
                racers.Add(new Racer(12, "Emerson", "Fittipaldi", "Brazil", 144, 14, new int[] {1972, 1974}, new string[] {"Lotus", "McLaren"}));

                return racers;
            }

            return null;

        }
    }
}
