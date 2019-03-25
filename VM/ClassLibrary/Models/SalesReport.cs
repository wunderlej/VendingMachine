using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CapstoneProject
{
    public abstract class SalesReport
    {
        private static string _salesReportLocation = Environment.CurrentDirectory + @"\..\..\..\..\etc\SalesReport.txt";

        /// <summary>
        /// Given the item name and list of items with prices, load report, modify the amount sold
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemPrices"></param>
        public static void AddSaleToSalesReport(string itemName, Dictionary<string, decimal> itemPrices)
        {

            // Load report
            List<string> itemNames = new List<string>(itemPrices.Keys);

            var report = LoadReport(itemNames);

            // Modify report
            report[itemName]++;

            // Save report
            SaveReport(report, itemPrices);

        }


        /// <summary>
        /// Loads the report, returns the list of items as a dictionary with the quantities sold
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private static Dictionary<string, int> LoadReport(List<string> items)
        {
            Dictionary<string, int> reportData = new Dictionary<string, int>();

            // First check to see if report file exists
            // if true, load file into dictionary
            if (File.Exists(_salesReportLocation))
            {
                List<string> products = new List<string>(File.ReadAllLines(_salesReportLocation));

                foreach(string product in products)
                {
                    string[] lines = product.Split("|");

                    if(lines.Length == 2)
                    {
                        reportData.Add(lines[0], int.Parse(lines[1]));
                    }
                    
                }

               
            }
            //else, create dictionary from list of items initializing quanities to zero
            else
            {
                foreach(string item in items)
                {
                    reportData.Add(item, 0);
                }
            }

            return reportData;
        }

        /// <summary>
        /// Given two dictionaries containing price and quantity, rewrite file including total sales number
        /// </summary>
        /// <param name="itemsQuantity"></param>
        /// <param name="itemPrices"></param>
        private static void SaveReport(Dictionary<string, int> itemsQuantity, Dictionary<string, decimal> itemPrices)
        {
            decimal totalSales = 0;

            if (File.Exists(_salesReportLocation))
            {
                File.Delete(_salesReportLocation);
            }

            using(StreamWriter sw = new StreamWriter(_salesReportLocation, true))
            {
                foreach (var item in itemsQuantity)
                {
                    totalSales += itemPrices[item.Key] * item.Value;
                    sw.WriteLine($"{item.Key}|{item.Value}");
                }
                sw.WriteLine();
                sw.WriteLine($"**TOTAL SALES** {totalSales.ToString("C")}");
            }
            
        }
    }
}
