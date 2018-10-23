using System.Collections.Generic;

namespace ConsoleA1._00_Common
{
    public static class Formula1
    {
       private static List<Racer> racers;
       private static List<Championship> championships;

      
      internal static IList<Racer> GetChampions()
        {
            if (racers == null)
            {
                racers = new List<Racer>(40);
                racers.Add(new Racer(1, "Giuseppe", "Farina", "Italy", 33, 5, new int[] { 1950 }, new string[] { "Alfa Romeo" }));
                racers.Add(new Racer(2, "Alberto", "Ascari", "Italy", 32, 10, new int[] { 1952, 1953 }, new string[] { "Ferrari" }));
                racers.Add(new Racer(3, "Juan Manuel", "Fangio", "Argentina", 51, 24, new int[] { 1951, 1954, 1955, 1956, 1957 }, new string[] { "Alfa Romeo", "Maserati", "Mercedes", "Ferrari" }));
                racers.Add(new Racer(4, "Mike", "Hawthorn", "UK", 45, 3, new int[] { 1958 }, new string[] { "Ferrari" }));
                racers.Add(new Racer(5, "Jack", "Brabham", "Australia", 125, 14, new int[] { 1959, 1960, 1966 }, new string[] { "Cooper", "Bragham" }));
                racers.Add(new Racer(6, "Phil", "Hill", "USA", 48, 3, new int[] { 1961 }, new string[] { "Ferrari" }));
                racers.Add(new Racer(7, "Jim", "Clark", "UK", 72, 25, new int[] { 1963, 1965 }, new string[] { "Lotus" }));
                racers.Add(new Racer(8, "John", "Surtees", "UK", 111, 6, new int[] { 1964 }, new string[] { "Ferrari" }));
                racers.Add(new Racer(9, "Denny", "Hulme", "New Zeland", 112, 8, new int[] { 1967 }, new string[] { "Brabham" }));
                racers.Add(new Racer(10, "Graham", "Hill", "UK", 176, 14, new int[] { 1962, 1968 }, new string[] { "BRM", "Lotus" }));
                racers.Add(new Racer(11, "Jochen", "Rindt", "Austria", 60, 6, new int[] { 1970 }, new string[] { "Lotus" }));
                racers.Add(new Racer(12, "Jackie", "Stewart", "UK", 99, 27, new int[] { 1969, 1971, 1973 }, new string[] { "Matra", "Tyrrell" }));
                racers.Add(new Racer(12, "Emerson", "Fittipaldi", "Brazil", 144, 14, new int[] { 1972, 1974 }, new string[] { "Lotus", "McLaren" }));
                racers.Add(new Racer(13, "James", "Hunt", "UK", 91, 10, new int[] { 1976 }, new string[] { "McLaren" }));
                racers.Add(new Racer(14, "Mario", "Andretti", "USA", 128, 12, new int[] { 1978 }, new string[] { "Lotus" }));
                racers.Add(new Racer(15, "Jody", "Scheckter", "South Africa", 112, 10, new int[] { 1979 }, new string[] { "Ferrari" }));
                racers.Add(new Racer(16, "Alan", "Jones", "Australia", 115, 12, new int[] { 1980 }, new string[] { "Williams" }));
                racers.Add(new Racer(17, "Keke", "Rosberg", "Finland", 114, 5, new int[] { 1982 }, new string[] { "Williams" }));
                racers.Add(new Racer(18, "Niki", "Lauda", "Austria", 173, 25, new int[] { 1975, 1977, 1984 }, new string[] { "Ferrari", "McLaren" }));
                racers.Add(new Racer(19,"Nelson", "Piquet", "Brazil", 204, 23, new int[] { 1981, 1983, 1987 }, new string[] { "Brabham", "Williams" }));
                racers.Add(new Racer(20,"Ayrton", "Senna", "Brazil", 161, 41, new int[] { 1988, 1990, 1991 }, new string[] { "McLaren" }));
                racers.Add(new Racer(21,"Nigel", "Mansell", "UK", 187, 31, new int[] { 1992 }, new string[] { "Williams" }));
                racers.Add(new Racer(22,"Alain", "Prost", "France", 197, 51, new int[] { 1985, 1986, 1989, 1993 }, new string[] { "McLaren", "Williams" }));
                racers.Add(new Racer(23,"Damon", "Hill", "UK", 114, 22, new int[] { 1996 }, new string[] { "Williams" }));
                racers.Add(new Racer(24,"Jacques", "Villeneuve", "Canada", 165, 11, new int[] { 1997 }, new string[] { "Williams" }));
                racers.Add(new Racer(25,"Mika", "Hakkinen", "Finland", 160, 20, new int[] { 1998, 1999 }, new string[] { "McLaren" }));
                racers.Add(new Racer(26,"Michael", "Schumacher", "Germany", 287, 91, new int[] { 1994, 1995, 2000, 2001, 2002, 2003, 2004 }, new string[] { "Benetton", "Ferrari" }));
                racers.Add(new Racer(27,"Fernando", "Alonso", "Spain", 177, 27, new int[] { 2005, 2006 }, new string[] { "Renault" }));
                racers.Add(new Racer(28,"Kimi", "Räikkönen", "Finland", 148, 17, new int[] { 2007 }, new string[] { "Ferrari" }));
                racers.Add(new Racer(29,"Lewis", "Hamilton", "UK", 90, 17, new int[] { 2008 }, new string[] { "McLaren" }));
                racers.Add(new Racer(30,"Jenson", "Button", "UK", 208, 12, new int[] { 2009 }, new string[] { "Brawn GP" }));
                racers.Add(new Racer(31,"Sebastian", "Vettel", "Germany", 81, 21, new int[] { 2010, 2011 }, new string[] { "Red Bull Racing" }));

              return racers;
            }

            return racers;
        }

        public static IEnumerable<Championship> GetChampionships()
        {
            if (championships == null)
            {
                championships = new List<Championship>();
                championships.Add(new Championship
                {
                    Year = 1950,
                    Champion = "Nino Farina",
                    Second = "Juan Manuel Fangio",
                    Third = "Luigi Fagioli"
                });
                championships.Add(new Championship
                {
                    Year = 1951,
                    Champion = "Juan Manuel Fangio",
                    Second = "Alberto Ascari",
                    Third = "Froilan Gonzalez"
                });
                championships.Add(new Championship
                {
                    Year = 1952,
                    Champion = "Alberto Ascari",
                    Second = "Nino Farina",
                    Third = "Piero Taruffi"
                });
                championships.Add(new Championship
                {
                    Year = 1953,
                    Champion = "Alberto Ascari",
                    Second = "Juan Manuel Fangio",
                    Third = "Nino Farina"
                });
                championships.Add(new Championship
                {
                    Year = 1954,
                    Champion = "Juan Manuel Fangio",
                    Second = "Froilan Gonzalez",
                    Third = "Mike Hawthorn"
                });
                championships.Add(new Championship
                {
                    Year = 1955,
                    Champion = "Juan Manuel Fangio",
                    Second = "Stirling Moss",
                    Third = "Eugenio Castellotti"
                });
                championships.Add(new Championship
                {
                    Year = 1956,
                    Champion = "Juan Manuel Fangio",
                    Second = "Stirling Moss",
                    Third = "Peter Collins"
                });
                championships.Add(new Championship
                {
                    Year = 1957,
                    Champion = "Juan Manuel Fangio",
                    Second = "Stirling Moss",
                    Third = "Luigi Musso"
                });
                championships.Add(new Championship
                {
                    Year = 1958,
                    Champion = "Mike Hawthorn",
                    Second = "Stirling Moss",
                    Third = "Tony Brooks"
                });
                championships.Add(new Championship
                {
                    Year = 1959,
                    Champion = "Jack Brabham",
                    Second = "Tony Brooks",
                    Third = "Stirling Moss"
                });
                championships.Add(new Championship
                {
                    Year = 1960,
                    Champion = "Jack Brabham",
                    Second = "Bruce McLaren",
                    Third = "Stirling Moss"
                });
                championships.Add(new Championship
                {
                    Year = 1961,
                    Champion = "Phil Hill",
                    Second = "Wolfgang von Trips",
                    Third = "Stirling Moss"
                });
                championships.Add(new Championship
                {
                    Year = 1962,
                    Champion = "Graham Hill",
                    Second = "Jim Clark",
                    Third = "Bruce McLaren"
                });
                championships.Add(new Championship
                {
                    Year = 1963,
                    Champion = "Jim Clark",
                    Second = "Graham Hill",
                    Third = "Richie Ginther"
                });
                championships.Add(new Championship
                {
                    Year = 1964,
                    Champion = "John Surtees",
                    Second = "Graham Hill",
                    Third = "Jim Clark"
                });
                championships.Add(new Championship
                {
                    Year = 1965,
                    Champion = "Jim Clark",
                    Second = "Graham Hill",
                    Third = "Jackie Stewart"
                });
                championships.Add(new Championship
                {
                    Year = 1966,
                    Champion = "Jack Brabham",
                    Second = "John Surtees",
                    Third = "Jochen Rindt"
                });
                championships.Add(new Championship
                {
                    Year = 1967,
                    Champion = "Dennis Hulme",
                    Second = "Jack Brabham",
                    Third = "Jim Clark"
                });
                championships.Add(new Championship
                {
                    Year = 1968,
                    Champion = "Graham Hill",
                    Second = "Jackie Stewart",
                    Third = "Dennis Hulme"
                });
                championships.Add(new Championship
                {
                    Year = 1969,
                    Champion = "Jackie Stewart",
                    Second = "Jackie Ickx",
                    Third = "Bruce McLaren"
                });
                championships.Add(new Championship
                {
                    Year = 1970,
                    Champion = "Jochen Rindt",
                    Second = "Jackie Ickx",
                    Third = "Clay Regazzoni"
                });
                championships.Add(new Championship
                {
                    Year = 1971,
                    Champion = "Jackie Stewart",
                    Second = "Ronnie Peterson",
                    Third = "Francois Cevert"
                });
                championships.Add(new Championship
                {
                    Year = 1972,
                    Champion = "Emerson Fittipaldi",
                    Second = "Jackie Stewart",
                    Third = "Dennis Hulme"
                });
                championships.Add(new Championship
                {
                    Year = 1973,
                    Champion = "Jackie Stewart",
                    Second = "Emerson Fittipaldi",
                    Third = "Ronnie Peterson"
                });
                championships.Add(new Championship
                {
                    Year = 1974,
                    Champion = "Emerson Fittipaldi",
                    Second = "Clay Regazzoni",
                    Third = "Jody Scheckter"
                });
                championships.Add(new Championship
                {
                    Year = 1975,
                    Champion = "Niki Lauda",
                    Second = "Emerson Fittipaldi",
                    Third = "Carlos Reutemann"
                });
                championships.Add(new Championship
                {
                    Year = 1976,
                    Champion = "James Hunt",
                    Second = "Niki Lauda",
                    Third = "Jody Scheckter"
                });
                championships.Add(new Championship
                {
                    Year = 1977,
                    Champion = "Niki Lauda",
                    Second = "Jody Scheckter",
                    Third = "Mario Andretti"
                });
                championships.Add(new Championship
                {
                    Year = 1978,
                    Champion = "Mario Andretti",
                    Second = "Ronnie Peterson",
                    Third = "Carlos Reutemann"
                });
                championships.Add(new Championship
                {
                    Year = 1979,
                    Champion = "Jody Scheckter",
                    Second = "Gilles Villeneuve",
                    Third = "Alan Jones"
                });
                championships.Add(new Championship
                {
                    Year = 1980,
                    Champion = "Alan Jones",
                    Second = "Nelson Piquet",
                    Third = "Carlos Reutemann"
                });
                championships.Add(new Championship
                {
                    Year = 1981,
                    Champion = "Nelson Piquet",
                    Second = "Carlos Reutemann",
                    Third = "Alan Jones"
                });
                championships.Add(new Championship
                {
                    Year = 1982,
                    Champion = "Keke Rosberg",
                    Second = "Didier Pironi",
                    Third = "John Watson"
                });
                championships.Add(new Championship
                {
                    Year = 1983,
                    Champion = "Nelson Piquet",
                    Second = "Alain Prost",
                    Third = "Rene Arnoux"
                });
                championships.Add(new Championship
                {
                    Year = 1984,
                    Champion = "Niki Lauda",
                    Second = "Alain Prost",
                    Third = "Elio de Angelis"
                });
                championships.Add(new Championship
                {
                    Year = 1985,
                    Champion = "Alain Prost",
                    Second = "Michele Alboreto",
                    Third = "Keke Rosberg"
                });
                championships.Add(new Championship
                {
                    Year = 1986,
                    Champion = "Alain Prost",
                    Second = "Nigel Mansell",
                    Third = "Nelson Piquet"
                });
                championships.Add(new Championship
                {
                    Year = 1987,
                    Champion = "Nelson Piquet",
                    Second = "Nigel Mansell",
                    Third = "Ayrton Senna"
                });
                championships.Add(new Championship
                {
                    Year = 1988,
                    Champion = "Ayrton Senna",
                    Second = "Alain Prost",
                    Third = "Gerhard Berger"
                });
                championships.Add(new Championship
                {
                    Year = 1989,
                    Champion = "Alain Prost",
                    Second = "Ayrton Senna",
                    Third = "Riccardo Patrese"
                });
                championships.Add(new Championship
                {
                    Year = 1990,
                    Champion = "Ayrton Senna",
                    Second = "Alain Prost",
                    Third = "Nelson Piquet"
                });
                championships.Add(new Championship
                {
                    Year = 1991,
                    Champion = "Ayrton Senna",
                    Second = "Nigel Mansell",
                    Third = "Riccardo Patrese"
                });
                championships.Add(new Championship
                {
                    Year = 1992,
                    Champion = "Nigel Mansell",
                    Second = "Riccardo Patrese",
                    Third = "Michael Schumacher"
                });
                championships.Add(new Championship
                {
                    Year = 1993,
                    Champion = "Alain Prost",
                    Second = "Ayrton Senna",
                    Third = "Damon Hill"
                });
                championships.Add(new Championship
                {
                    Year = 1994,
                    Champion = "Michael Schumacher",
                    Second = "Damon Hill",
                    Third = "Gerhard Berger"
                });
                championships.Add(new Championship
                {
                    Year = 1995,
                    Champion = "Michael Schumacher",
                    Second = "Damon Hill",
                    Third = "David Coulthard"
                });
                championships.Add(new Championship
                {
                    Year = 1996,
                    Champion = "Damon Hill",
                    Second = "Jacques Villeneuve",
                    Third = "Michael Schumacher"
                });
                championships.Add(new Championship
                {
                    Year = 1997,
                    Champion = "Jacques Villeneuve",
                    Second = "Heinz-Harald Frentzen",
                    Third = "David Coulthard"
                });
                championships.Add(new Championship
                {
                    Year = 1998,
                    Champion = "Mika Hakkinen",
                    Second = "Michael Schumacher",
                    Third = "David Coulthard"
                });
                championships.Add(new Championship
                {
                    Year = 1999,
                    Champion = "Mika Hakkinen",
                    Second = "Eddie Irvine",
                    Third = "Heinz-Harald Frentzen"
                });
                championships.Add(new Championship
                {
                    Year = 2000,
                    Champion = "Michael Schumacher",
                    Second = "Mika Hakkinen",
                    Third = "David Coulthard"
                });
                championships.Add(new Championship
                {
                    Year = 2001,
                    Champion = "Michael Schumacher",
                    Second = "David Coulthard",
                    Third = "Rubens Barrichello"
                });
                championships.Add(new Championship
                {
                    Year = 2002,
                    Champion = "Michael Schumacher",
                    Second = "Rubens Barrichello",
                    Third = "Juan Pablo Montoya"
                });
                championships.Add(new Championship
                {
                    Year = 2003,
                    Champion = "Michael Schumacher",
                    Second = "Kimi Räikkönen",
                    Third = "Juan Pablo Montoya"
                });
                championships.Add(new Championship
                {
                    Year = 2004,
                    Champion = "Michael Schumacher",
                    Second = "Rubens Barrichello",
                    Third = "Jenson Button"
                });
                championships.Add(new Championship
                {
                    Year = 2005,
                    Champion = "Fernando Alonso",
                    Second = "Kimi Räikkönen",
                    Third = "Michael Schumacher"
                });
                championships.Add(new Championship
                {
                    Year = 2006,
                    Champion = "Fernando Alonso",
                    Second = "Michael Schumacher",
                    Third = "Felipe Massa"
                });
                championships.Add(new Championship
                {
                    Year = 2007,
                    Champion = "Kimi Räikkönen",
                    Second = "Lewis Hamilton",
                    Third = "Fernando Alonso"
                });
                championships.Add(new Championship
                {
                    Year = 2008,
                    Champion = "Lewis Hamilton",
                    Second = "Felipe Massa",
                    Third = "Kimi Raikkonen"
                });
                championships.Add(new Championship
                {
                    Year = 2009,
                    Champion = "Jenson Button",
                    Second = "Sebastian Vettel",
                    Third = "Rubens Barrichello"
                });
                championships.Add(new Championship
                {
                    Year = 2010,
                    Champion = "Sebastian Vettel",
                    Second = "Fernando Alonso",
                    Third = "Mark Webber"
                });
                championships.Add(new Championship
                {
                    Year = 2011,
                    Champion = "Sebastian Vettel",
                    Second = "Jenson Button",
                    Third = "Mark Webber"
                });
            }
            return championships;
        }

    }

    public class Championship
    {
        public int Year { get; set; }
        public string Champion { get; set; }
        public string Second { get; set; }
        public string Third { get; set; }
    }

}
