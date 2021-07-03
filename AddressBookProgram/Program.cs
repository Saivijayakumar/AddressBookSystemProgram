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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Adress Book Program");
            //ReadInput();
            StoreDetails storeDetails = new StoreDetails("sai", "vijaya", "address", "city", "state", 123, 123456789, "something");
            Console.Read();
        }
        
    }
}
