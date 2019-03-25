using CapstoneProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class GumTest
    {
        [TestMethod]
        public void GumExpectedSound()
        {
            Gum gum = new Gum("Some Gum", 3);

            string actual = gum.MakeSound();

            Assert.AreEqual("Chew Chew, Yum!", actual, "Make sound for gum");
        }
    }
}
