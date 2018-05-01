using System.Collections.Generic;


namespace ConsoleA1._10_Collections
{
    public class Doc
    {
        public string Title { get; private set; }
        public string Auther { get; private set; }

        public Doc(string title, string auther)
        {
            this.Auther = auther;
            this.Title = title;
        }
    }

    public class DocsManager
    {
        private readonly Queue<Doc> docQueue = new Queue<Doc>();

        public bool AddDoc(Doc doc)
        {
            lock (this)
            {
                docQueue.Enqueue(doc);
            }
            return true;
        }

        public Doc GetDoc()
        {
            Doc doc = null;
            lock (this)
            {
                doc = docQueue.Dequeue();
            }

            return doc;
        }

        public bool AnyDocs
        {
            get => docQueue.Count > 0;
        }
    }
}
