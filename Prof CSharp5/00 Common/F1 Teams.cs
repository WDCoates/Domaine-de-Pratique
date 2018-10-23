using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._00_Common
{
    class F1_Teams
    {
        private static List<Team> teams;

        public static IList<Team> GetConstructorChampions()
        {
            if (teams == null)
            {
                teams = new List<Team>()
                {
                    new Team("Vanwall", 1958),
                    new Team("Cooper", 1959, 1960),
                    new Team("Ferrari", 1961, 1964, 1975, 1976, 1977, 1979, 1982, 1983, 1999, 2000, 2001, 2002, 2003, 2004, 2007, 2008),
                    new Team(name:"BRM", years: 1962),
                    new Team(name:"Lotus", years: new [] {1963, 1965, 1968, 1970, 1972, 1973, 1978}),
                    new Team("Brabham", 1966, 1967),
                    new Team(name:"Matra", years: 1969),
                    new Team(name:"Tyrell", years: 1971),
                    new Team("McLaren", 1974, 1984, 1985, 1988, 1989, 1900, 1991, 1998),
                    new Team("Williams", 1980, 1981, 1986, 1987, 1992, 1993, 1994, 1996, 1997),
                    new Team(name:"Benetton", years: 1995),
                    new Team(name:"Renault", years: new [] {2005, 2006}),
                    new Team(name:"Brawn GP", years: 2009),
                    new Team(name:"Red Bull Racing", years: new [] {2010, 2011})
                };
            }

            return teams;
        }
    }
}
