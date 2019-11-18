using ShopList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Model
{
    public class AddToCart
    {
        List<Product> _items = new List<Product>(); //儲存加入購物車的物品

        public List<Product> Cart
        {
            get
            {
                return _items;
            }
        }

        // 加入購物車
        public void AddItem(Product product)
        {
            _items.Add(product);
        }

        // 拿出購物車
        public void DeleteItem(int rowIndex)
        {
            _items.RemoveAt(rowIndex);
        }
    }
}
