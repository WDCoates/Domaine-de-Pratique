using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._24_MaipulatingFiles
{
    public class DirsAndFiles
    {
        public static string Initialise()
        {
            string exists = "False";
            FileInfo fInfo = new FileInfo(@".\TestDC.Txt");
            if (!fInfo.Exists)
            {
               FileStream fStream = fInfo.Create();
               fStream.Close();
               fInfo.CreationTime = new System.DateTime(1900, 1, 1);
            }

            

            DirectoryInfo dInfo = new DirectoryInfo(fInfo?.DirectoryName ?? @".");
            exists = dInfo.Exists.ToString();

            return exists;
        }
    }
}
