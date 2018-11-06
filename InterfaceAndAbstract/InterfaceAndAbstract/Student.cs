using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo
{
    class Student : Person
    {
        public override double Taxes(double amt)
        {
            return amt * 0.02;
        }
    }
}
