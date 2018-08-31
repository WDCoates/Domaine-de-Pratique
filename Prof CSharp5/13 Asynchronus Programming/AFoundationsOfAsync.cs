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

        static string Greeting(string name, int wait)
        {
            Thread.Sleep(wait);
            return $"Good {DateTime.Now.TimeOfDay} {name}!";
        }

        //To Make this Asunchronous
        static Task<string> GreetingAs(string name, int wait)
        {
            //return Task.Run<string>(() => { return Greeting(name); });  //The oldway....
            return Task.Run<string>(function: () => Greeting(name, wait));    //The modernway!
        }

  
        public static async void GetGreetingAs(string name)
        {
            
            _result = await GreetingAs(name, 3000);
            Console.WriteLine(_result);
        }

        //Continuation
        public static void CallerWithContinuation(string name)
        {
            Task<string> t1 = GreetingAs(name, 500);
            t1.ContinueWith(t =>
            {
                _result = t.Result;
                Console.WriteLine(_result);

            });
        }


    }
}
