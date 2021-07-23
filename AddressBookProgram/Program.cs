using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class Program
    {
        //crating Dictionary for handleing multiple address books
        public static Dictionary<string, AddressBook> addressBookDict = new Dictionary<string, AddressBook>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Adress Book Program");
            Console.WriteLine("\t----------------------------------------------");
            Console.WriteLine("\t 1.Adding New Address Book\n\t 2.Working on the Existing Address Book\n\t 3.Display the persons from all Address Books who are in same state and count of the persons\n\t 0.For Exit");
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
                        //adding new address book
                        addressBookDict.Add(name, new AddressBook());
                        break;
                    case 2:
                        Console.Write("Enter the Name of Address Book you wish to Work On : ");
                        name = Console.ReadLine();
                        //checking the key is present are not. It help to handle run time exception.
                        if (addressBookDict.ContainsKey(name))
                        {
                            //by using the key we are geting the value in here it was object
                            AddressBook addressBook = addressBookDict[name];
                            //Displaying features for perticular address book
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
                        //Displaying all the persons from all address book who is from same state and count of the persons
                        DisplayPersonsStatewise(stateName);
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
            Console.WriteLine("\t 1.Adding New Contact\n\t 2.Edit Contact\n\t 3.Delet Contact\n\t 4.Display the count of contacts \n\t 0.For Exit");
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
                        //adding new contact
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
                        //checking the name is present in address book or not
                        StoreDetails store = book.CheckingExistence(firstName);
                        if (store == null)
                        {
                            Console.WriteLine("There is no such contact called {0} ", firstName);
                        }
                        else
                        {
                            StoreDetails store2 = new StoreDetails();
                            //If pressent changeing the details
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
                    case 4:
                        Console.WriteLine("\n Total Number of Address Book are : " + addressBookDict.Count);
                        Console.WriteLine(" Number of Contacts in this Dictionary : " + book.storeDetails.Count);
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
            int count = 0;
            if(addressBookDict.Count != 0)
            {
                //Console.WriteLine($"These Are The List Of Persons From {stateName} State");
                foreach (var dict in addressBookDict)
                {
                    var retunList = dict.Value.storeDetails.FindAll(a => a.state.Equals(stateName));
                    foreach (var i in retunList)
                    {
                        //if you want to see the names of the persons then you can use below line
                        //Console.WriteLine(i.firstName);
                        count++;
                    }
                }
                Console.WriteLine($"\n\t{count} Persons Are From Same State");
            }
            else
            {
                Console.WriteLine("We don't have any contacts First Add contacts");
            }
        }
        public static StoreDetails TakeDetails(StoreDetails store)
        {
            //This method help to Take all details
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
