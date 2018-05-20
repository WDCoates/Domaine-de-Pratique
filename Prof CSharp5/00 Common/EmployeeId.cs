using System;
using System.Diagnostics.Contracts;

namespace ConsoleA1._00_Common
{
    public struct EmployeeId : IEquatable<EmployeeId>
    {
        private readonly char prefix;
        private readonly int number;
        
        
        public EmployeeId(string id)
        {
            //Contract.Requires<ArgumentNullException>(id != null);     //-- Not in VS 2017 !
            
            prefix = (id.ToUpper())[0];
            int numLength = id.Length - 1;
            try
            {
                number = int.Parse(id.Substring(1, numLength > 6 ? 6 : numLength));
            }
            catch (FormatException fE)
            {
                throw new EmployeeIdException("Invalid EmployeeId format!");
            }
        }

        public override string ToString()
        {
            return prefix.ToString() + $"{this.number, 6:000000}";
        }

        public override int GetHashCode()
        {
            return (number ^ number << 16) * 0x15051505;
        }

        public bool Equals(EmployeeId other)
        {
            if (other == null) return false;
            return (prefix == other.prefix && number == other.number);
        }

        public override bool Equals(Object obj)
        {
            return Equals((EmployeeId) obj);
        }

        public static bool operator ==(EmployeeId left, EmployeeId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EmployeeId left, EmployeeId right)
        {
            return !(left == right);
        }
    }
    
    public class EmployeeIdException : Exception
    {
        public EmployeeIdException (string message) : base(message) {}
    }
}
