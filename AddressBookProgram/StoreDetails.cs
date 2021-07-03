using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class StoreDetails
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zip;
        public long phoneNumber;
        public string email;

        public StoreDetails(string firstName, string lastName, string address, string city, string state, int zip, long phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }
}
