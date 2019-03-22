namespace CalculatorContract
{
    public interface IOperation
    {
        string Name { get; }
        int NumberOperands { get; }
    }
}
