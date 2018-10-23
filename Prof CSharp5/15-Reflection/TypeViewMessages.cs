using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ConsoleA1._15_Reflection
{
    public static class TypeViewMessages
    {
        static StringBuilder OutoutText = new StringBuilder();

        public static void DispTypeView()
        {
            Type t = typeof(double);

            AnalyzeType(t);

            MessageBox.Show(OutoutText.ToString(), $"Analysis of type {t.Name}");
        }

        private static void AnalyzeType(Type t)
        {
            AddToOutput($"Type Name: {t.Name}");
            AddToOutput($"Full Name: {t.FullName}");
            AddToOutput($"Namespace: {t.Namespace}");

            Type tBase = t.BaseType;
            if (tBase != null) AddToOutput($"Base Type: {tBase.Name}");
            Type tU = t.UnderlyingSystemType;
            if (tU != null) AddToOutput($"Underlying System Type: {tU.Name}");

            AddToOutput($"\nPUBLIC MEMBERS:");
            MemberInfo[] memInfo = t.GetMembers();

            foreach (var mI in memInfo)
            {
                AddToOutput($"{mI.DeclaringType}  {mI.MemberType}  {mI.Name}" );
            }
        }

        private static void AddToOutput(string text)
        {
            OutoutText.Append("\n" + text);
        }
    }
}
