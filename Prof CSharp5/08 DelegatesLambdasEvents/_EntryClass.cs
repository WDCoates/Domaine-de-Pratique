using Cns = System.Console;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    class _EntryClass
    {
        public static void Main()
        {
            Cns.WriteLine("Chapter 08!");

            Delegates.DemoDelegates();

            LambdaExpressions.MidL();
            Cns.WriteLine(
                $"{LambdaExpressions.StringToUpper("Test all goes to upper through one Parm Lambda function")}");
            Cns.WriteLine($"{LambdaExpressions.twoToUpper("two Parm Lambda function ()")}");

            LambdaExpressions.lambdaExamples();

            SandPit.Test();

            //Just to stop the console disapearing...
            Cns.ReadKey();
        }
    }
}
