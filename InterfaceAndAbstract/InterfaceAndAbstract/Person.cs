using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo
{
    abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public abstract double Taxes(double amt);

        public double CalcTelephoneBill(double amt)
        {
            return this.Taxes(amt) + amt;
        }
    }
}
