using CapstoneProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineItemTests
    {
        private string _fullFilePathLoadItems = Environment.CurrentDirectory + @"\..\..\..\..\etc\vendingmachine.csv";

        private VendingMachine _machine = new VendingMachine();

        [TestMethod]
        public void ItemOutOfStockDisplayAsSoldOut()
        {
            _machine.AddFunds(4);
            _machine.AddFunds(4);

            _machine.LoadItemsFromFile(_fullFilePathLoadItems);

            for (int i = 0; i < 5; i++)
            {
                _machine.PurchaseItem("A1");
            }

            Assert.AreEqual("SOLD OUT", _machine.ItemsInVendingMachine["A1"].DisplayQuantity, "Items sold out should display as \"SOLD OUT\"");
        }
    }
}
