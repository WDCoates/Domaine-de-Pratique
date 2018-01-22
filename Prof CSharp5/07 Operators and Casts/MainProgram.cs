using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._07_Operators_and_Casts
{
    struct Items
    {
        public string Descp;
        public int AppPrice;
    }
    class MainProgram
    {
        public static void Main()
        {
            //Type Cons
            long val = 300000000000;
            try {
                int i = checked((int)val);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            ushort c = 43;
            char sym = (char)c;
            Console.WriteLine(sym);

            double[] Prices = { 10.90, 20.25, 15.33, 34.99 };

            Items items;
            items.Descp = "Red Bottle";
            items.AppPrice = (int)(Prices.Average());


            try
            {
                int? a = null;
                int b = (int)a;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            Boolean res = BoxUnBox.Box();

        }
    }
}
