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
    public class ProductManagementSystemPresentationModelTests
    {
        CategoryManagement _categoryManagement;
        ProductManagement _productManagement;
        ProductManagementSystemPresentationModel _productManagementSystemPresentationModel;
        ReadFile _readFIle = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../../Shopping/Data Info.ini";

        [TestInitialize]
        public void Initialize()
        {
            _productManagement = new ProductManagement(_readFIle);
            _categoryManagement = new CategoryManagement(_productManagement);
            _productManagementSystemPresentationModel = new ProductManagementSystemPresentationModel(_categoryManagement, _productManagement);
        }

        [TestMethod()]
        public void ProductManagementSystemPresentationModelTest()
        {
            Assert.IsNotNull(_productManagementSystemPresentationModel);
        }

        [TestMethod()]
        public void ConfirmNameTest()
        {
            _productManagementSystemPresentationModel.ConfirmName("");
            _productManagementSystemPresentationModel.ConfirmName("a");
        }

        [TestMethod()]
        public void InputOnlyNumberTest()
        {
            Assert.IsTrue(_productManagementSystemPresentationModel.InputOnlyNumber('a'));
            Assert.IsFalse(_productManagementSystemPresentationModel.InputOnlyNumber('1'));
        }

        [TestMethod()]
        public void ConfirmPriceTest()
        {
            _productManagementSystemPresentationModel.ConfirmPrice("");
            _productManagementSystemPresentationModel.ConfirmPrice("0");
            _productManagementSystemPresentationModel.ConfirmPrice("1");
        }

        [TestMethod()]
        public void ConfirmTypeTest()
        {
            _productManagementSystemPresentationModel.ConfirmType(-1);
            _productManagementSystemPresentationModel.ConfirmType(1);
        }

        [TestMethod()]
        public void ConfirmPathTest()
        {
            _productManagementSystemPresentationModel.ConfirmPath("");
            _productManagementSystemPresentationModel.ConfirmPath("../../Resources/notFound.jpg");
        }

        [TestMethod()]
        public void ConfirmSaveButtonTest()
        {
            _productManagementSystemPresentationModel.ConfirmName("a");
            _productManagementSystemPresentationModel.ConfirmPrice("1");
            _productManagementSystemPresentationModel.ConfirmType(-1);
            _productManagementSystemPresentationModel.ConfirmPath("../../Resources/notFound.jpg");
            Assert.IsFalse(_productManagementSystemPresentationModel.ConfirmSaveButton());
            _productManagementSystemPresentationModel.ConfirmType(0);
            Assert.IsTrue(_productManagementSystemPresentationModel.ConfirmSaveButton());
        }

        [TestMethod()]
        public void ModifyProductTest()
        {
            String[] content = new string[] {"name", "999", "category", "filePath", "" };
            _productManagementSystemPresentationModel.ModifyProduct(0, content);
            Assert.AreEqual(_productManagement.GetEditProduct().ProductName, "name");
        }

        [TestMethod()]
        public void CopyFileToResourcesTest()
        {
            Assert.AreEqual(_productManagementSystemPresentationModel.CopyFileToResources("../../_cartIcon.png"), "../../Resources/_cartIcon.png");
            Assert.AreEqual(_productManagementSystemPresentationModel.CopyFileToResources("../../g"), "../../Resources/g");
        }

        [TestMethod()]
        public void AddNewProductTest()
        {
            String[] content = new string[] { "name", "999", "category", "filePath", "" };
            _productManagementSystemPresentationModel.AddNewProduct(content);
            Assert.AreEqual(_productManagement.GetEditProduct().ProductName, "name");
        }

        [TestMethod()]
        public void GetProductOfCategoryTest()
        {
            Assert.AreEqual(_productManagementSystemPresentationModel.GetProductOfCategory(0).Count, 7);
        }

        [TestMethod()]
        public void InputNoNumberTest()
        {
            Assert.IsFalse(_productManagementSystemPresentationModel.InputNoNumber('a'));
            Assert.IsTrue(_productManagementSystemPresentationModel.InputNoNumber('1'));
        }

        [TestMethod()]
        public void ConfirmCategoryNameTest()
        {
            Assert.IsFalse(_productManagementSystemPresentationModel.ConfirmCategoryName(""));
            Assert.IsFalse(_productManagementSystemPresentationModel.ConfirmCategoryName("主機板"));
            Assert.IsTrue(_productManagementSystemPresentationModel.ConfirmCategoryName("滑鼠"));
        }

        [TestMethod()]
        public void AddNewCategoryTest()
        {
            _productManagementSystemPresentationModel.AddNewCategory("滑鼠");
            Assert.AreEqual(_categoryManagement.GetLatestCategory().CategoryName, "滑鼠");
        }
    }
}