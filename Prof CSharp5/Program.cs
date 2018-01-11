#define Test
using System;
using System.Drawing;


namespace ConsoleA1
{
    /// <summary>
    /// Test Summary Comments
    /// </summary>
    /// <c>var a = b + c;</c>
    class Client
    {
        /// <param name="args"></param>
        /// <returns>void just does it.</returns>
        public static void Main(string[] args)
        {
        }
    }

    class SomeThing
    {
        public static readonly Color cColor;
        static SomeThing()
        {
            Start();
            cColor = Color.Black;
        }

        public static void Start()
        {
            return;
        }

        public SomeThing(int iStart)
        {
            if (iStart > 0)
            {
                Start();
            }

        }

        public void Stop()
        {
           
        }

    }

    class Test
    {

        public static int Main(string[] args)
        {

            Int32 Test = (Int32)Math.Floor(3.122);
            
            Console.WriteLine("Test %0.d", Test );

            #region one Region block
            string[] a = new string[4];
            #if  Test
            Console.WriteLine(a.ToString());   
            #endif

            Client.Main(a);

            SomeThing sT = new SomeThing(0);
            SomeThing.Start();
            sT.Stop();

            return 0;
            #endregion
        }
    }
}
