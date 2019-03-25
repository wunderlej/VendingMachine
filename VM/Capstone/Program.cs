using System;

namespace CapstoneProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VendingMachine machine = new VendingMachine();
                VMCLI startUp = new VMCLI(machine);
                startUp.MainMenu();
            }
            catch (InvalidInventoryException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Unable to create the machine object");
                Console.WriteLine("The program will now close...");
                Console.ReadKey();
            }
            
        }
    }
}
