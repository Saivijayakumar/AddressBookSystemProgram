using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class AddressBook
    {
        List<StoreDetails> storeDetails;

        public AddressBook()
        {
            storeDetails = new List<StoreDetails>();
        }

        public bool AddNewContact(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            StoreDetails store = new StoreDetails(firstName,lastName, address,  city,  state,  zip,  phoneNumber,  email);
            StoreDetails result = CheckingExistence(firstName);
            if (result == null)
            {
                storeDetails.Add(store);
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
