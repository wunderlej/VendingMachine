using CapstoneProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class DrinkTest
    {
        [TestMethod]
        public void DrinkExpectedSound()
        {
            Drink drink = new Drink("Some drink", 9);

            string actual = drink.MakeSound();

            Assert.AreEqual("Glug Glug, Yum!", actual, "Make sound for drink");
        }
    }
}
