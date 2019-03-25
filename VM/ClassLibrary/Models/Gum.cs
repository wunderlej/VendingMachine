using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneProject
{
    public class Gum : VendingMachineItem
    {
        public Gum(string itemName, decimal itemPrice) : base(itemName, itemPrice)
        {

        }

        /// <summary>
        /// Provides sound, overridden by each of the vending machine item subclasses
        /// </summary>
        /// <returns></returns>
        public override string MakeSound()
        {
            Sound.PlaySound("Gum.wav");
            return "Chew Chew, Yum!";
        }
    }
}
