using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class FileIOOperations
    {
        const string FILEPATH = @"C:\Users\SaiVijay\source\repos\AddressBookProgram\AddressBookProgram\file.txt";
        //Write Operation
        public static void WriteingIntoFile(Dictionary<string,AddressBook> keyValuePair)
        {
            //It help to clear the file
            File.WriteAllText(FILEPATH, string.Empty);
            foreach(KeyValuePair<string,AddressBook> key in keyValuePair)
            {
                //store the address book name
                File.AppendAllText(FILEPATH, $"Address Book :{key.Key} \n");
                foreach(var value in key.Value.contactDetails)
                {
                    //store the contacts one by one
                    File.AppendAllText(FILEPATH, value.ToString() + Environment.NewLine);
                }

            }
        }
        //Read Operation
        public static void ReadTheFile()
        {
            //storeing all the data in a string 
            string lines = File.ReadAllText(FILEPATH);
            //just displaying that string
            Console.WriteLine(lines);
        }
    }
}
