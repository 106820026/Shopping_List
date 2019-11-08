using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Tests
{
    [TestClass()]
    public class AddToCartTests
    {
        ReadFile _initial = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";
        Product _product;
        AddToCart _addToCart;

        [TestInitialize()]
        [DeploymentItem("Bank.exe")]
        public void Initialize()
        {
            _addToCart = new AddToCart();
            _product = new Product(_initial.GetAllSections()[0]);
        }

        [TestMethod()]
        public void AddItemTest()
        {
            _addToCart.AddItem(_product);
            Assert.IsTrue(_addToCart.GetProductList().Contains(_product));
        }

        [TestMethod()]
        public void GetProductListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteItemTest()
        {
            Assert.Fail();
        }
    }
}