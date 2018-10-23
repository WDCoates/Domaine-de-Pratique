using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WhatsNewAttributes;

namespace ConsoleA1._15_Reflection
{
    public static class LookupWhatsNew
    {
        private static readonly StringBuilder OutputText = new StringBuilder(1000);
        private static DateTime backDateTo = new DateTime(2018, 1, 1);

        public static void LookWhatsNew()
        {
            Assembly theAss = Assembly.Load("MyVectors");
            Attribute supportsAttribute = Attribute.GetCustomAttribute(theAss, typeof(SupportsWhatsNewAttribute));
            
            var name = theAss.FullName;
            AddToMessage($"Assembly: {name}");

            if (supportsAttribute == null)
            {
                AddToMessage($"This assembly does not support the WhatsNew Assembly!");
                return;
            }
            else
            {
                AddToMessage("Defined Type:");
            }

            foreach (var type in theAss.GetTypes())
                DisplayTypeInfo(type);

            MessageBox.Show(OutputText.ToString(), $"Whats\'s New Since {backDateTo}");
            Console.ReadLine();

        }

        private static void DisplayTypeInfo(Type type)
        {
            if (type.IsClass)
            {
                AddToMessage("\nclass " + type.Name);
                Attribute[] att = Attribute.GetCustomAttributes(type);

                if (att.Length == 0)
                {
                    AddToMessage("No Changes to this class\n");
                }
                else
                {
                    foreach (var atr in att)
                    {
                        WriteAttributeInto(atr);
                    }

                }
            }
        }

        private static void WriteAttributeInto(Attribute atr)
        {
            LastModifiedAttribute lastModifiedAttribute = atr as LastModifiedAttribute;

            if (lastModifiedAttribute != null)
            {
                DateTime modifedDate = lastModifiedAttribute.DateModified;

                if (modifedDate >= backDateTo)
                {
                    AddToMessage($" Modified: {lastModifiedAttribute}" );
                    AddToMessage($"  {lastModifiedAttribute.Change}");
                }

            }
        }


        private static void AddToMessage(string message)
        {
            OutputText.Append("\n" + message);
        }
    }
}
