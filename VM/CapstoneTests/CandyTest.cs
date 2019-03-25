using CapstoneProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class CandyTest
    {
        
        [TestMethod]
        public void CandyExpectedSound()
        {
            Candy candy = new Candy("Candy Bar", 1);

            string actual = candy.MakeSound();

            Assert.AreEqual("Munch Munch, Yum!", actual, "Make sound for candy");
        }
    }
}
