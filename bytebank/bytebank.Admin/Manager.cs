using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank.Employee
{
    internal class Manager : Employee
    {
        public Manager(string name, string registry) : base(name, registry)
        {
        }

        public override void GetBonus()
        {
            Salary = Salary + Salary * 0.3;
        }
    }
}
