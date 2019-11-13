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
    public class ShopListPresentationModelTests
    {
        ProductManagement _productManagement;
        CategoryManagement _categoryManagement;
        ShopListPresentationModel _ShopListPresentationModel;
        ReadFile _readFIle = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../../Shopping/Data Info.ini";

        [TestInitialize]
        public void Initialize()
        {
            _productManagement = new ProductManagement(_readFIle);
            _categoryManagement = new CategoryManagement(_productManagement);
            _ShopListPresentationModel = new ShopListPresentationModel(_categoryManagement, _productManagement);
        }

        [TestMethod()]
        public void ShopListPresentationModelTest()
        {
            Assert.IsNotNull(_ShopListPresentationModel);
        }

        [TestMethod()]
        public void GetCurrentProduceTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            Assert.AreEqual(_ShopListPresentationModel.CurrentProduct, _productManagement.AllProducts[0]);
        }

        [TestMethod()]
        public void IsEditItemInCartTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            _productManagement.EditProductName(_productManagement.AllProducts[0], "name");
            Assert.IsTrue(_ShopListPresentationModel.IsEditItemInCart());
            _productManagement.EditProductName(_productManagement.AllProducts[1], "name");
            Assert.IsFalse(_ShopListPresentationModel.IsEditItemInCart());
        }

        [TestMethod()]
        public void GetDetailTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            Assert.AreEqual(_ShopListPresentationModel.GetDetail(), _ShopListPresentationModel.CurrentProduct.GetProductCaption());
        }

        [TestMethod()]
        public void DeleteCartItemTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.AreEqual(_ShopListPresentationModel.RowCount, 1);
            _ShopListPresentationModel.DeleteCartItem(0);
            Assert.AreEqual(_ShopListPresentationModel.RowCount, 0);
        }

        [TestMethod()]
        public void AddItemToCartTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.AreEqual(_ShopListPresentationModel.RowCount, 1);
        }

        [TestMethod()]
        public void GetCartItemTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            for(int i = 0; i < _ShopListPresentationModel.GetCartItem().Length; i++)
                Assert.AreEqual(_ShopListPresentationModel.GetCartItem()[i], _productManagement.AllProducts[0].GetProductCartForm()[i]);
        }

        [TestMethod()]
        public void GetStockTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            Assert.AreEqual(_ShopListPresentationModel.GetQuantity(), _ShopListPresentationModel.CurrentProduct.ProductQuantity);
        }

        [TestMethod()]
        public void GetPriceTest()
        {
            Assert.AreEqual(_ShopListPresentationModel.GetPrice(), "");
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            Assert.AreEqual(_ShopListPresentationModel.GetPrice(), int.Parse(_ShopListPresentationModel.CurrentProduct.ProductPrice).ToString("#,0"));
        }

        [TestMethod()]
        public void CheckConfirmButtonTest()
        {
            _ShopListPresentationModel.RowCount = 0;
            Assert.IsFalse(_ShopListPresentationModel.CheckConfirmButton());
            _ShopListPresentationModel.RowCount = 10;
            Assert.IsTrue(_ShopListPresentationModel.CheckConfirmButton());
        }

        [TestMethod()]
        public void ResetCartTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            _ShopListPresentationModel.GetCurrentProduce("1", 1, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.AreEqual(_ShopListPresentationModel.RowCount, 2);
            _ShopListPresentationModel.ResetCart();
            Assert.AreEqual(_ShopListPresentationModel.RowCount, 0);
        }

        [TestMethod()]
        public void IsAlreadyInCartTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.IsFalse(_ShopListPresentationModel.IsAlreadyInCart());
            _ShopListPresentationModel.GetCurrentProduce("1", 1, "主機板");
            Assert.IsTrue(_ShopListPresentationModel.IsAlreadyInCart());
        }

        [TestMethod()]
        public void GetSubtotalTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.AreEqual(_ShopListPresentationModel.GetSubtotal(1, 0), 6990);
        }

        [TestMethod()]
        public void UpdateProductQuantityTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.AreEqual(_ShopListPresentationModel.GetSubtotal(2, 0), 13980);
            _ShopListPresentationModel.UpdateProductQuantity();
            Assert.AreEqual(_productManagement.AllProducts[0].ProductQuantity, 3.ToString());
        }

        [TestMethod()]
        public void OutOfStockTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.IsFalse(_ShopListPresentationModel.OutOfStock(0, 5));
            Assert.IsTrue(_ShopListPresentationModel.OutOfStock(0, 6));
        }

        [TestMethod()]
        public void ChangeToMaximumStockTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.AreEqual(_ShopListPresentationModel.ChangeToMaximumStock(0), "5");
        }

        [TestMethod()]
        public void GetProductListTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.AreEqual(_ShopListPresentationModel.GetProductList()[0], _productManagement.AllProducts[0]);
        }

        [TestMethod()]
        public void GetChangedProductRowIndexTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            _ShopListPresentationModel.GetCurrentProduce("1", 1, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            Assert.AreEqual(_ShopListPresentationModel.GetChangedProductRowIndex(), 0);
            _productManagement.EditProductName(_productManagement.AllProducts[1], "name");
            Assert.AreEqual(_ShopListPresentationModel.GetChangedProductRowIndex(), 1);
        }

        [TestMethod()]
        public void GetEditProductNameTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            _productManagement.EditProductName(_productManagement.AllProducts[0], "name");
            Assert.AreEqual(_ShopListPresentationModel.GetEditProductName(), "name");
        }

        [TestMethod()]
        public void GetEditProductCategoryTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            _productManagement.EditProductCategory(_productManagement.AllProducts[0], "cagegory");
            Assert.AreEqual(_ShopListPresentationModel.GetEditProductCategory(), "cagegory");
        }

        [TestMethod()]
        public void GetEditProductPriceTest()
        {
            _ShopListPresentationModel.GetCurrentProduce("1", 0, "主機板");
            _ShopListPresentationModel.AddItemToCart();
            _productManagement.EditProductPrice(_productManagement.AllProducts[0], "999");
            Assert.AreEqual(_ShopListPresentationModel.GetEditProductPrice(), "999");
        }
    }
}