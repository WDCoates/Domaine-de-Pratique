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
                
            ImArray1 = imArrayLoader.Add("One").Add("Two").Add("Three");
            Cons.WriteLine($"{ImArray1.ToString()}");

            List<Acc> accounts = new List<Acc>() { new Acc() {Name = "Ann", Number = 1}, new Acc() {Name = "Beth", Number = 2}, new Acc() {Name = "Cath", Number = 1000003}, new Acc() {Name = "Dee", Number = 1000013} };

            ImmutableArray<Acc> iaAcc = accounts.ToImmutableArray();
            ImmutableList<Acc> ilAcc = accounts.ToImmutableList();

            //Remove account under 1000000
            ImmutableList<Acc>.Builder ilBuilder = ilAcc.ToBuilder();
            for (int i = 0; i < ilBuilder.Count; i++)
            {
                Acc a = ilBuilder[i];
                if (a.Number < 1000000)
                {
                    ilBuilder.Remove(a);
                }
            }

            ImmutableList<Acc> NewAccs = ilBuilder.ToImmutable();
            foreach (var nAcc in NewAccs)
            {
                Cons.WriteLine($"New Account: {nAcc.Name}");
            }
        }
    }

    class Acc
    {
        internal string Name { get; set; }
        internal int Number { get; set; }
    }
}
