using System;

using System.Threading;
using System.Threading.Tasks;

namespace ConsoleA1._10_Collections
{
    public class ProcessDocs
    {
        private DocsManager docManager;
        private static Task _t;
        
        public static void Start(DocsManager dm)
        {
            _t = Task.Factory.StartNew(new ProcessDocs(dm).Run);
            
        }
        public static void Stop()
        {
            if(_t.IsCompleted)
                _t.Dispose();
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
            var waits = 0;
            while (waits < 20)
            {
                if (docManager.AnyDocs)
                {
                    waits = 0;
                    Doc doc = docManager.GetDoc();
                    Console.WriteLine($"Document Title: {doc.Title}; by {doc.Auther}");
                }
                else
                {
                    Console.WriteLine($"Nothing to process...");
                }

                Thread.Sleep(new Random().Next(20));
                waits++;
            }
        }
    }
}
