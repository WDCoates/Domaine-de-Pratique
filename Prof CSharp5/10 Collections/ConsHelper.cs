using System;
using Cons = System.Console;

namespace ConsoleA1._10_Collections
{
    internal class ConsHelper
    {
        private static object syncOutput = new object();

        internal static void WriteLine(string message)
        {
            lock (syncOutput)
            {
                Cons.WriteLine(message);
            }
        }

        internal static void WriteLine(string message, string colour)
        {
            lock (syncOutput)
            {
                Cons.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), colour);
                Cons.WriteLine(message);
                Cons.ResetColor();
            }
        }
    }
}