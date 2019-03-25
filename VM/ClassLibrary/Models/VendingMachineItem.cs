using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneProject
{
    public abstract class VendingMachineItem
    {
        
        public string Name { get; set; }
        public decimal Price { get; private set; }
        public int Quantity { get; set; } = 5;
        public string DisplayQuantity
        {
            get
            {
                string result = Quantity.ToString();

                if(Quantity == 0)
                {
                    result = "SOLD OUT";
                }

                return result;

            }
        }


        public VendingMachineItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }


        /// <summary>
        /// Provides sound, overridden by each of the vending machine item subclasses
        /// </summary>
        /// <returns></returns>
        public abstract string MakeSound();



    }
}
