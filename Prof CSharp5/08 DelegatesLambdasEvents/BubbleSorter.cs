using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._08_DelegatesLambdasEvents
{
    class BubbleSorter
    {
        static public void Sort<T>(IList<T> sortList, Func<T, T, bool> comp)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortList.Count - 1; i++)
                {
                    if (comp(sortList[i + 1], sortList[i]))
                    {
                        T temp = sortList[i];
                        sortList[i] = sortList[i + 1];
                        sortList[i + 1] = temp;
                        swapped = true;
                    }
                }

            } while (swapped);
        }
    }
}
