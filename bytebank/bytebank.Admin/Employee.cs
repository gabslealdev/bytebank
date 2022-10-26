using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank.Employee
{
    public class Employee
    {
        public string Name { get; set; }
        public string Registry { get; set; }
        public double Salary { get; set; }
        public int Level { get; set; } 

        public Employee(string name, string registry)
        {
            Name = name;
            Registry = registry;
        }

        public virtual void GetBonus()
        {

        }

    }
}
