using CapstoneProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        private VendingMachine _machine = new VendingMachine();

        private string _fullFilePathLoadItems = Environment.CurrentDirectory + @"\..\..\..\..\etc\vendingmachine.csv";
        
        [TestMethod]
        public void LoadItemsTest()
        {
            _machine.LoadItemsFromFile(_fullFilePathLoadItems);

            Assert.AreEqual(16, _machine.ItemsInVendingMachine.Count, "16 items are loaded when the machine is loaded");
        }

        [TestMethod]
        public void Add1DollarToMachine()
        {
            _machine.AddFunds(1);

            Assert.AreEqual(1, _machine.AvailableFunds, "Feed 1 dollar into the machine");

        }

        [TestMethod]
        public void Add2DollarsToMachine()
        {
            _machine.AddFunds(2);

            Assert.AreEqual(2, _machine.AvailableFunds, "Feed 2 dollar into the machine");
        }

        [TestMethod]
        public void Add5DollarsToMachine()
        {
            _machine.AddFunds(3);

            Assert.AreEqual(5, _machine.AvailableFunds, "Feed 5 dollars into machine");
        }

        [TestMethod]
        public void Add10DollarsToMachine()
        {
            _machine.AddFunds(4);

            Assert.AreEqual(10, _machine.AvailableFunds, "Feed 10 dollars into machine");
        }

        [TestMethod]
        public void SelectItemValidLocation()
        {
            _machine.AddFunds(4);

            _machine.LoadItemsFromFile(_fullFilePathLoadItems);

            _machine.PurchaseItem("A1");

            Assert.AreEqual(4, _machine.ItemsInVendingMachine["A1"].Quantity, "Purchase an item in A1 spot");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSlotException))]
        public void MakeInvalidSelectionThrowsException()
        {
            _machine.AddFunds(4);

            _machine.LoadItemsFromFile(_fullFilePathLoadItems);

            _machine.PurchaseItem("A5");

        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void AttemptingPurchaseWithoutEnoughFundsThrowsException()
        {
            _machine.AddFunds(1);

            _machine.LoadItemsFromFile(_fullFilePathLoadItems);

            _machine.PurchaseItem("A1");

        }

        [TestMethod]
        [ExpectedException(typeof(OutOfStockException))]
        public void AttemptToBuyOutOfStockOptionThrowsException()
        {
            _machine.AddFunds(4);
            _machine.AddFunds(4);

            _machine.LoadItemsFromFile(_fullFilePathLoadItems);

            for(int i = 0; i < 6; i++)
            {
                _machine.PurchaseItem("A1");
            }
        }

        
    }
}
