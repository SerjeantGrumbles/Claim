using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = CreateNewCustomer();
            Console.WriteLine("New customer created:");
            Console.WriteLine("{0}: {1}", c1.FullName, c1.ID);
            LoanApproval(c1);
            Console.ReadKey();
        }

        static Customer CreateNewCustomer()
        {
            string fname, lname, email;
            int age = 0;
            double salary = 0;
            Console.WriteLine("Enter First Name:");
            fname = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            lname = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            try { age = Convert.ToInt32(Console.ReadLine()); }
            catch (FormatException ex) { Console.WriteLine("Invalid user input. Your age is now set to 0."); }
            Console.WriteLine("Enter Email:");
            email = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            try { salary = Convert.ToDouble(Console.ReadLine()); }
            catch (FormatException ex) { Console.WriteLine("Invalid user input.  Your salary is now set to $0.00");}
            return new Customer(fname, lname, age, email, salary);
        }

        static void LoanApproval(Customer c)
        {
            double amt = 0, interest = 0;
            try
            {
                Console.WriteLine("Enter loan amount:");
                amt = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter desired interest rate:");
                interest = Convert.ToDouble(Console.ReadLine());  // this isn't even used by the program!
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid user input.  I hate you.  Goodbye.");
                return;
            }
            if (amt > c.Salary * 3)
            {
                Console.WriteLine("Loan denied.  Loan must not exceed three times your annual salary.");
            }
            else if(amt > 60000)
            {
                Console.WriteLine("Loan denied.  Loan must not exceed $60,000.");
            }
            else if(c.Age < 18)
            {
                Console.WriteLine("Loan denied.  Customers under 18 years of age are ineligible.");
            }
            else
            {
                Console.WriteLine("Congratulations, your loan is approved for");
                Console.WriteLine("Customer Name: " + c.FullName);
                Console.WriteLine("Customer ID: " + c.ID);
                Console.WriteLine("Loan Amount: " + amt.ToString("C2"));
                Console.WriteLine("Date of Approval: " + DateTime.Now.ToLongDateString());
            }
        }
    }
}
