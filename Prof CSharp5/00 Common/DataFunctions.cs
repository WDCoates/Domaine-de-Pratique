using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleA1._00_Common
{
    public static class DataFunctions
    {
        public static IEnumerable<string> FillData(int size)
        {
            var data = new List<string>(size);
            var r = new Random();
            for(int i = 0; i < size; i++)
            {
                data.Add(GetString(r));
            }

            return data;
        }

        private static string GetString(Random r)
        {
            var sb = new StringBuilder(6);
            for (int i = 0; i < 6; i++)
            {
                sb.Append((char) (r.Next(26) + 97));
            }

            return sb.ToString();
        }
    }
}
