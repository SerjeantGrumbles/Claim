using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add some people from the start
            Person girlNum = new Person("Sierra", "Gossett", 3175294962); // I don't know her address
            CreateEntry("John", "Doe", 6366435698, "114 Market St", "St Louis", "MO", "63403");
            CreateEntry("John E", "Doe", 8475390126, "324 Main St", "St Charles", "MO","63303");
            CreateEntry("Conrad", "Arthur", 3174574982, "8532 Wakefield Ct.", "Indianapolis", "IN", "46256");
            CreateEntry("Jane", "Doe", 3145556969, "114 Market St", "St Louis", "MO", "63403");
            CreateEntry("John Michael West", "Doe", 5628592375, "574 Pole ave", "St. Peters", "MO", "63333");
            Console.WriteLine("***************** PHONE BOOK *********************");
            Console.WriteLine("**************************************************\n");
            Console.WriteLine("                 ,==.------ -.                    ");
            Console.WriteLine("                 (    )====  \\                      ");
            Console.WriteLine("                 ||  |[][][] |");
            Console.WriteLine("              ,8 ||  |[][][] |");
            Console.WriteLine("               8 ||  |[][][] |");
            Console.WriteLine("               8 (    )O O O /");
            Console.WriteLine("               '88`=='------ - '\n");
            //               
            //  
            // 
            //
            //
            //
            // hjw
            DisplayMainMenu();
            //Console.ReadKey();
        }

        static void CreateEntry(string fname, string lname, long pnum, string st, string cit, string etat, string zip)
        {
            Console.WriteLine();
            Person ppl;
            if (Address.Book != null)
            {
                foreach (Address a in Address.Book)
                {
                    // if it's an existing address
                    if (a.Street == st && a.City == cit && a.State == etat && a.ZipCode == zip)
                    {
                        ppl = new Person(fname, lname, pnum, a);
                        return;
                    }
                }
            }           
            // if it's a new a address
            Address add = new Address(st, cit, etat, zip);
            ppl = new Person(fname, lname, pnum, add);
        }

        static void SearchByFName(string fname)
        {
            Console.WriteLine();
            bool found = false;
            foreach (Person p in Person.Book)
            {
                    if (p.FirstName.Contains(fname))
                    {
                        Console.WriteLine(p.ToString());
                        try
                        {
                            Console.WriteLine(p._Address.ToString() + "\n");
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine();
                        }
                        finally
                        {
                            found = true;
                        }                                          
                    }                 
            }
            if (!found)
            {
                Console.WriteLine("No entries found matching your query.\n");
            }
        }

        static void SearchByLName(string lname)
        {
            Console.WriteLine();
            bool found = false;
            foreach (Person p in Person.Book)
            {
                if (p.LastName.Contains(lname))
                {
                    Console.WriteLine(p.ToString());                    
                    try
                    {
                        Console.WriteLine(p._Address.ToString() + "\n");
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine();
                    }
                    finally
                    {
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("No entries found matching your query.\n");
            }
        }

        static void SearchByCityState(string cSt)
        {
            Console.WriteLine();
            bool found = false;
            foreach (Person p in Person.Book)
            {
                if (p._Address != null) {
                    string cityState = p._Address.City + ", " + p._Address.State;
                    if (cityState.Contains(cSt))
                    {
                        Console.WriteLine(p.ToString());
                        Console.WriteLine(p._Address.ToString() + "\n");
                        found = true;
                    }
                }                 
            }
            if (!found)
            {
                Console.WriteLine("No entries found matching your query.\n");
            }
        }

        static void DeleteRecord(string pString)
        {
            Console.WriteLine();
            long pnum = PNumStringToInt64(pString);
            foreach (Person p in Person.Book)
            {                
                    if (p.PhoneNumber == pnum)
                    {
                        Console.WriteLine("Are you sure you wish to delete this number?  Type \"YES\" to confirm:");
                        string response = Console.ReadLine();
                        if (response == "YES")
                        {
                            Person.Book.Remove(p);
                            Console.WriteLine("Number deleted\n");
                        }
                        else
                        {
                            Console.WriteLine("Action cancelled\n");
                        }
                        return;
                    }
            }
            Console.WriteLine("That phone number doesn't exist.\n");          
        }

        static void UpdateFName(string pString)
        {
            Console.WriteLine();
            long pnum = PNumStringToInt64(pString);
            foreach (Person p in Person.Book)
            {
                if (p.PhoneNumber == pnum)
                {
                    Console.WriteLine("Type the new name you would like to replace to old:");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Are you sure you wish rename \"{0}\" to \"{1}\"?  Type \"YES\" to confirm:", p.FirstName, newName);
                    string response = Console.ReadLine();
                    if (response == "YES")
                    {
                        p.FirstName = newName;
                        Console.WriteLine("Name updated\n");
                    }
                    else
                    {
                        Console.WriteLine("Action cancelled\n");
                    }
                    return;
                }
            }
            Console.WriteLine("That phone number doesn't exist.\n");
        }

        static void DisplayMainMenu()
        {
            string response = "";
            do
            {
                Console.WriteLine("1) Add New Entry");
                Console.WriteLine("2) Search Existing Entries");
                Console.WriteLine("3) Delete Record");
                Console.WriteLine("4) Update Record");
                Console.WriteLine("5) Display All Records");
                Console.WriteLine("6) Exit\n");
                response = Console.ReadLine();
                switch (response)
                {
                    case "1": // Add New Entry
                        string fname, lname, st, cit, etat, zip;
                        long pnum;
                        Console.WriteLine("\nFIRST NAME:");
                        fname = Console.ReadLine();
                        Console.WriteLine("LAST NAME:");
                        lname = Console.ReadLine();
                        Console.WriteLine("PHONE NUMBER:");
                        pnum = PNumStringToInt64(Console.ReadLine());
                        Console.WriteLine("STREET ADDRESS:");
                        st = Console.ReadLine();
                        Console.WriteLine("CITY:");
                        cit = Console.ReadLine();
                        Console.WriteLine("STATE:");
                        etat = Console.ReadLine();
                        Console.WriteLine("ZIP CODE:");
                        zip = Console.ReadLine();
                        CreateEntry(fname, lname, pnum, st, cit, etat, zip);
                        Console.WriteLine("Entry created\n");
                        Console.WriteLine("Press any key to continue.\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "2": // Go to Search Submenu
                        DisplaySearchMenu();
                        break;
                    case "3": // Delete record
                        Console.WriteLine("A record can be deleted if you know the corresponding phone number.");
                        Console.WriteLine("Enter phone number:");
                        DeleteRecord(Console.ReadLine());
                        Console.WriteLine("Press any key to continue.\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "4": // Update record
                        Console.WriteLine("The first name for a record can be updated if you know the corresponding phone number.");
                        Console.WriteLine("Enter phone number:");
                        UpdateFName(Console.ReadLine());
                        Console.WriteLine("Press any key to continue.\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "5":
                        DisplayAllRecords();
                        Console.WriteLine("Press any key to continue.\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "6": // Exit
                        continue;
                    default:
                        Console.WriteLine("Invalid command\n");
                        break;
                }
            } while (response != "6");
        }

        static void DisplaySearchMenu()
        {
            string response = "";
            do
            {
                Console.WriteLine("1) Search by First Name");
                Console.WriteLine("2) Search by Last Name");
                Console.WriteLine("3) Search by City/State");
                Console.WriteLine("4) Main Menu\n");
                response = Console.ReadLine();
                switch (response)
                {
                    case "1": // Search by first name
                        Console.WriteLine("Enter first name:");
                        SearchByFName(Console.ReadLine());
                        Console.WriteLine("Press any key to continue.\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "2": // Search by last name
                        Console.WriteLine("Enter last name:");
                        SearchByLName(Console.ReadLine());
                        Console.WriteLine("Press any key to continue.\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "3": // search by citystate
                        Console.WriteLine("Enter city and/or state:");
                        SearchByCityState(Console.ReadLine());
                        Console.WriteLine("Press any key to continue.\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "4": // back to main
                        continue;
                    default:
                        Console.WriteLine("Invalid command\n");
                        break;
                }                
            } while (response != "4");
        }

        static void DisplayAllRecords()
        {
            Console.WriteLine();
            Person.Book.Sort();
            foreach (Person p in Person.Book)
            {
                Console.WriteLine(p.ToString());
                try
                {
                    Console.WriteLine(p._Address.ToString() + "\n");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine();
                }
                
            }
        }

        static long PNumStringToInt64(string pString)
        {
            pString = pString.Replace("(", "");
            pString = pString.Replace(")", "");
            pString = pString.Replace("-", "");
            pString = pString.Replace(" ", "");
            try
            {
                return Convert.ToInt64(pString);
            }
            catch (FormatException ex)
            {
                return 0;
            }
        }
    }
}
