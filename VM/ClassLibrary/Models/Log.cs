using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CapstoneProject
{
    public static class Log
    {

        private static string _logFileLocation = Environment.CurrentDirectory + @"\..\..\..\..\etc\Log.txt";


        /// <summary>
        /// Create a log line when money is fed into vending machine
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="resultAmount"></param>
        public static void WriteFeedMoneyToLog(decimal amount, decimal resultAmount)
        {
            WriteToLog($"{DateTime.Now}  ".PadRight(20) + "FEED MONEY:".PadRight(25) + $"{amount.ToString("C")}".PadRight(10) + $"{resultAmount.ToString("C")}".PadRight(20));
        }


        /// <summary>
        /// Create a log line when an item is purchased
        /// </summary>
        /// <param name="item"></param>
        /// <param name="previousBalance"></param>
        /// <param name="location">Location of the product purchased ex. (A1)</param>
        public static void WritePurchaseToLog(VendingMachineItem item, decimal previousBalance, string location)
        {
            WriteToLog($"{DateTime.Now}  ".PadRight(20) + $"{item.Name} {location}".PadRight(25) + $"{previousBalance.ToString("C")}".PadRight(10) + $"{(previousBalance - item.Price).ToString("C")}".PadRight(20));
        }


        /// <summary>
        /// Create a log line for change received when transaction is finished
        /// </summary>
        /// <param name="previousAmount">Vending machine balance</param>
        public static void WriteMakeChangeToLog(decimal previousAmount)
        {
            WriteToLog($"\n{DateTime.Now}  ".PadRight(20) + "GIVE CHANGE:".PadRight(25) + $"{previousAmount.ToString("C")}".PadRight(10) + $"$0.00".PadRight(20));
        }


        /// <summary>
        /// Simplifies other log methods by pulling out need to create and use StreamWriter
        /// </summary>
        /// <param name="line"></param>
        public static void WriteToLog(string line)
        {
            using (StreamWriter sw = new StreamWriter(_logFileLocation, true))
            {
                sw.WriteLine(line);
            }
        }
    }
}
