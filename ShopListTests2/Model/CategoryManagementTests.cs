using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ShopList.Model.Tests
{
    [TestClass()]
    public class CategoryManagementTests
    {
        CategoryManagement _categoryManagement;
        ReadFile _initial = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";

        [TestInitialize]
        public void Initialize()
        {
            _categoryManagement = new CategoryManagement(new ProductManagement(_initial));
        }

        [TestMethod()]
        public void CategoryManagementTest()
        {
            Assert.IsNotNull(_categoryManagement);
        }

        [TestMethod()]
        public void InitialCategoriesTest()
        {
            _categoryManagement.InitialCategories();
            Assert.AreEqual(_categoryManagement.Categories.Count, 6);
        }

        [TestMethod()]
        public void AddCategoryTest()
        {
            _categoryManagement._addNewCategory += EventHandler;
            Category category = new Category("滑鼠");
            _categoryManagement.AddCategory(category);
            Assert.IsTrue(_categoryManagement.Categories.Contains(category));
            _categoryManagement._addNewCategory += EventHandler;
        }

        [TestMethod()]
        public void GetCategoryNameTest()
        {
            List<String> categoryName = new List<string> { "主機板", "CPU", "記憶體", "硬碟", "顯卡", "套裝電腦" };
            for (int i = 0; i < categoryName.Count; i++)
                Assert.AreEqual(categoryName[i], _categoryManagement.GetCategoryName()[i]);
        }

        [TestMethod()]
        public void GetTotalPageTest()
        {
            Assert.AreEqual(_categoryManagement.GetTotalPage(0), 2);
            Category category = new Category("滑鼠");
            _categoryManagement.AddCategory(category);
            Assert.AreEqual(_categoryManagement.GetTotalPage(6), 1);
        }

        [TestMethod()]
        public void GetCurrentCategoryProductTest()
        {
            Assert.AreEqual(_categoryManagement.GetCurrentCategoryProduct(0).Count, 7);
        }

        [TestMethod()]
        public void GetCurrentCategoryProductNameTest()
        {
            Assert.AreEqual(_categoryManagement.GetCurrentCategoryProductName(0).Count, 7);
        }

        [TestMethod()]
        public void ExistCategoryTest()
        {
            _categoryManagement.AddCategory(new Category("滑鼠"));
            Assert.IsTrue(_categoryManagement.ExistCategory("滑鼠"));
            Assert.IsFalse(_categoryManagement.ExistCategory("鍵盤"));
        }

        [TestMethod()]
        public void GetLatestCategoryTest()
        {
            Category mouse = new Category("滑鼠");
            _categoryManagement.AddCategory(mouse);
            Assert.AreEqual(_categoryManagement.GetLatestCategory(), mouse);
            Category keyboard = new Category("鍵盤");
            _categoryManagement.AddCategory(keyboard);
            Assert.AreNotEqual(_categoryManagement.GetLatestCategory(), mouse);
            Assert.AreEqual(_categoryManagement.GetLatestCategory(), keyboard);
        }

        public void EventHandler()
        {
            Assert.IsTrue(true);
        }
    }
}