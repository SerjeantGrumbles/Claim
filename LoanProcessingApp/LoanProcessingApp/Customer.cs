using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessingApp
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public string ID { get; private set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public Customer(string fname, string lname, int aege, string mail, double sal)
        {
            FirstName = fname;
            LastName = lname;
            Age = aege;
            Email = mail;
            Salary = sal;
            GenerateID();
        }

        private void GenerateID()
        {
            Random RNG = new Random();
            ID = FullName.Substring(0, 1) + RNG.Next(10, 100);
        }
    } 
}
