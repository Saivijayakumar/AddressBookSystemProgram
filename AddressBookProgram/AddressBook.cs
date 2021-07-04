using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class AddressBook
    {
        public List<StoreDetails> storeDetails;
        public Dictionary<string, StoreDetails> keyValuesMap;

        public AddressBook()
        {
            storeDetails = new List<StoreDetails>();
            keyValuesMap = new Dictionary<string, StoreDetails>();
        }

        public bool AddNewContact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            StoreDetails store = new StoreDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);
            StoreDetails result = CheckingExistence(firstName);
            if (result == null)
            {
                storeDetails.Add(store);
                //storeing into dictionary
                keyValuesMap.Add(firstName, store);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool removeing(string firstName)
        {
            StoreDetails store = CheckingExistence(firstName);

            if(store != null)
            {
                storeDetails.Remove(store);
                //deleting in Dictionary
                keyValuesMap.Remove(firstName);
                return true;
            }
            else
            {
                return false;
            }
        }
        public StoreDetails CheckingExistence(string firstName)
        {
            StoreDetails store = storeDetails.Find((a) => a.firstName == firstName);
            return store;
        }
    }
}
