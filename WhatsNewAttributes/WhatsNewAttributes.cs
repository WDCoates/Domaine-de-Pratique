using System;

namespace WhatsNewAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class LastModifiedAttribute : Attribute
    {
        private readonly string _change;
        private readonly DateTime _dateModified;

        public LastModifiedAttribute(string dateModified, string change)
        {
            _dateModified = DateTime.Parse(dateModified);
            _change = change;
        }

        public DateTime DateModified => _dateModified;

        public string Change => _change;
    }


    [AttributeUsage(AttributeTargets.Assembly)]
    public class SupportsWhatsNewAttribute : Attribute
    {
    }
    public class WhatsNewAttributes
    {
    }
}
