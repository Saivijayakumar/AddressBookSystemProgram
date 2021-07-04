using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    /// <summary>
    /// =================>Welcome To Address Book Program<============
    /// </summary>
    class Program
    {
        public AddressBook book = new AddressBook();
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zip;
        public long phoneNumber;
        public string email;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Adress Book Program");
            Console.WriteLine("\t===> LIST of Features <====");
            Console.WriteLine("\t----------------------------------------------");
            Console.WriteLine("\t 1.Adding New Contact\n\t 2.Edit Contact\n\t 0.For Exit");
            Console.WriteLine("\t----------------------------------------------");
        
            Program program = new Program();
            program.FeaturesList();
            
        }
        public void FeaturesList()
        {
            bool simply = true;
            while (simply)
            {
                Console.Write("\n\tEnter your choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n\t Adding New Contact Please Enter Details");
                        Console.Write("Enter the First Name : ");
                        firstName = Console.ReadLine();
                        Console.Write("Enter the Last Name : ");
                        lastName = Console.ReadLine();
                        Console.Write("Enter the Address : ");
                        address = Console.ReadLine();
                        Console.Write("Enter the City Name : ");
                        city = Console.ReadLine();
                        Console.Write("Enter the State Name : ");
                        state = Console.ReadLine();
                        Console.Write("Enter the zip code : ");
                        zip = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Phone Number : ");
                        phoneNumber = long.Parse(Console.ReadLine());
                        Console.Write("Enter the email address : ");
                        email = Console.ReadLine();
                        if (book.AddNewContact(firstName, lastName, address, city, state, zip, phoneNumber, email))
                        {
                            Console.WriteLine("Contact Is Added Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Existing Contact");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter First Name to Edit: ");
                        firstName = Console.ReadLine();
                        StoreDetails store = book.CheckingExistence(firstName);
                        if(store == null)
                        {
                            Console.WriteLine("There is no such contact called {0} ", firstName);
                        }
                        else
                        {
                            Console.Write("Enter the First Name : ");
                            store.firstName = Console.ReadLine();
                            Console.Write("Enter the Last Name : ");
                            store.lastName = Console.ReadLine();
                            Console.Write("Enter the Address : ");
                            store.address = Console.ReadLine();
                            Console.Write("Enter the City Name : ");
                            store.city = Console.ReadLine();
                            Console.Write("Enter the State Name : ");
                            store.state = Console.ReadLine();
                            Console.Write("Enter the zip code : ");
                            store.zip = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter the Phone Number : ");
                            store.phoneNumber = long.Parse(Console.ReadLine());
                            Console.Write("Enter the email address : ");
                            store.email = Console.ReadLine();
                            Console.WriteLine("Details are updated");
                        }
                        break;
                    case 0:
                        simply = false;
                        break;

                    default:
                        Console.WriteLine("\t PLEASE ENTER A VALID OPTION");
                        break;
                }
            }
        }
        
    }
}
