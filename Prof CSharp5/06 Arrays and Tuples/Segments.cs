using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._06_Arrays_and_Tuples
{
    class Segments
    {
        static internal int SumOfSegments(ArraySegment<int>[] segments)
        {
            int sum = 0;
            foreach (var seg in segments)
            {
                for (int i = 0; i < seg.Count; i++)
                {
                    sum += seg.Array[i + seg.Offset];
                }
            }

            return sum;
        }
    }
}
