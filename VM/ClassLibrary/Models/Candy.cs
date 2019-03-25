using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneProject
{
    /// <summary>
    /// 
    /// </summary>
    public class Candy : VendingMachineItem
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemPrice"></param>
        public Candy(string itemName, decimal itemPrice) : base(itemName, itemPrice)
        {

        }

        /// <summary>
        /// Provides sound, overridden by each of the vending machine item subclasses
        /// </summary>
        /// <returns>String representation of the sound candy makes when eaten</returns>
        public override string MakeSound()
        {
            Sound.PlaySound("Candy.wav");
            return "Munch Munch, Yum!";
        }
    }
}
