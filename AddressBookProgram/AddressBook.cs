using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class AddressBook
    {
        //It help to store the contacts 
        public List<StoreDetails> storeDetails;
        //default constructure
        public AddressBook()
        {
            storeDetails = new List<StoreDetails>();
        }
        public bool AddNewContact(StoreDetails store)
        {
            //checking the name is present in list are not
            StoreDetails result = CheckingExistence(store.firstName);
            if (result == null)
            {
                storeDetails.Add(store);
                //it helps to sort the list by state name
                storeDetails = storeDetails.OrderBy(p => p.state).ToList();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool removeing(string firstName)
        {
            //checking the name is present in list are not
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
            //checking the name is present in list are not
            StoreDetails store = storeDetails.Find((a) => a.firstName == firstName);
            return store;
        }
    }
}