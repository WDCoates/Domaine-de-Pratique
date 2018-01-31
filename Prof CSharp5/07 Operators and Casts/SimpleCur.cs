using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._07_Operators_and_Casts
{
    struct Cur
    {
        public uint Dollars;
        public ushort Cents;

        public Cur(uint dollars, ushort  cents)
        {
            this.Dollars = dollars;
            this.Cents = cents;
        }

        public override string ToString()
        {
            //return string.Format("${0}.{1,-2:00}", Dollars, Cents);
            return $"${Dollars}.{Cents,-2:00}";
        }

        public static implicit operator float(Cur value)
        {
            return value.Dollars + (value.Cents / 100.0f);
        }

        public static explicit operator Cur(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                //ushort cents = (ushort) ((value - dollars) * 100); using ushort gives a rounding error Microsoft has better ones now!
                ushort cents = Convert.ToUInt16((value - dollars) * 100);
                return new Cur(dollars, cents);
            }
        }

        public static implicit operator Cur(uint value)
        {
            checked
            {
                return new Cur(value/100u, (ushort) (value%100));   //Do not do this!!!!!
            }
        }
    }
    class SimpleCur
    {
        private float _wage;
        private string _name;


        public SimpleCur (string name, Cur wage)
        {
            _name = name;
            _wage = wage;
        }

        public string Name
        {
            get => _name;
            set => _name = Name;
        }
        public float Wage
        {
            get => _wage;
            set => _wage = Wage;
        }
    }

    class MoreSimpleCur : SimpleCur
    {
        public MoreSimpleCur (SimpleCur sCur) : base(sCur.Name, (Cur)sCur.Wage)
        {
            
        }
    }
}
