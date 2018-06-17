using System.Collections.Generic;
using System.Collections.Immutable;     //Added through NuGet first
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Cons = System.Console;
using System;
using System.IO;
using System.Linq;
using ConsoleA1._00_Common;
using Task = System.Threading.Tasks.Task;

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
            StartPipeline();

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
        internal static Task ReadFileNameAsync(string path, BlockingCollection<string> fName)
        {
            return Task.Run(async () => {
                    foreach (string fileName in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories))
                    {
                        fName.Add(fileName);
                        ConsHelper.WriteLine($"Stage 1: Added {fileName}");
                    }

                    fName.CompleteAdding();
                }
            );
        }

        internal static Task LoadContentAsync(BlockingCollection<string> fName, BlockingCollection<string> lines)
        {
            return Task.Run(async () =>
            {
                foreach (var f in fName.GetConsumingEnumerable())
                {
                    using (FileStream stream = File.OpenRead(f))
                    {
                        var reader = new StreamReader(stream);
                        string line = null;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            lines.Add(line);
                            ConsHelper.WriteLine($"Stage 2: Added {line}");
                        }
                    }
                }

                lines.CompleteAdding();
            });
        }

        internal static Task ProcessContentAsync(BlockingCollection<string> lines, ConcurrentDictionary<string, int> words)
        {
            return Task.Run(() =>
            {
                foreach (var l in lines.GetConsumingEnumerable())
                {
                    string[] wrds = l.Split(' ', ';', '\t', '{', '}', '(', ')', ':', ',', '"');
                    foreach (var w in wrds.Where(w => !string.IsNullOrEmpty(w)))
                    {
                        words.AddOrIncrementValue(w);
                        ConsHelper.WriteLine($"Stage 3: Added {w}");
                    }
                }
            });
        }
    }

    internal static class ConcurrentDictionaryExtension
    {
        internal static void AddOrIncrementValue(this ConcurrentDictionary<string, int> dict, string key)
        {
            bool success = false;
            while (!success)
            {
                int value;
                if (dict.TryGetValue(key, out value))
                {
                    if (dict.TryUpdate(key, value + 1, value))
                    {
                        success = true;
                    }
                }
                else
                {
                    if (dict.TryAdd(key, 1))
                    {
                        success = true;
                    }
                }
            }
        }
    }

}
