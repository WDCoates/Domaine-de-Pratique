using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ConsoleA1._15_Reflection
{
    public static class LookupWhatsNew
    {
        private static readonly StringBuilder OutoutText = new StringBuilder(1000);
        private static DateTime backDateTo = new DateTime(2018, 1, 1);

        public static void LookWhatsNew()
        {
            Assembly theAss = Assembly.Load("MyVectors");
        }
    }
}
