using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._15_Reflection
{
    class FieldNames
    {
        [FieldName("SSNumber")]
        public string SSNumber { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class FieldNameAttribute : Attribute
    {
        private string name;

        public FieldNameAttribute(string name)
        {
            this.name = name;
        }
    }
}
