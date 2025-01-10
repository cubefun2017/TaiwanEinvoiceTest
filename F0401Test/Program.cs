using System;
using System.Collections.Generic;
using MIG4.Storage;

namespace F0401Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create F0401 create eInvoice for storage
            InvoiceF0401 F0401 = new InvoiceF0401();

            // create F0401test blank XML file
            string blankFileName = "F0401test-Blank.xml";
            F0401.CreateXML(F0401, blankFileName);

            // Create XML example file
            var f0401 = F0401.CreateExample();
            // override InvoiceNumber default value
            //f0401.MainDetails.InvoiceNumber = "1234567890"; //invalid invoice number

            // Valid format error
            List<string> errors = F0401.Validation(f0401);
            if (errors.Count == 0)
            {
                // Create example F0401.XML
                string fileName = "F0401test.xml";
                F0401.CreateXML(f0401, fileName);
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

