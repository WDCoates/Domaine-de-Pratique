using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._07_Operators_and_Casts
{
    public struct SimpleStruct
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    struct MVector
    {
        public double x, y, z;

        public MVector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public MVector(MVector rhs)
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }

        public static MVector operator + (MVector lhs, MVector rhs)
        {
            MVector res = new MVector(lhs);
            res.x += rhs.x;
            res.y += rhs.y;
            res.z += rhs.z;

            return res;
        }

        public static MVector operator * (MVector lhs, double rhs)
        {
            return new MVector(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs );
        }

        public static MVector operator *(double lhs, MVector rhs)
        {
            //return new MVector(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);  //First stab ok but better to do...
            return rhs * lhs;
        }

        public static double operator * (MVector lhs, MVector rhs)
        {
            return (lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z);
        }

        public static MVector operator - (MVector lhs, MVector rhs)
        {
            MVector res = new MVector(lhs);
            res.x -= rhs.x;
            res.y -= rhs.y;
            res.z -= rhs.z;

            return res;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }
    class OpOverloading
    {
        internal bool eTest(string name)
        {
            SimpleStruct sA = new SimpleStruct {Id = 0, Name = "Bob"};
            SimpleStruct sB = new SimpleStruct();
            if (name != null)
            {
                sB.Id = 1;
                sB.Name = name;
            }

            bool r1 = sA.Equals(sB);

            // r1 = (sA == sB); Need to write override for == for don't know how yet....

            return r1;
        }

    }
}
