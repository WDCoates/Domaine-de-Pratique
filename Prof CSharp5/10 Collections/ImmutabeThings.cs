using System.Collections.Immutable;     //Added through NuGet first
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Cons = System.Console;

namespace ConsoleA1._10_Collections
{
    public static class ImmutabeThings
    {
        public static ImmutableArray<string> ImArray1;

        public static void ImmutableTing1()
        {
            ImmutableArray<string> imArrayLoader = ImmutableArray.Create<string>();
                
            ImArray1 = imArrayLoader.Add("One");
            Cons.WriteLine($"{ImArray1.ToString()}");


        }
    }
}
