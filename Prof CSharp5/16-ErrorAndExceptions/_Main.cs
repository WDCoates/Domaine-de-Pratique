using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._16_ErrorAndExceptions;

namespace ConsoleA1._16_ErrorAndExceptions
{
    class _Main
    {
        public static void Main()
        {
            Console.WriteLine($"Errors and Exceptions.");
            Console.WriteLine($"Simple Exception Handling.");
            while (true)
            {
                try
                {
                    string uIn;
                    Console.WriteLine($"Enter number between 0 and 5, return to exit.");
                    uIn = Console.ReadLine();
                    if (string.IsNullOrEmpty(uIn)) 
                        break;

                    int index = Convert.ToInt32(uIn);
                    if (index < 0 || index > 5)
                        throw new IndexOutOfRangeException("You have to be kidding me!");

                    Console.WriteLine($"You entered {index}, well done.");
                }                
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please: Enter a number between 0 and 5....");
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    Console.WriteLine("Thanks for playing. Be seeing you.");
                } 

                Console.WriteLine($"End of Try block");
            }

            SexyColdCall.Start();
            

            Console.WriteLine($"Press any key to exit.");
            Console.ReadKey();
        }

    }

    class MyClass
    {
        
    }
}
