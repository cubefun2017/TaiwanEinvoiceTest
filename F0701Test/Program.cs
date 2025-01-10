using System;
using System.Collections.Generic;
using MIG4.Storage;

namespace F0701Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create F0701 create void eInvoice for storage
            InvoiceF0701 F0701 = new InvoiceF0701();

            // create blank XML file
            string blankFileName = "F0701test-Blank.xml";
            F0701.CreateXML(F0701, blankFileName);

            // Create XML example file
            var f0701 = F0701.CreateExample();
            // override InvoiceNumber default value
            //f0401.MainDetails.InvoiceNumber = "1234567890"; //invalid invoice number

            // Valid format error
            List<string> errors = F0701.Validation(f0701);
            if (errors.Count == 0)
            {
                // Create example F0401.XML
                string fileName = "F0701test.xml";
                F0701.CreateXML(f0701, fileName);
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
