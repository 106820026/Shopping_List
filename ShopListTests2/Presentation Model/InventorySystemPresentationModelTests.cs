using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Tests
{
    [TestClass()]
    public class InventorySystemPresentationModelTests
    {
        ProductManagement _productManagement;
        InventorySystemPresentationModel _inventorySystemPresentationModel;
        ReadFile _initial = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../../Shopping/Data Info.ini";

        [TestInitialize]
        public void Initialize()
        {
            _productManagement = new ProductManagement(_initial);
            _inventorySystemPresentationModel = new InventorySystemPresentationModel(_productManagement);
        }

        [TestMethod()]
        public void InventorySystemPresentationModelTest()
        {
            Assert.IsNotNull(_productManagement);
        }

        [TestMethod()]
        public void GetAllItemDetailTest()
        {
            Assert.AreEqual(_inventorySystemPresentationModel.GetAllItemDetail().Count, 42);
        }

        [TestMethod()]
        public void GetLatestItemDetailTest()
        {
            String[] inventoryForm = new string[] { "Acer N50-600 i5-8400", "套裝電腦", "26,900", "5" };
            for(int i = 0; i < inventoryForm.Length; i++)
                Assert.AreEqual(_inventorySystemPresentationModel.GetLatestItemDetail()[i], inventoryForm[i]);
        }

        [TestMethod()]
        public void GetImageFilePathTest()
        {
            Assert.AreEqual(_inventorySystemPresentationModel.GetImageFilePath(0).Height, Image.FromFile("../../Resources/_motherBoardPage1Item1.jpg").Height);
            Assert.AreEqual(_inventorySystemPresentationModel.GetImageFilePath(-1).Height, Image.FromFile("../../Resources/notFound.jpg").Height);
        }

        [TestMethod()]
        public void GetItemDetailTest()
        {
            Assert.AreEqual(_inventorySystemPresentationModel.GetItemDetail(0), _productManagement.AllProducts[0].ProductDetail);
        }

        [TestMethod()]
        public void GetNameTest()
        {
            _productManagement.EditProductName(_productManagement.AllProducts[0], "name");
            Assert.AreEqual(_inventorySystemPresentationModel.GetName(), "name");
        }

        [TestMethod()]
        public void GetStockTest()
        {
            _productManagement.EditProductName(_productManagement.AllProducts[0], "name");
            Assert.AreEqual(_inventorySystemPresentationModel.GetStock(), "5");
        }

        [TestMethod()]
        public void GetCategoryTest()
        {
            _productManagement.EditProductCategory(_productManagement.AllProducts[0], "category");
            Assert.AreEqual(_inventorySystemPresentationModel.GetCategory(), "category");
        }

        [TestMethod()]
        public void GetPriceTest()
        {
            _productManagement.EditProductPrice(_productManagement.AllProducts[0], "999");
            Assert.AreEqual(_inventorySystemPresentationModel.GetPrice(), "999");
        }
    }
}