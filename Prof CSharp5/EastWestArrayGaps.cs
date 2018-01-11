using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AluGrid
{
    class ArrayPro
    {
        public static void Main(string[] args)
        {
            string ModArray = "033333333";
            int Rows = 3;
            int Cols = 3;

            int[,] arrayGaps = new int[Rows, Cols];

            //Initial Processing for first Col
            int i = 0;
            do
            {
                if (ModArray.Substring(i, 1) == "0")
                {
                    arrayGaps[0, i] = 0;
                }
                else
                {
                    arrayGaps[0, i] = 1;
                }
            } while (++i < Cols);

            //Processing for Second Col onwards
            for (int r = 1; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (ModArray.Substring(i++, 1) == "0")
                    {
                        arrayGaps[r, c] = 0;
                    }
                    else
                    {
                        if (arrayGaps[r - 1, c] == 0)
                        {
                            arrayGaps[r, c] = 1;
                        }
                        else
                        {
                            arrayGaps[r - 1, c] = 0;
                            arrayGaps[r, c] = 0;
                        };
                    }

                }
            }

            Console.Write(arrayGaps.Cast<int>().Sum());

            int[] arr = new int[] { 1, 2, 3 };
            int t = arr.Sum();
        }
    }
}