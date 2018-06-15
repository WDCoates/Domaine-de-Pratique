using System;

namespace ConsoleA1._00_Common
{
    internal class Info
    {
        public string Word { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return String.Format("{0} times: {1}", Count, Word);
        }

    }
}