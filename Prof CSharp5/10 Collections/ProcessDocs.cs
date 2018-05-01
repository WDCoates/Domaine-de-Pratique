using System;

using System.Threading;
using System.Threading.Tasks;

namespace ConsoleA1._10_Collections
{
    public class ProcessDocs
    {
        private DocsManager docManager;
        public static void Start(DocsManager dm)
        {
            Task.Factory.StartNew(new ProcessDocs(dm).Run);
        }

        protected ProcessDocs(DocsManager dm)
        {
            ////if (dm == null)
            ////    throw new ArgumentNullException("dm");
            ////docManager = dm;

            docManager = dm ?? throw new ArgumentNullException("dm");
        }

        protected void Run()
        {
            while (true)
            {
                if (docManager.AnyDocs)
                {
                    Doc doc = docManager.GetDoc();
                    Console.WriteLine($"Document Title: {doc.Title}; by {doc.Auther}");
                }
                else
                {
                    Console.WriteLine($"Nothing to process...");
                }

                Thread.Sleep(new Random().Next(20));
            }
        }
    }
}
