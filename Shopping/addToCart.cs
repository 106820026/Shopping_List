using ShopList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class AddToCart
    {
        const String PRICE_KEY = "price";
        int _totalPrice;
        List<Product> _items = new List<Product>(); //儲存加入購物車的物品

        // 加入購物車
        public void AddItem(Product product)
        {
            _items.Add(product);
            _totalPrice += int.Parse(product.ProductPrice);
        }

        // 取得購物車內容
        public List<Product> GetProductList()
        {
            return _items;
        }

        // 拿出購物車
        public void DeleteItem(int rowIndex)
        {
            _totalPrice -= int.Parse(_items[rowIndex].ProductPrice);
            _items.RemoveAt(rowIndex);
        }
    }
}
