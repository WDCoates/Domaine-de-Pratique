using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._00_Common;

namespace ConsoleA1._10_Collections
{
    public class FindCountry
    {
        private string country;
        public FindCountry(string country)
        {
            this.country = country;
        }

        public bool FindCountryPredicate(Racer r)
        {
            Contract.Requires<ArgumentNullException>(r != null);

            return r.Country == country;
        }
    }
}
