using System;
using System.Collections.Generic;
using MIG4.Storage;

namespace G0401Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create G0401 Allowance information for storage
            InvoiceG0401 G0401 = new InvoiceG0401();

            // create blank XML file
            string blankFileName = "G0401test-Blank.xml";
            G0401.CreateXML(G0401, blankFileName);

            // Create XML example file
            var g0401 = G0401.CreateExample();

            // override Example value
            g0401.MainDetails.OriginalInvoiceBuyerId = "03563707"; //invalid Buyer Id, last number invalid it should be "03563708"
            //g0401.DetailsDetails.PIs.Add(new InvoiceG0401.Details.ProductItem { OriginalInvoiceNumber = "AA12345678" });

            // Valid format error
            List<string> errors = G0401.Validation(g0401);
            if (errors.Count == 0)
            {
                // Create example XML
                string fileName = "G0401test.xml";
                G0401.CreateXML(g0401, fileName);
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
