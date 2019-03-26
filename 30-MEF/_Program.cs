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

            var operations = Calculator.GetOperations();
            var oprDir = new SortedList<string, IOperation>();

            foreach (var item in operations)
            {
                oprDir.Add(item.Name, item);
                Console.WriteLine($"Name: {item.Name}, number of operands: {item.NumberOperands}");
            }
            Console.WriteLine();

            string selectedOp = null;
            do
            {
                try
                {
                    Console.Write($"Operation? ");
                    selectedOp = Console.ReadLine();
                    if (selectedOp != null && !oprDir.ContainsKey(selectedOp))
                        continue;
                    var operation = oprDir[selectedOp];
                    double[] operands = new double[operation.NumberOperands];

                    for (int i = 0; i < operation.NumberOperands; i++)
                    {
                        Console.Write($"\t operand {i + 1}? ");
                        string selectedOperand = Console.ReadLine();
                        operands[i] = double.Parse(selectedOperand);
                    }

                    Console.WriteLine($"Calling Calculater.....");
                    double res = Calculator.Operate(operation, operands);
                    Console.WriteLine($"Result: {res}");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Error: {fe.Message}");
                }
            } while (selectedOp.ToLower() != "x");

        }
    }
}
