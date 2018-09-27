using System.Linq.Expressions;
using System.Windows;
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
            dealer.NewCarInfo -= christine.NewCarIsHere;
            System.GC.Collect();

            //Just to stop the console disapearing...

            //Weak Class Listeners
            var wendy = new WeakConsumer("Wendy");
            WeakCarInfoEM.AddListener(dealer, wendy);
            dealer.NewCar("Willie Wonker Wanger");
            WeakCarInfoEM.RemoveListener(dealer, wendy);
            dealer.NewCar("Nothing Today");
            System.GC.Collect();

            //Generic WeakEvent
            var gCus = new Consumer("Gena");
            WeakEventManager<CarDealer, CarInfoEventsArgs>.AddHandler(dealer, "NewCarInfo", gCus.NewCarIsHere);

            dealer.NewCar("Genevieve");

            WeakEventManager<CarDealer, CarInfoEventsArgs>.RemoveHandler(dealer, "NewCarInfo", gCus.NewCarIsHere);
            dealer.NewCar("Renault");

            Cns.ReadKey();
        }
    }
}
