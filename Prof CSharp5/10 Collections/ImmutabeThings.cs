using System.Collections.Generic;
using System.Collections.Immutable;     //Added through NuGet first
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Cons = System.Console;
using System;
using ConsoleA1._00_Common;

namespace ConsoleA1._10_Collections
{
    class Acc
    {
        internal string Name { get; set; }
        internal int Number { get; set; }
    }

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

            //Concurrent Collections: Thread safe. Pipes
            


        }
        private static async void StartPipeline()
        {
            var fName = new BlockingCollection<string>();
            var lines = new BlockingCollection<string>();
            var words = new ConcurrentDictionary<string, int>();
            var items = new BlockingCollection<Info>();
            var colItems = new BlockingCollection<Info>();

            Task s1 = PipelineStage.ReadFileNameAsync(@"../../..", fName);
            ConsHelper.WriteLine($"Started Stage 1");
            Task s2 = PipelineStage.LoadContentAsync(fName, lines);
            ConsHelper.WriteLine($"Started Stage 2");
            Task s3 = PipelineStage.ProcessContentAsync(lines, words);
            ConsHelper.WriteLine($"Started Stage 3");
            await Task.WhenAll(s1, s2, s3);
            ConsHelper.WriteLine("All stages 1,2,3 have completed");

        }
    }

    internal static class PipelineStage
    {
        internal static Task ReadFileNameAsync(string v, BlockingCollection<string> fName)
        {
            throw new NotImplementedException();
        }

        public static Task LoadContentAsync(BlockingCollection<string> fName, BlockingCollection<string> lines)
        {
            throw new NotImplementedException();
        }

        internal static Task ProcessContentAsync(BlockingCollection<string> lines, ConcurrentDictionary<string, int> words)
        {
            throw new NotImplementedException();
        }
    }
}
