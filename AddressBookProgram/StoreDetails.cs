using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class StoreDetails
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public long phoneNumber { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return $"Name: {firstName} {lastName} Address: {address} City: {city} State: {state} Zip: {zip} PhoneNumber: {phoneNumber} Email: {email} ";
        }
    }
}