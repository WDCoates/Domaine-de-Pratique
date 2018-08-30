using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleA1._13_Asynchronus_Programming
{
    class AFoundationsOfAsync
    {
        public static string _result;

        static string Greeting(string name)
        {
            Thread.Sleep(3000);
            return $"Good {DateTime.Now.TimeOfDay} {name}.";
        }

        //To Make this Asunchronous
        static Task<string> GreetingAsync(string name)
        {
            //return Task.Run<string>(() => { return Greeting(name); });  //The oldway....
            return Task.Run<string>(function: () => Greeting(name));    //The modernway!
        }

        public static async void GetGreetingAsync(string name)
        {
            _result = await GreetingAsync(name);
            Console.WriteLine(_result);
        }
    }
}
