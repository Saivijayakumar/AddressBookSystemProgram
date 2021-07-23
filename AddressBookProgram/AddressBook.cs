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
        public AddressBook()
        {
            storeDetails = new List<StoreDetails>();
        }
        public bool AddNewContact(StoreDetails store)
        {
            StoreDetails result = CheckingExistence(store.firstName);
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
        public bool removeing(string firstName)
        {
            StoreDetails store = CheckingExistence(firstName);

            if (store != null)
            {
                storeDetails.Remove(store);
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