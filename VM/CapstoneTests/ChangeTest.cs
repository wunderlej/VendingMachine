using CapstoneProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTest
    {
        [TestMethod]
        public void OneDollarGives4Quarters()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 4);
            expected.Add("Dime(s)", 0);
            expected.Add("Nickel(s)", 0);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(1);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }

        [TestMethod]
        public void GiveChangeFor55Cents()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 2);
            expected.Add("Dime(s)", 0);
            expected.Add("Nickel(s)", 1);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(.55m);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }

        [TestMethod]
        public void GiveChangeFor60Cents()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 2);
            expected.Add("Dime(s)", 1);
            expected.Add("Nickel(s)", 0);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(.60m);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }

        [TestMethod]
        public void GiveChangeFor1DollarAnd10Cents()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 4);
            expected.Add("Dime(s)", 1);
            expected.Add("Nickel(s)", 0);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(1.1m);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }

        [TestMethod]
        public void GiveChangeFor40Cents()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 1);
            expected.Add("Dime(s)", 1);
            expected.Add("Nickel(s)", 1);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(.4m);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }

        [TestMethod]
        public void GiveChangeFor25Cents()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 1);
            expected.Add("Dime(s)", 0);
            expected.Add("Nickel(s)", 0);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(.25m);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }

        [TestMethod]
        public void GiveChangeFor10Cents()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 0);
            expected.Add("Dime(s)", 1);
            expected.Add("Nickel(s)", 0);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(.1m);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }

        [TestMethod]
        public void GiveChangeFor5Cents()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 0);
            expected.Add("Dime(s)", 0);
            expected.Add("Nickel(s)", 1);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(.05m);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }

        [TestMethod]
        public void GiveChangeFor0()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();

            expected.Add("Quarter(s)", 0);
            expected.Add("Dime(s)", 0);
            expected.Add("Nickel(s)", 0);

            Dictionary<string, int> actual = new Dictionary<string, int>();

            actual = Change.GetChangeWithNoDollars(0);

            CollectionAssert.AreEqual(expected, actual, "Make change for a dollar");
        }
    }
}
