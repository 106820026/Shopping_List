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
        int _totalPrice;
        List<String> _items = new List<string>(); //儲存加入購物車的物品

        public AddToCart()
        {

        }

        // 加入購物車
        public void AddItem(String itemName, int price)
        {
            _items.Add(itemName);
            _totalPrice += price;
            System.Diagnostics.Debug.Print(_items.Count.ToString());
        }

        // 取得購物車內容
        public List<String> GetItemList()
        {
            return _items;
        }

        // 取得購物車內總金額
        public int GetTotalPrice()
        {
            return _totalPrice;
        }
    }
}
