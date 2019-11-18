using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ShopList.Model;

namespace ShopList.PresentationModel.Tests
{
    [TestClass()]
    public class ReplenishmentPresentationModelTests
    {
        ReplenishmentPresentationModel _replenishmentPresentationModel;
        ProductManagement _productManagement;
        ReadFile _readFIle = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../../Shopping/Data Info.ini";

        [TestInitialize]
        public void Initialize()
        {
            _productManagement = new ProductManagement(_readFIle);
            _replenishmentPresentationModel = new ReplenishmentPresentationModel(_productManagement);
        }

        [TestMethod()]
        public void ReplenishmentPresentationModelTest()
        {
            Assert.IsNotNull(_replenishmentPresentationModel);
        }

        [TestMethod()]
        public void IsZeroTest()
        {
            Assert.IsFalse(_replenishmentPresentationModel.IsZero(""));
            Assert.IsFalse(_replenishmentPresentationModel.IsZero("0"));
            Assert.IsTrue(_replenishmentPresentationModel.IsZero("1"));
        }

        [TestMethod()]
        public void InputOnlyNumberTest()
        {
            Assert.IsTrue(_replenishmentPresentationModel.InputOnlyNumber('a'));
            Assert.IsFalse(_replenishmentPresentationModel.InputOnlyNumber((char)8));
            Assert.IsFalse(_replenishmentPresentationModel.InputOnlyNumber('1'));
        }

        [TestMethod()]
        public void GetReplenishmentNumberTest()
        {
            _replenishmentPresentationModel.GetReplenishmentNumber("5");
        }

        [TestMethod()]
        public void GetEditProductTest()
        {
            Assert.AreEqual(_replenishmentPresentationModel.GetEditProduct(0), _productManagement.AllProducts[0]);
        }

        [TestMethod()]
        public void UpdateQuantityTest()
        {
            _replenishmentPresentationModel.GetReplenishmentNumber("5");
            _replenishmentPresentationModel.UpdateQuantity(0);
        }
    }
}