using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleA1._00_Common
{
    class DicEmployee
    {
        private readonly EmployeeId id;
        private string name;
        public decimal Salary { get; private set; }
        
        public DicEmployee(EmployeeId id, string name, decimal salary)
        {
            this.name = name;
            this.id = id;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"Employee ID is: {name}, {id.ToString()}, on {Salary:C}";
        }

        public static bool CompareSalary(Employee eL, Employee eR)
        {
            return eL.Salary < eR.Salary;
        }
    }
}
