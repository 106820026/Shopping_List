using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Model.Tests
{
    [TestClass()]
    public class ProductTests
    {
        Product product1;
        Product product2;

        [TestInitialize]
        public void Initialize()
        {
            product1 = new Product();
            product2 = new Product("_motherBoardItem1Page1");
        }
        [TestMethod()]
        public void ProductTest()
        {
            Assert.AreEqual(product1.ProductName, null);
        }

        [TestMethod()]
        public void ProductTest1()
        {
            Assert.AreEqual(product2.ProductName, "ROG STRIX Z390-E GAMING");
        }

        [TestMethod()]
        public void GetProductCaptionTest()
        {
            Assert.AreEqual(product2.GetProductCaption(), "ROG STRIX Z390-E GAMING\n----------------------------------------------\nIntel Z390 LGA 1151 ATX 電競主機板搭載 Aura Sync、802.11ac Wi-Fi、支援 DDR4 4266 MHz+、雙 M.2 含散熱片、SATA 6Gbps、HDMI 及 USB 3.1 Gen 2");
        }

        [TestMethod()]
        public void GetProductCartFormTest()
        {
            String[] test = new String[] { "", "ROG STRIX Z390-E GAMING", "主機板", "6,990", "1", "6,990" };
            for (int i = 0; i < product2.GetProductCartForm().Length; i++) 
                Assert.AreEqual(product2.GetProductCartForm()[i], test[i]);
        }

        [TestMethod()]
        public void GetProductInventoryFormTest()
        {
            String[] test = new String[] { "ROG STRIX Z390-E GAMING", "主機板", "6,990", "5" };
            for (int i = 0; i < product2.GetProductInventoryForm().Length; i++)
                Assert.AreEqual(product2.GetProductInventoryForm()[i], test[i]);
        }
    }
}