using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookProgram
{
    class CSVOperations
    {
        public static void CsvSerialize(Dictionary<string,AddressBook> temp)
        {
            try
            {
                string path =@"C:\Users\SaiVijay\source\repos\AddressBookProgram\AddressBookProgram\CSVFile.csv";
                using(StreamWriter writer = new StreamWriter(path))
                {
                    using(var csvWriter = new CsvWriter(writer,CultureInfo.InvariantCulture))
                    {
                        foreach(var i in temp)
                        {
                            csvWriter.WriteField("Address Book Name : " + i.Key);
                            csvWriter.NextRecord();
                            foreach (AddressBook res in temp.Values)
                            {
                                csvWriter.WriteRecords(res.contactDetails);
                            }
                        }
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void CsvDeserialize()
        {
            string path = @"C:\Users\SaiVijay\source\repos\AddressBookProgram\AddressBookProgram\CSVFile.csv";
            string line = File.ReadAllText(path);
            Console.WriteLine(line);
        }

    }
}
