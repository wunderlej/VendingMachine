using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineCLI.Classes;

namespace CapstoneProject
{
    public class VMCLI
    {
        private VendingMachine _machine;

        public VMCLI(VendingMachine machine)
        {
            _machine = machine;
        }

        public void MainMenu()
        {
            Console.WriteLine(SplashScreen.StartupScreen());
            Console.WriteLine("Developed by: Ben Loper | John Wunderle");
            Console.WriteLine("\nUnder the instructions and direction of Chris Rupp");
            System.Threading.Thread.Sleep(2000);


            // Load items into vending _machine

            LoadItems();



            //(1) Display Vending _machine Items(2) Purchase(3) Exit



            bool quitMenu = false;

            while (!quitMenu)
            {
                Console.Clear();
                Console.WriteLine("1) Display Vending Machine Items");
                Console.WriteLine("2) Purchase");
                Console.WriteLine("3) Exit");


                Console.WriteLine();

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 4);

                if (selection == 1)
                {
                    DisplayMenu();
                }
                else if (selection == 2)
                {
                    PurchaseMenu();

                }
                else if (selection == 3)
                {
                    quitMenu = true;
                }



            }


        }



        /// <summary>
        /// Loads items into _machine object upon project start 
        /// </summary>
        private void LoadItems()
        {
            string fullFilePathLoadItems = Environment.CurrentDirectory + @"\..\..\..\..\etc\vendingmachine.csv";

            _machine.LoadItemsFromFile(fullFilePathLoadItems);

        }

        public void DisplayMenu()
        {
            bool quit = false;

            while (!quit)
            {
                Console.Clear();

                Console.WriteLine("Slot Location".PadRight(20) + "Product Name".PadRight(20) + "Price".PadRight(10) + "Quantity");

                foreach (var item in _machine.ItemsInVendingMachine)
                {
                    PrintItem(_machine.ItemsInVendingMachine[item.Key], item.Key);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");

                Console.WriteLine($"Current Money Provided: {_machine.AvailableFunds.ToString("C")}");



                Console.Write("Select slot location or enter Q to return to the main menu: ");

                string userSelection = Console.ReadLine().ToUpper();

                try
                {
                    if (userSelection.ToLower() == "q")
                    {
                        quit = true;
                    }
                    else
                    {
                        _machine.PurchaseItem(userSelection);
                        DispensedItemMenu(userSelection, _machine);
                    }
                }
                catch (InvalidSlotException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nPress any key to return to the purchase menu...");
                    Console.ReadKey();
                }
                catch (OutOfStockException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nPress any key to return to the purchase menu...");
                    Console.ReadKey();
                }
                catch (InsufficientFundsException ex)
                {
                    DisplayExceptionMessage(ex.Message);
                }
            }
        }

        private void DisplayExceptionMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("\nPress any key to return to the purchase menu...");
            Console.ReadKey();
        }

        public void PurchaseMenu()
        {
            bool quit = false;

            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("1) Feed Money");
                Console.WriteLine("2) Select Product");
                Console.WriteLine("3) Finish Transaction");
                Console.WriteLine("\n");
                Console.WriteLine($"Current Money Provided: {_machine.AvailableFunds.ToString("C")}");
                Console.WriteLine("\n");

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 3);
                if (selection == 1)
                {
                    FeedMoneyMenu();
                }
                else if (selection == 2)
                {
                    DisplayMenu();
                }
                else if (selection == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("\nChange received:");
                    Console.WriteLine();

                    foreach (var item in _machine.GetChange())
                    {
                        Console.WriteLine($"{item.Value} {item.Key}");
                    }

                    Console.ReadKey();

                    quit = true;
                }
            }
        }

        public void FeedMoneyMenu()
        {
            bool quit = false;

            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("1) $1");
                Console.WriteLine("2) $2");
                Console.WriteLine("3) $5");
                Console.WriteLine("4) $10");
                Console.WriteLine("5) Back");
                Console.WriteLine("\n");

                Console.WriteLine($"Current Money Provided: {_machine.AvailableFunds.ToString("C")}");

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 5);

                if (selection < 5)
                {
                    _machine.AddFunds(selection);
                    Sound.PlaySound("AddChange.wav");
                }
                else if (selection == 5)
                {
                    quit = true;
                }
            }
        }

        private static void PrintItem(VendingMachineItem item, string itemLocation)
        {
            if (item.DisplayQuantity == "SOLD OUT")
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"{itemLocation}".PadRight(20) + $"{item.Name}".PadRight(20) + $"{item.Price.ToString("C")}".PadRight(10) + $"{item.DisplayQuantity}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{itemLocation}".PadRight(20) + $"{item.Name}".PadRight(20) + $"{item.Price.ToString("C")}".PadRight(10) + $"{item.DisplayQuantity}");
            }
        }

        public void DispensedItemMenu(string userSelection, VendingMachine _machine)
        {
            //bool quit = false;

            //while (!quit)
            {
                Console.Clear();

                Console.WriteLine($"{_machine.ItemsInVendingMachine[userSelection].Name}");

                Console.WriteLine($"{_machine.ItemsInVendingMachine[userSelection].Price.ToString("C")}");

                Console.WriteLine($"{_machine.ItemsInVendingMachine[userSelection].MakeSound()}\n");

                Console.WriteLine($"Current Money Provided: {_machine.AvailableFunds.ToString("C")}");

                Console.Write("Push any button to go back to purchase menu...");

                Console.ReadKey();

               // quit = true;
            }






        }

    }
}
