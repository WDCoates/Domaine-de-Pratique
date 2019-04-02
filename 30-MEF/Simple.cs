using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using CalculatorContract;

namespace _30_MEF
{
    public class Simple
    {
        [Import("CalculatorContract.Simple")]
        public static dynamic SimpleCon { get; set; }

        public static void Main()
        {
            dynamic var = SimpleCon.Con1();
        }

    }
}
