using System;
using System.Collections.Generic;
using MIG4.Storage;

namespace F0501Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create F0501 Cancel eInvoice for storage
            InvoiceF0501 F0501 = new InvoiceF0501();

            // create blank XML file
            //string fileName = "F0501test.xml";
            //F0501.CreateXML(F0501, fileName);

            // Create XML example file
            var f0501 = F0501.CreateExample();
            // override InvoiceNumber default value
            //f0401.MainDetails.InvoiceNumber = "1234567890"; //invalid invoice number

            // Valid format error
            List<string> errors = F0501.Validation(f0501);
            if (errors.Count == 0)
            {
                // Create example F0401.XML
                string fileName = "F0501test.xml";
                F0501.CreateXML(f0501, fileName);
                Console.WriteLine($"{fileName} Created.");
            }
            else
            {
                // show all errors from Validation()
                ShowErrors(errors);
            }

            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }
        private static void ShowErrors(List<string> errors)
        {
            Console.WriteLine("Show Errors!");
            foreach (string error in errors)
            {
                Console.WriteLine(error);
            }
        }
    }
}
