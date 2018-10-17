using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum PersonCompareType
    {
        FirstName,
        LastName
    }
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Id { get; private set; }

        public Person()
        {

        }

        public Person(string name)
        {
            string[] split = name.Split(',');
            this.FirstName = split[0];
            this.LastName = split[1];
        }

        //So sorting can happen need to add IComparable to this class
        public int CompareTo(Person target)
        {
            try
            {
                if (target == null) return 1;

                int result = string.Compare((string)this.LastName, (string)target.LastName);
                if (result == 0)
                {
                    return string.Compare((string)this.FirstName, (string)target.FirstName);
                }

                return result;
            }
            catch (Exception)
            {
                return 1;
            }
            
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return base.Equals(other);
            return Equals(other as Person);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public bool Equals(Person other)
        {
            if (other == null)
                return base.Equals(other);

            return this.Id == other.Id && this.FirstName == other.FirstName && this.LastName == other.LastName;

        }

    }

    public class PersonComparer : IComparer<Person>
    {
        private PersonCompareType compType;

        public PersonComparer(PersonCompareType compType)
        {
            this.compType = compType;
        }

        public int Compare(Person x, Person y)
        {
            if (x == null && y == null) return 0;
            if (x == null ) return 1;
            if (y == null) return -1;

            switch (compType)
            {
                case PersonCompareType.FirstName:
                    return string.Compare(x.FirstName, y.FirstName);
                case PersonCompareType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                default:
                    throw new ArgumentException("Unexpected compare type");
            }
        }
    }

}
