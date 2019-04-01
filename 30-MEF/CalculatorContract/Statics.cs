using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorContract
{
    public class Statics
    {
        public static void CalculatorLoop(ICalculator Calculator)
        {
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
