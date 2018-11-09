using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public static List<Address> Book = new List<Address>();

        public Address(string st, string cit, string etat, string zip)
        {
            Street = st;
            City = cit;
            State = etat;
            ZipCode = zip;
            Book.Add(this);
        }

        public override string ToString()
        {
            return String.Format("{0} \n{1}, {2} {3}", Street, City, State, ZipCode);
        }
    }
}
