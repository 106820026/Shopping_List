using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopList.Model.Tests
{
    [TestClass()]
    public class CategoryTests
    {

        [TestMethod()]
        public void CategoryTest()
        {
            Category category = new Category("category");
            Assert.AreEqual(category.CategoryName, "category");
        }
    }
}