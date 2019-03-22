using CalculatorContract;

namespace SimpleCalculator
{
    public class Operation : IOperation
    {
        public string Name { get; internal set; }
        public int NumberOperands { get; internal set; }
    }
}
