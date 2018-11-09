using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public static List<Person> Book = new List<Person>();
        public Address _Address;

        public Person(string fname, string lname, long pnum)
        {
            FirstName = fname;
            LastName = lname;
            PhoneNumber = pnum;
            Book.Add(this);
        }

        public Person(string fname, string lname, long pnum, Address a)
        {
            FirstName = fname;
            LastName = lname;
            PhoneNumber = pnum;
            _Address = a;
            Book.Add(this);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}       {2:(###) ###-####}", FirstName, LastName, PhoneNumber);
        }

        public int CompareTo(Person other)
        {
            if (this.LastName.CompareTo(other.LastName) > 0) return 1;
            else if (this.LastName.CompareTo(other.LastName) < 0) return -1;
            else return 0;
        }
    }
}
