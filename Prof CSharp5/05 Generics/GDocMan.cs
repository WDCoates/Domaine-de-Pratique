using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleA1._05_Generics
{    
    internal class DocumentManager<TDocument> where TDocument : IDocument
    {

        private readonly Queue<TDocument> _docQueue = new Queue<TDocument>();
        

        public TDocument GetDoc()
        {
            TDocument doc = default(TDocument);
            lock (this)
            {
                doc = _docQueue.Dequeue();
            }
            return doc;
        }
        public void AddDoc(TDocument doc)
        {
            lock (this)
            {
                _docQueue.Enqueue(doc);
            }
        }

        public bool IsDocAvailable
        {
            get { return _docQueue.Count > 0; }
        }

        public void DisplayAllDocs()
        {
            foreach (var doc in _docQueue)
            {
                Console.WriteLine(((IDocument)doc).Title);
            }

            foreach (TDocument tDoc in _docQueue)
            {
                Console.WriteLine(tDoc.Title);
            }
        }

        //internal void AddDoc(Doc2 doc2)
        //{
        //    throw new NotImplementedException();
        //}
    }

    /// <summary>
    /// Used as lowest com de
    /// </summary>
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }

    internal class Document: IDocument
    {
        public Document() { }
        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Content { get; set; }
        public string Title { get; set; }
    }


    internal class Doc2 : IDocument
    {
        public Doc2() { }
        public Doc2(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Content { get; set; }
        public string Title { get; set; }

    }

    internal class BigDoc : Document
    {
        public string Author { get; set; }

        public BigDoc()
        {
        }

        public BigDoc(string title, string content) : base(title, content)
        { }

    }

    internal class SDemo<T>
    {
        public static int x;
    }

    internal class GDocMan
    {
        public static void Main()
        {
            Console.Write($"Someting Generic with TDocuments!");

            Document doc = new Document("Test", "Something longer I think!");
            var dm = new DocumentManager<Document>();
            dm.AddDoc(doc);
            dm.AddDoc(new Document ("Second T", "More content longer than title..."));
            var dm2 = new DocumentManager<Doc2>();
            dm2.AddDoc(new Doc2("Doc 2", "So What Am I doing wrong..."));
            var bDoc = new BigDoc
            {
                Author = "Me",
                Title = "Mine",
                Content = "No way this will work...."
            };

            dm.AddDoc(bDoc);

            var bDoc2 = new BigDoc("Test 9", "Hello!");
            dm.AddDoc((Document)bDoc2);

            dm.DisplayAllDocs();

            if (dm.IsDocAvailable)
            {
                Document d = dm.GetDoc();
                Console.WriteLine(d);
            }

            SDemo<string>.x = 2;
            SDemo<Test>.x = 2;

            Console.Write($"SDemo with string type {SDemo<string>.x}");
            Console.Write($"SDemo with Test type {SDemo<Test>.x}");

            Console.ReadKey();
        }
    }

}
