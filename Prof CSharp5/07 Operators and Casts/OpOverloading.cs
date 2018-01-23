using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._07_Operators_and_Casts
{
    public struct SimpleStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    class OpOverloading
    {
        internal bool eTest(string name)
        {
            SimpleStruct sA = new SimpleStruct {Id = 0, Name = "Bob"};
            SimpleStruct sB = new SimpleStruct();
            if (name != null)
            {
                sB.Id = 1;
                sB.Name = name;
            }

            bool r1 = sA.Equals(sB);

            // r1 = (sA == sB); Need to write override for == for don't know how yet....

            return r1;
        }

    }
}
