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

            //Car Dealer and Delgate Events
            var dealer = new CarDealer();

            //New customer
            var michelle = new Consumer("Michelle");
            dealer.NewCarInfo += michelle.NewCarIsHere;

            dealer.NewCar("Lotus");

            var christine = new Consumer("Chrissie");
            dealer.NewCarInfo += christine.NewCarIsHere;

            dealer.NewCar("Mini");
            
            dealer.NewCarInfo -= michelle.NewCarIsHere;
            dealer.NewCar("BMW 325i");
            //Just to stop the console disapearing...
            Cns.ReadKey();
        }
    }
}
