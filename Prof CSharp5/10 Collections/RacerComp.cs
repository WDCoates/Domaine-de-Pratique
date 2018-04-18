using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._00_Common;

namespace ConsoleA1._10_Collections
{
    public class RacerComp: IComparer<Racer>
    {
        public enum CompareType
        {
            LastName,
            FirstName,
            Country,
            Wins
        }

        private CompareType compType;

        public RacerComp(CompareType compType)
        {
            this.compType = compType;
        }

        public int Compare(Racer x, Racer y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            int res;
            switch (compType)
            {
                case CompareType.LastName:
                    res = string.Compare(x.LastName, y.LastName);
                    if (res != 0) return res;
                    return string.Compare(x.FirstName, y.FirstName);
                case CompareType.FirstName:
                    res = string.Compare(x.FirstName, y.FirstName);
                    if (res != 0) return res;
                    return string.Compare(x.LastName, y.LastName);
                case CompareType.Country:
                    res = string.Compare(x.Country, y.Country);
                    if (res == 0)
                    {
                        this.compType = CompareType.LastName;
                        res = this.Compare(x, y);
                        this.compType = CompareType.Country;
                        return res;
                    }
                    else
                        return res;

                case CompareType.Wins:
                    return x.Wins.CompareTo(y.Wins);
                
                default:

                    throw new ArgumentException("Invalid Compare Type");
            }
        }
    }
}
