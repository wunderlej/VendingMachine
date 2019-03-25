using CapstoneProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class ChipTest
    {
        [TestMethod]
        public void ChipExpectedSound()
        {
            Chip chip = new Chip("Munchies", 2);

            string actual = chip.MakeSound();

            Assert.AreEqual("Crunch Crunch, Yum!", actual, "Make sound for chip");
        }
    }
}
