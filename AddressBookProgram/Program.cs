using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class Program
    {
        public static Dictionary<string, AddressBook> addressBookDict = new Dictionary<string, AddressBook>();
        public static Dictionary<string, List<StoreDetails>> StateWiseContacts = new Dictionary<string, List<StoreDetails>>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Adress Book Program");
            Console.WriteLine("\t----------------------------------------------");
            Console.WriteLine("\t 1.Adding New Address Book\n\t 2.Working on the Existing Address Book\n\t 3.Display the persons from all Address Books who are in same state\n\t 0.For Exit");
            Console.WriteLine("\t----------------------------------------------");
            bool simply = true;
            Program program = new Program();
            while (simply)
            {
                Console.Write("\n\tEnter your choice For Address Book : ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Enter the Name of Address Book : ");
                        string name = Console.ReadLine();
                        addressBookDict.Add(name, new AddressBook());
                        break;
                    case 2:
                        Console.Write("Enter the Name of Address Book you wish to Work On : ");
                        name = Console.ReadLine();
                        if (addressBookDict.ContainsKey(name))
                        {
                            AddressBook addressBook = addressBookDict[name];
                            program.FeaturesList(addressBook, name);
                        }
                        else
                        {
                            Console.WriteLine($"There is No {name} Address Book \nEnter vallid Address Book Name");
                        }
                        break;
                    case 3:
                        Console.Write("Enter State Name: ");
                        string stateName = Console.ReadLine();
                        //This useing by now method....
                        DisplayPersonsStatewise(stateName);
                        //By using Dictonary we are displaying contacts...
                        DisplayStateWiseContacts(stateName);
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
        public void FeaturesList(AddressBook book, string addressBookName)
        {
            Console.WriteLine($"\tNow You Are In {addressBookName} Address Book");
            Console.WriteLine("\t===> LIST of Features <====");
            Console.WriteLine("\t----------------------------------------------");
            Console.WriteLine("\t 1.Adding New Contact\n\t 2.Edit Contact\n\t 3.Delet Contact\n\t 0.For Exit");
            Console.WriteLine("\t----------------------------------------------");
            bool simply = true;
            while (simply)
            {
                Console.Write("\n\tEnter your choice For Features List : ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("\n\t Adding New Contact Please Enter Details");
                        StoreDetails store1 = new StoreDetails();
                        store1 = TakeDetails(store1);
                        AddingStateWiseContacts(store1);
                        if (book.AddNewContact(store1))
                        {
                            Console.WriteLine("Contact Is Added Successfully");
                        }
                        else
                        {
                            Console.WriteLine("\n\t\t---->The Contact Already Exists<------");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter First Name to Edit: ");
                        string firstName = Console.ReadLine();
                        StoreDetails store = book.CheckingExistence(firstName);
                        if (store == null)
                        {
                            Console.WriteLine("There is no such contact called {0} ", firstName);
                        }
                        else
                        {
                            StoreDetails store2 = new StoreDetails();
                            store2 = TakeDetails(store2);
                            Console.WriteLine("Details are updated");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name To Delete: ");
                        firstName = Console.ReadLine();
                        if (book.removeing(firstName))
                        {
                            Console.WriteLine("\n\t------>Contact Deleted successfull<-------");
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
        public static void DisplayPersonsStatewise(string stateName)
        {
            if(addressBookDict.Count != 0)
            {
                Console.WriteLine($"These Are The List Of Persons From {stateName} State");
                foreach (var dict in addressBookDict)
                {
                    var retunList = dict.Value.storeDetails.FindAll(a => a.state.Equals(stateName));
                    foreach (var i in retunList)
                    {
                        Console.WriteLine(i.firstName);
                    }
                }
            }
            else
            {
                Console.WriteLine("We don't have any contacts First Add contacts");
            }
        }
        public static void AddingStateWiseContacts(StoreDetails details)
        {
            if (StateWiseContacts.ContainsKey(details.state))
            {
                List<StoreDetails> stateContacts = StateWiseContacts[details.state];
                stateContacts.Add(details);
            }
            else
            {
                List<StoreDetails> stateContacts = new List<StoreDetails>();
                stateContacts.Add(details);
                StateWiseContacts.Add(details.state, stateContacts);
            }
        }
        public static void DisplayStateWiseContacts(string stateName)
        {
            List<StoreDetails> stateContact = StateWiseContacts[stateName];
            Console.WriteLine($"These Are The List Of Contacts From {stateName} State");
            foreach (StoreDetails details in stateContact)
            {
                Console.Write($"Name : {details.firstName} {details.lastName}");
                Console.WriteLine($"\tPhone Number : {details.phoneNumber}");
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
