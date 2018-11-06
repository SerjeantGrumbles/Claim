using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Employee e1 = new Employee();                     
            Person p1 = new Student();
            Person p2 = new Employee();
                     
            s1.FirstName = "Conrad";
            s1.LastName = "Arthur";
            e1.FirstName = "Sahara";
            e1.LastName = "Datta";
            p1.FirstName = "Sierra";
            p1.LastName = "Gossett";
            p2.FirstName = "Praneeth";
            p2.LastName = "Medari";
            Console.WriteLine("{0} {1}", s1.FirstName, s1.LastName);
            Console.WriteLine(s1.CalcTelephoneBill(120.5).ToString("C2"));
            Console.WriteLine("{0} {1}", e1.FirstName, e1.LastName);
            Console.WriteLine(e1.CalcTelephoneBill(120.5).ToString("C2"));
            Console.WriteLine("{0} {1}", p1.FirstName, p1.LastName);
            Console.WriteLine(p1.CalcTelephoneBill(120.5).ToString("C2"));
            Console.WriteLine("{0} {1}", p2.FirstName, p2.LastName);
            Console.WriteLine(p2.CalcTelephoneBill(120.5).ToString("C2"));

            Console.ReadKey();
        }
    }
}
