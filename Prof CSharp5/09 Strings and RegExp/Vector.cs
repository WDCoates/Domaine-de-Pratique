using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleA1._07_Operators_and_Casts;

namespace ConsoleA1._09_Strings_and_RegExp
{
    struct FVector: IFormattable
    {
        public double x, y, z;
        public FVector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public string ToString(string format, IFormatProvider fProvider)
        {
            if (format == null)
            {
                return ToString();
            }

            switch (format.ToUpper())
            {
                case "N":
                    return $"|| " + Norm().ToString(CultureInfo.InvariantCulture) + " ||";
                case "V":
                case "VE":
                    return String.Format($"( {x:E}, {y:E}, {z:E} )");
                case "I":
                case "IJK":
                    StringBuilder sB = new StringBuilder(x.ToString(), 30);
                    sB.AppendFormat(" i + ").AppendFormat(y.ToString(CultureInfo.InvariantCulture));
                    sB.AppendFormat(" j + ").AppendFormat(z.ToString(CultureInfo.InvariantCulture));
                    sB.AppendFormat(" k ");
                    return sB.ToString();
                default:
                    return ToString();
            }
        }

        public override string ToString()
        {
            return $"( {x}, {y}, {z} )";
        }

        public double Norm()
        {
            return x * x + y * y + z * z;
        }

    }
}
