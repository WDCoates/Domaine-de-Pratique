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

        //Multi Calls Async
        public async static void MultiAsCalls(string n1, string n2)
        {
            string c1 = await GreetingAs(n1, 500);
            string c2 = await GreetingAs(n2, 100);

            Console.WriteLine($"This is c1:{c1}. and this is c2:{c2}");

            //With Combinators...
            Task<string> t1 = GreetingAs(n1, 10000);
            Task<string> t2 = GreetingAs(n2, 100);
            string[] re = await Task.WhenAll(t1, t2);

            Console.WriteLine($"This is t1:{t1.Result}. and this is t2:{t2.Result}");
        }

        //Converting the Asynchronus Pattern!!!!!
        private static Func<string, int, string> greetingInvoker = Greeting;

        static IAsyncResult BegingGreeting(string name, int wait, AsyncCallback callback, object state)
        {
            return greetingInvoker.BeginInvoke(name, wait, callback, state);
        }

        static string EndGreeting(IAsyncResult ar)
        {
            return greetingInvoker.EndInvoke(ar);
        }

        //Not Finsihed and not sure why I'm doing this.....
    }
}
