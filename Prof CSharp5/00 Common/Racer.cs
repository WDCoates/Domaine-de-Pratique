﻿using System;

namespace ConsoleA1._00_Common
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Wins { get; set; }

        public Racer(int id, string firstName, string lastName, string country)
            :this(id, firstName, lastName, country, wins: 0)
        {
        }
        public Racer(int id, string firstName, string lastName, string country, int wins)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Wins = wins;
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
}