using System;
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
    public class PDoc : Doc
    {
        public byte Priority { get; private set; }
        public PDoc(string title, string auther, byte priority) : base(title, auther)
        {
            this.Priority = priority;
        }
    }

    public class PDocManager
    {
        private readonly LinkedList<PDoc> pDocList;
        private readonly List<LinkedListNode<PDoc>> pNodes;

        public PDocManager()
        {
            pDocList = new LinkedList<PDoc>();
            pNodes = new List<LinkedListNode<PDoc>>(10);
            for (var n=0; n < 10; n++)
            {
                pNodes.Add(new LinkedListNode<PDoc>(null));
            }
        }

        public void AddPDoc(PDoc d)
        {
            if (d == null) throw new ArgumentException("d");
            AddDocToPriorityNode(d, d.Priority);
        }

        private void AddDocToPriorityNode(PDoc pDoc, int priority)
        {
            if (priority > 9 || priority < 0)
                throw new ArgumentException("Priority must be between 0 and 9 inclusive.");

            if (pNodes[priority].Value == null)
            {
                --priority;
                if (priority >= 0)
                {
                    //Check for the next lower priority
                    AddDocToPriorityNode(pDoc, priority);
                }
                else
                {
                    pDocList.AddLast(pDoc);
                    pNodes[pDoc.Priority] = pDocList.Last;
                }
                return;
            }
            else
            {
                LinkedListNode<PDoc> pNode = pNodes[priority];
                if (priority == pDoc.Priority)
                {
                    pDocList.AddAfter(pNode, pDoc);
                    pNodes[pDoc.Priority] = pNode.Next;
                }
                else
                {
                    LinkedListNode<PDoc> firstPNode = pNode;

                    while (firstPNode.Previous != null && firstPNode.Previous.Value.Priority == pNode.Value.Priority)
                    {
                        firstPNode = pNode.Previous;
                        pNode = firstPNode;
                    }

                    pDocList.AddBefore(firstPNode, pDoc);

                    pNodes[pDoc.Priority] = firstPNode.Previous;
                }
            }
        }

        public void DisplayAllNodes()
        {
            foreach (var pDoc in pDocList)
            {
                Console.WriteLine($"Priority: {pDoc.Priority}, title {pDoc.Title}");
            }
        }

        public PDoc GetPDoc()
        {
            PDoc pDoc = pDocList.First.Value;
            pDocList.RemoveFirst();
            return pDoc;
        }

    }
}
