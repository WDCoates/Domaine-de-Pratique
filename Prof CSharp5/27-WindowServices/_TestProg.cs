using System;

namespace QuoteServer
{
    public class _TestProg
    {
        public static void Main()
        {
            var qs = new QuoteServer(@".\MyQuotes.txt", 4444);
            qs.Start();
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
            qs.Stop();
        }
    }
}
