using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank.Client
{
    public class Holder
    {
        public string Name { get; set; }
        public string Registry { get; set; }
        public double Salary { get; set; }
        public Holder(string name, string registry)
        {
            Name = name;
            Registry = registry;
        }
    }
}
