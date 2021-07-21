using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
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
            Console.WriteLine("\t 1.Adding New Contact\n\t 2.Edit Contact\n\t 3.Delet Contact\n\t 0.For Exit");
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
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("\n\t Adding New Contact Please Enter Details");
                        StoreDetails store1 = new StoreDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);
                        store1 = TakeDetails(store1);
                        if (book.AddNewContact(store1.firstName, store1.lastName, store1.address, store1.city, store1.state, store1.zip, store1.phoneNumber, store1.email))
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
                        if (store == null)
                        {
                            Console.WriteLine("There is no such contact called {0} ", firstName);
                        }
                        else
                        {
                            StoreDetails store2 = new StoreDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);
                            store2 = TakeDetails(store2);
                            Console.WriteLine("Details are updated");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter First Name To Delete: ");
                        firstName = Console.ReadLine();
                        if (book.removeing(firstName))
                        {
                            Console.WriteLine("Contact Deleted successfull");
                        }
                        else
                        {
                            Console.WriteLine($"Given Contact {firstName} is not present");
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
        public static StoreDetails TakeDetails(StoreDetails store)
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
            return store;
        }

    }
}
