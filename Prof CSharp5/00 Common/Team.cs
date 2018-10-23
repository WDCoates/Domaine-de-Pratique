using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._00_Common
{
    class Team
    {
        public string Name { get; private set; }
        public IEnumerable<int> Years { get; private set; }
        public Team(string name, params int[] years)
        {
            Name = name;
            Years = new List<int>(years);
        }
    }
}
