using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleA1._13_Asynchronus_Programming
{
    class AFoundationsOfAsync
    {
        public static string _result;
        private static CancellationTokenSource _cts;

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

        //Converting the Asynchronus Pattern Old style coding not task based!!!!!
        static Func<string, int, string> greetingInvoker = Greeting;

        private static IAsyncResult BegingGreeting(string name, int wait, AsyncCallback callback, object state)
        {
            return greetingInvoker.BeginInvoke(name, wait, callback, state);
        }

        public static string EndGreeting(IAsyncResult ar)
        {
            return greetingInvoker.EndInvoke(ar);
        }

        public static async void ConvAsyncPattern()
        {
            string s = await Task<string>.Factory.FromAsync<string>(BegingGreeting, EndGreeting, "Angela", null);
            Console.WriteLine(s);
        }

        private static IAsyncResult BegingGreeting(string name, AsyncCallback arg2, object arg3)
        {
            return BegingGreeting(name, 1000, arg2, arg3);
        }
        //Not sure why I had to have two BegingGreeting methods here!


        //Error Handling!
        static async Task ThrowUpAfter(int ms, string error)
        {
            await Task.Delay(ms);
            throw new Exception(error);
        }

        public static void DontHandle()
        {
            try
            {
                ThrowUpAfter(4000, "First Throw Up!"); //Won't be caught as in Try Catch Block because try catch has fnished...
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async void CanHandle()
        {
            try
            {
                await ThrowUpAfter(4000, "Second Throw Up!"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                await ThrowUpAfter(4000, "1st M4 Throw Up!"); 
                await ThrowUpAfter(1000, "2nd M1 Throw Up!"); //This is never got to becase the first lands in the catch block.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Task t1 = ThrowUpAfter(4000, "T1 M4 Throw Up!");
                Task t2 = ThrowUpAfter(1000, "T2 M4 Throw Up!");
                await Task.WhenAll(t1, t2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Handled {0}", ex.Message);
            }

            //Aggregate Exception Information
            Task tRes = null;
            try
            {
                Task t1 = ThrowUpAfter(4000, "T1 M4 Throw Up!");
                Task t2 = ThrowUpAfter(1000, "T2 M4 Throw Up!");
                await (tRes = Task.WhenAll(t1, t2));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Handle all exceptions. {0}", ex.GetHashCode());
                foreach (var ie in tRes.Exception.InnerExceptions)
                {
                    Console.WriteLine("Inner exception {0}", ie.Message);
                }
                
            }

            Task et1 = null;
            Task et2 = null;
            Task r;
            try
            {
                et1 = ThrowUpAfter(4000, "T1 M4 Throw Up!");
                et2 = ThrowUpAfter(1000, "T2 M4 Throw Up!");
                r = await Task.WhenAny(et1, et2);
                if (r.IsFaulted)
                {
                    Console.WriteLine("? WTF {0}", r.Exception?.InnerException);
                }
            }
            catch (Exception)
            {
                if (et1 != null)
                {
                    if (_cts != null) _cts.Cancel();
                    Console.WriteLine("Handled {0}", et1.Exception?.Message);
                }
                if (et2 != null) Console.WriteLine("Handled {0}", et2.Exception?.Message);
            }

            //Cancellation
            _cts = new CancellationTokenSource();

            et1 = Task.Run(() =>
                {
                    for (var i = 0; i < 100000; i++)
                    {
                        if (_cts.IsCancellationRequested)
                        {
                            Console.WriteLine($"Get me out of here!!!!!!!");
                            _cts.Token.ThrowIfCancellationRequested();
                        }
                        else
                        {
                            Task.Delay(10000);
                        }
                    }

                    Console.WriteLine($"No Cancellation");
                }, _cts.Token                                   //requires methods that take Cancellation Tokens!
            );

            et2 = Task.Delay(2000);

            r = await Task.WhenAny(et1, et2);
            if (r.IsCompleted)
            {
                _cts.Cancel();
            }

        }
    }
}
