using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CapstoneProject
{
    public class VendingMachine
    {
        
        // Member Variables
        public Dictionary<string, VendingMachineItem> ItemsInVendingMachine { get; set; } = new Dictionary<string, VendingMachineItem>();

        private Dictionary<string, decimal> _priceForItems = new Dictionary<string, decimal>();

        // Properties
        public decimal AvailableFunds { get; private set; } = 0;

        /// <summary>
        /// Given the full file path, reads the pipe delimited items in the file
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadItemsFromFile(string filePath)
        {        
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        string[] item = line.Split("|");

                        ItemsInVendingMachine.Add(item[0], CreateItem(item));
                        _priceForItems.Add(item[1], decimal.Parse(item[2]));
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Create a VendingMachineItem given array of strings from file
        /// </summary>
        /// <param name="item">Array of items from file</param>
        public VendingMachineItem CreateItem(string [] item)
        {
            VendingMachineItem result;

            const int Type = 3;
            const int Name = 1;

            if (item[Type] == "Chip")
            {
                 result = new Chip(item[Name], decimal.Parse(item[2]));
            }
            else if (item[3] == "Candy")
            {
                result = new Candy(item[1], decimal.Parse(item[2]));
            }
            else if (item[3] == "Drink")
            {
                result = new Drink(item[1], decimal.Parse(item[2]));
            }
            else
            {
                result = new Gum(item[1], decimal.Parse(item[2]));
            }

            return result;

        }


        /// <summary>
        /// Add funds to vending machine specified by user selection, creates log file item
        /// </summary>
        /// <param name="selection"></param>
        public void AddFunds(int selection)
        {
            decimal amountFed = 0;

            if (selection == 1)
            {
                AvailableFunds += 1;
                amountFed = 1;
            }
            else if (selection == 2)
            {
                AvailableFunds += 2;
                amountFed = 2;
            }
            else if (selection == 3)
            {
                AvailableFunds += 5;
                amountFed = 5;
            }
            else if (selection == 4)
            {
                AvailableFunds += 10;
                amountFed = 10;
            }

            Log.WriteFeedMoneyToLog(amountFed, AvailableFunds);
        }

        /// <summary>
        /// Purchase items from vending machine, creates log file item
        /// </summary>
        /// <param name="key"></param>
        public void PurchaseItem(string key)
        {
            if (!ItemsInVendingMachine.ContainsKey(key))
            {
                throw new InvalidSlotException("Invalid slot location entered");
            }
            else if (ItemsInVendingMachine[key].Quantity == 0)
            {
                throw new OutOfStockException($"{ItemsInVendingMachine[key].Name} is sold out");
            }
            else if (AvailableFunds - ItemsInVendingMachine[key].Price < 0)
            {
                throw new InsufficientFundsException("Insufficient funds available for item selected");
            }
            else
            {
                Log.WritePurchaseToLog(ItemsInVendingMachine[key], AvailableFunds, key);

                SalesReport.AddSaleToSalesReport(ItemsInVendingMachine[key].Name, _priceForItems);

                RemoveItem(key);
                AvailableFunds -= ItemsInVendingMachine[key].Price;


            }
        }
        /// <summary>
        /// Decrement vending machine quantity
        /// </summary>
        /// <param name="key"></param>
        private void RemoveItem(string key)
        {
            ItemsInVendingMachine[key].Quantity--;

        }


        /// <summary>
        /// Calls static change class to return money to customer w/ smallest amount of coins
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetChange()
        {
            decimal amountToMakeChange = AvailableFunds;

            Log.WriteMakeChangeToLog(AvailableFunds);

            AvailableFunds = 0;

            var result = Change.GetChangeWithNoDollars(amountToMakeChange);

            return result;
        }
    }
}
