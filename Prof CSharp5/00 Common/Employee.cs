using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._00_Common
{
    class Employee
    {
        public Int32 ID { get; private set; }
        public decimal Salary { get; private set; }
        public Employee(Int32 id, decimal salary)
        {
            this.ID = id;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"Employee ID is: {ID}";
        }

        public static bool CompareSalary(Employee eL, Employee eR)
        {
            return eL.Salary < eR.Salary;
        }
    }
}
