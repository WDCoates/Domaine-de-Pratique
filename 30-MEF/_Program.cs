using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using CalculatorContract;


namespace _30_MEF
{
    public class _Program
    {
        [Import]
        public ICalculator Calculator { get; set;}
        public static void Main()
        {
            var p = new _Program();
            p.Run();
        }

        public void Run()
        {
            var catalog = new DirectoryCatalog(@"..\..\SimpleCalculator\Bin\Debug");
            var container = new CompositionContainer(catalog);

            try
            {
                container.ComposeParts(this);
            }
            catch (ChangeRejectedException cre)
            {
                Console.WriteLine(cre.Message);
            }

            Statics.CalculatorLoop(Calculator);

        }

        
    }
}
