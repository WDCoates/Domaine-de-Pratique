using System.ComponentModel.Composition;


namespace CalculatorContract
{
    [Export("CalculatorContract.Simple")]
    public class SimpleCon
    {
        public string Con1()
        {
            return "Contract One!";
        }
    }
}
