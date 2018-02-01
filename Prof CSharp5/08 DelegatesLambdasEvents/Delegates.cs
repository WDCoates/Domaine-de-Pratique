using Con = System.Console;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    delegate string GetAString();

    public struct Delegates
    {
        public static void DemoDelegates()
        {
            int x = 40;
            GetAString fStringMethod = new GetAString(x.ToString);


            Con.WriteLine($"x String is {fStringMethod()}");
        }

    }
}
