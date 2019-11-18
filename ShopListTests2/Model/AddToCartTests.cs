using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopList.Model.Tests
{
    [TestClass()]
    public class AddToCartTests
    {
        Product _product;
        AddToCart _addToCart;

        [TestInitialize]
        public void Initialize()
        {
            _addToCart = new AddToCart();
            _product = new Product();
        }

        [TestMethod()]
        public void AddItemTest()
        {
            _addToCart.AddItem(_product);
            Assert.IsTrue(_addToCart.Cart.Contains(_product));
        }

        [TestMethod()]
        public void DeleteItemTest()
        {
            _addToCart.AddItem(_product);
            Assert.IsTrue(_addToCart.Cart.Contains(_product));
            _addToCart.DeleteItem(0);
            Assert.IsFalse(_addToCart.Cart.Contains(_product));
        }
    }
}