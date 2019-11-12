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
    public class ProductManagementTests
    {
        ProductManagement _productManagement;
        ReadFile _initial = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";

        [TestInitialize]
        public void Initialize()
        {
            _productManagement = new ProductManagement(_initial);
        }

        [TestMethod()]
        public void ProductManagementTest()
        {
            Assert.IsNotNull(_productManagement.AllProducts);
            Assert.AreEqual(_productManagement.AllProducts.Count, 42);
        }

        [TestMethod()]
        public void GetProductsTest()
        {
            Assert.AreEqual(_productManagement.GetProducts("主機板").Count, 7);
        }

        [TestMethod()]
        public void GetEditProductIndexOfAllProductsTest()
        {
            _productManagement.EditProductName(_productManagement.AllProducts[0], "test");
            Assert.AreEqual(_productManagement.GetEditProductIndexOfAllProducts(), 0);
        }

        [TestMethod()]
        public void GetLatestProductTest()
        {
            int index = _productManagement.AllProducts.Count - 1;
            Assert.AreEqual(_productManagement.GetLatestProduct(), _productManagement.AllProducts[index]);
        }

        [TestMethod()]
        public void EditProductNameTest()
        {
            _productManagement._writeNewData += EventHandler;
            _productManagement.EditProductName(_productManagement.AllProducts[0], "name");
            Assert.AreEqual(_productManagement.AllProducts[0].ProductName, "name");
            _productManagement._writeNewData += EventHandler;
        }

        [TestMethod()]
        public void EditProductCategoryTest()
        {
            _productManagement._writeNewData += EventHandler;
            _productManagement.EditProductCategory(_productManagement.AllProducts[0], "category");
            Assert.AreEqual(_productManagement.AllProducts[0].ProductCategory, "category");
            _productManagement._writeNewData += EventHandler;
        }

        [TestMethod()]
        public void EditProductPriceTest()
        {
            _productManagement._writeNewData += EventHandler;
            _productManagement.EditProductPrice(_productManagement.AllProducts[0], "123");
            Assert.AreEqual(_productManagement.AllProducts[0].ProductPrice, "123");
            _productManagement._writeNewData += EventHandler;
        }

        [TestMethod()]
        public void EditProductDetailTest()
        {
            _productManagement._writeNewData += EventHandler;
            _productManagement.EditProductDetail(_productManagement.AllProducts[0], "detail");
            Assert.AreEqual(_productManagement.AllProducts[0].ProductDetail, "detail");
            _productManagement._writeNewData += EventHandler;
        }

        [TestMethod()]
        public void EditProductQuantityTest()
        {
            _productManagement._writeNewData += EventHandler;
            _productManagement.EditProductQuantity(_productManagement.AllProducts[0], 5);
            Assert.AreEqual(_productManagement.AllProducts[0].ProductQuantity, "10");
            _productManagement._writeNewData += EventHandler;
        }

        [TestMethod()]
        public void EditProductPicturePathTest()
        {
            _productManagement._writeNewData += EventHandler;
            _productManagement.EditProductPicturePath(_productManagement.AllProducts[0], "path");
            Assert.AreEqual(_productManagement.AllProducts[0].ProductPicturePath, "path");
            _productManagement._writeNewData += EventHandler;
        }

        [TestMethod()]
        public void AddNewProductTest()
        {
            _productManagement._writeNewData += EventHandler;
            String[] list = new String[] { "name", "999", "category", "path", "detail" };
            _productManagement.AddNewProduct(list);
            Assert.AreEqual(_productManagement.GetEditProduct(), _productManagement.GetLatestProduct());
            Assert.AreEqual(_productManagement.GetEditProduct().ProductName, "name");
            Assert.AreEqual(_productManagement.GetEditProduct().ProductPrice, "999");
            Assert.AreEqual(_productManagement.GetEditProduct().ProductCategory, "category");
            Assert.AreEqual(_productManagement.GetEditProduct().ProductPicturePath, "path");
            Assert.AreEqual(_productManagement.GetEditProduct().ProductDetail, "detail");
            Assert.AreEqual(_productManagement.GetEditProduct().ProductQuantity, "0");
            _productManagement._writeNewData += EventHandler;

        }

        [TestMethod()]
        public void GetEditProductTest()
        {
            Product editProduct = new Product();
            _productManagement.EditProductName(editProduct, "edit");
            Assert.AreEqual(_productManagement.GetEditProduct(), editProduct);
            Assert.AreEqual(_productManagement.GetEditProduct().ProductName, "edit");
        }

        public void EventHandler()
        {
            Assert.IsTrue(true);
        }
    }
}