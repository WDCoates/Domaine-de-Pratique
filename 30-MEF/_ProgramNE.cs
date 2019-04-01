using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using CalculatorContract;

namespace _30_MEF
{
    public class _ProgramNE
    {
        public ICalculator Calculator { get; set;}

        public static void Main()
        {
            var pNE = new _ProgramNE();
            pNE.Run();
        }

        public void Run()
        {
            var conventions = new RegistrationBuilder();
            conventions.ForTypesDerivedFrom<ICalculator>().Export<ICalculator>();
            conventions.ForType<_ProgramNE>().ImportProperty<ICalculator>(p => p.Calculator);

            var catalog = new DirectoryCatalog(@"..\..\SimpleCalculator\Bin\Debug", conventions);

            using (CompositionService cS = catalog.CreateCompositionService())
            {
                cS.SatisfyImportsOnce(this, conventions);
            }

            Statics.CalculatorLoop(Calculator);
            
        }
    }
}
