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
        Initial _initial;
        const String PRICE_KEY = "price";
        int _totalPrice;
        List<String> _items = new List<string>(); //儲存加入購物車的物品

        public AddToCart(Initial initial)
        {
            this._initial = initial;
        }

        // 加入購物車
        public void AddItem(String itemName)
        {
            _items.Add(itemName);
            _totalPrice += int.Parse(_initial.Read(itemName, PRICE_KEY));
        }

        // 取得購物車內容
        public List<String> GetItemList()
        {
            return _items;
        }

        // 拿出購物車
        public void DeleteItem(int rowIndex)
        {
            _totalPrice -= int.Parse(_initial.Read(_items[rowIndex], PRICE_KEY));
            _items.RemoveAt(rowIndex);
        }
    }
}
