using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConsoleA1._21_Tasks_Threads_Synchronization
{
    internal static class DataFlowStuff
    {
        internal static BufferBlock<string> bBlock = new BufferBlock<string>();

        internal static void Producer()
        {
            bool exit = false;
            while (!exit)
            {
                string inPut = Console.ReadLine();
                if (string.Compare(inPut, "exit", ignoreCase: true) == 0)
                {
                    exit = true;
                }
                else
                {
                    bBlock.Post(inPut);
                }
            }
        }

        internal static async void Consumer()
        {
            while (true)
            {
                string bBlockData = await bBlock.ReceiveAsync();
                Console.Write($"DataFrom bBlck: {bBlockData}");
            }
        }

        //Begin
        //Code for connecting blocks
        //
        internal static IEnumerable<string> GetWords(IEnumerable<string> lines)
        {
            foreach (var l in lines)
            {
                string[] words = l.Split(' ', ';', '(', ')', '{', '}', '.', ',');
                foreach (var w in words)
                {
                    if (!string.IsNullOrEmpty(w))
                    {
                        yield return w;
                    }
                }
            }
        }

        internal static IEnumerable<string> LoadLines(IEnumerable<string> fNames)
        {
            foreach (var fN in fNames)
            {
                using (FileStream fStr = File.OpenRead(fN))
                {
                    var sReader = new StreamReader(fStr);
                    string line = null;
                    while ((line = sReader.ReadLine()) != null)
                    {
                        Console.WriteLine($"Loading lines {line}");

                        yield return line;
                    }
                }
            }
        }

        internal static IEnumerable<string> GetFileNames(string path)
        {
            foreach (var fName in Directory.EnumerateFiles(path, "*.cs"))
            {
                yield return fName;         //returns each file name or fName one at a time with the yield statement....
            }
        }

        internal static ITargetBlock<string> SetupPipeline()
        {
            var fNamePath = new TransformBlock<string, IEnumerable<string>>(path => GetFileNames(path));

            var lines = new TransformBlock<IEnumerable<string>, IEnumerable<string>>(fNames => LoadLines(fNames));

            var words = new TransformBlock<IEnumerable<string>, IEnumerable<string>>(lines2 => GetWords(lines2));

            //Action block
            var display = new ActionBlock<IEnumerable<string>>(coll =>
            {
                foreach (var s in coll)
                {
                    Console.WriteLine($"{s}");
                }
            });


            //Connect the blocks....
            fNamePath.LinkTo(lines);
            lines.LinkTo(words);
            words.LinkTo(display);

            return fNamePath;
        }

        //
        //Code for connecting blocks
        //End
    }
}
