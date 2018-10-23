using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._14_Memory_and_Pointers
{
    public class SelfDestructor: IDisposable
    {
        public SelfDestructor()
        {
            Console.WriteLine(@"Here we go!");
        }

        public void Up()
        {
            Console.WriteLine(@"Up!");
        }

        public void Dispose()
        {
            Console.WriteLine(@"Is this better now!");
        }

        ~SelfDestructor()
        {
            Console.WriteLine(@"And I'm Gone....");
        }

    }
}
