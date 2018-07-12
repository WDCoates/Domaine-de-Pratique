using System;
using System.Collections.Generic;

namespace ConsoleA1._00_Common
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Starts { get; set; }
        public int Wins { get; set; }
        public IEnumerable<string> Cars { get; private set; }
        public IEnumerable<int> Years { get; private set; }

        public Racer(int id, string firstName, string lastName, string country)
            : this(id, firstName, lastName, country, 0, 0, null, null)
        {
        }

        public Racer(int id, string firstName, string lastName, string country, int wins)
            : this(id, firstName, lastName, country, 0, wins, null, null)
        {
        }
        public Racer(int id, string firstName, string lastName, string country, int starts, int wins, IEnumerable<int> years, IEnumerable<string> cars)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Starts = starts;
            Wins = wins;
            Years = new List<int>(years);
            Cars = new List<string>(cars);
        }

        public override string ToString()
        {
            return String.Format($"{LastName}, {FirstName} from {Country}.");
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null) format = "n";

            switch (format.ToUpper())
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "A":
                    return String.Format($"{LastName},{FirstName}  Starts: {Starts} with {Wins} Wins.");
                case "W":
                    return String.Format($"{ToString()}, Wins: {Wins}.");
                default:
                    throw new FormatException(String.Format(formatProvider, "Format {format} is not supported"));
            }

        }


        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            int compare = string.Compare(LastName, other.LastName);
            if (compare == 0)
                return string.Compare(FirstName, other.FirstName);
            return compare;

        }

    }

    public class RacerInfo
    {
        public int Year { get; set; }
        public int Position { get; set; }

        


    }
}
