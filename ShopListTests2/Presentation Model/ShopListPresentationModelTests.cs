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
        ShopListPresentationModel _ShopListPresentationModel;
        ItemTabControlPages _itemTabControlPages;
        CategoryManagement _categoryManagement;
        ProductManagement _productManagement;
        ReadFile _readFIle = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../../Shopping/Data Info.ini";

        [TestInitialize]
        public void Initialize()
        {
            _productManagement = new ProductManagement(_readFIle);
            _categoryManagement = new CategoryManagement(_productManagement);
            _itemTabControlPages = new ItemTabControlPages(_categoryManagement);
            _ShopListPresentationModel = new ShopListPresentationModel();
        }

        [TestMethod()]
        public void ShopListPresentationModelTest()
        {
            Assert.Fail();
        }

        //[TestMethod()]
        //public void SetRowCountTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetCurrentProduceTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void IsInCartTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetDetailTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteCartItemTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void AddItemToCartTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetCartItemTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetStockTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetPriceTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ChangePageTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void IsFirstPageTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void IsLastPageTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void CheckConfirmButtonTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ResetCartTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void IsAlreadyInCartTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetSubtotalTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void UpdateProductQuantityTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void OutOfStockTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ChangeToMaximumStockTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetProductListTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetChangedProductRowIndexTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetEditProductNameTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetEditProductCategoryTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void GetEditProductPriceTest()
        //{
        //    Assert.Fail();
        //}
    }
}