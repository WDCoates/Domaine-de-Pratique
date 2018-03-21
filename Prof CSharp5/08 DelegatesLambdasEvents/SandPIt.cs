using System.Runtime.Remoting.Messaging;
using Cons = System.Console;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    delegate string Stringify();

    struct SandPit
    {
        private static string pTest;

        public static void Test()
        {
            int x = 4040;
            Stringify getTheString = new Stringify(x.ToString);
            Stringify getStringify2 = x.ToString;



            Cons.WriteLine($"This is what stringify does but you have to us it as a method ()...{getTheString()}...or {getStringify2()}");
            Cons.WriteLine($"Trying the invoke method ...{getTheString.Invoke()}");


            var msg = "Test";
            
            TestS.ChgTest(ref msg);

            pTest = msg;
        }
    }

    public static class TestS
    {
        public static void ChgTest(ref string test)
        {
            test += "...";
        }
    }
}
