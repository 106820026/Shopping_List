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
        Dictionary<Int32, String> _itemCode = new Dictionary<Int32, string>(); //每個物品綁一個id, 方便查詢
        List<String> _items = new List<string> //儲存加入購物車的物品
        {
            null };

        public AddToCart()
        {

        }

        // 把物品的id和名稱變成字典
        public void MakeDictionary(Int32 hashCode, String name)
        {
            if (!_itemCode.ContainsKey(hashCode))
                _itemCode.Add(hashCode, name);
        }

        // 加入購物車
        public void AddItem(Int32 hashCode, int price)
        {
            _items.Add(_itemCode[hashCode]);
            _totalPrice += price;
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

        // 取得id名稱字典
        public Dictionary<Int32, String> GetItemCode()
        {
            return this._itemCode;
        }
    }
}
