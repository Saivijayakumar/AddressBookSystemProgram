using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class JsonOperations
    {
        const string PATH = @"C:\Users\SaiVijay\source\repos\AddressBookProgram\AddressBookProgram\JsonFile.json";
        public static void SerializeingJsonFile(Dictionary<string,AddressBook> keyValuePairs)
        {
            //convert object to streams of Bytes
            try
            {
                string res = JsonConvert.SerializeObject(keyValuePairs);
                File.WriteAllText(PATH, res);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DeserializeingJsonFile()
        {
            //converting streams of byte to object
            try
            {
                Dictionary<string,AddressBook> res = JsonConvert.DeserializeObject<Dictionary<string,AddressBook>>(File.ReadAllText(PATH));
                if(res != null)
                {
                    foreach (KeyValuePair<string, AddressBook> key in res)
                    {
                        Console.WriteLine($"===============>Address Book Name : {key.Key} <==================");
                        foreach (var value in key.Value.contactDetails)
                        {
                            Console.WriteLine(value.ToString() + "\n");
                        }
                        Console.WriteLine("-----------------------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
