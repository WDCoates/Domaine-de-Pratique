using System;
using System.Collections;
using WhatsNewAttributes;

[assembly: SupportsWhatsNew]

namespace MyVectors
{
    [LastModified("17 Oct 2018", "IEnumerable interface implemented so Vector can now be treated as a collection.")]
    [LastModified("10 Feb 2018", "Fic date when looked at.")]
    public class MyVector : IFormattable, IEnumerable
    {
        private double x, y, z;

        public MyVector(double x, double y, double z)
        {
           this.x = x;
           this.y = y;
           this.z = z;   
        }
        [LastModified("10 Feb 2018", ".")]
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        [LastModified("17 Oct 2018", "Added method ToString()")]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider == null) throw new ArgumentNullException(nameof(formatProvider));
            if (format == null)
            {
                return ToString();
            }

            return $"Format: {format}";
        }

    }
}
