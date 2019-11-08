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
    public class TestInitialize
    {
        ReadFile _initial = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";
        Product _product;
        AddToCart _addToCart;

        [TestInitialize()]
        [DeploymentItem("ShopList.exe")]
        public void Initialize()
        {
            _product = new Product(_initial.GetAllSections()[0]);
            _addToCart = new AddToCart();
        }

        [TestMethod()]
        public void AddItemTest()
        {
            _addToCart.AddItem(_product);
            //Assert.AreEqual(_addToCart.GetProductList().Contains(_product), true);
        }

        //[TestMethod()]
        //public void GetProductListTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteItemTest()
        //{
        //    Assert.Fail();
        //}
    }
}