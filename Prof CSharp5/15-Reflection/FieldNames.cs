using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._15_Reflection
{
    class FieldNames
    {
        [FieldName("SSNumber", Comment="This is red!")]
        public string SSNumber { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class FieldNameAttribute : Attribute
    {
        private string Name { get; }

        public string Comment { set; get; }

        public FieldNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
