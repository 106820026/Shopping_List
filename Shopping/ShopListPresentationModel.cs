using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class ShopListPresentationModel
    {
        #region Member Data
        Initial _initial;
        ItemTabControlPages _itemTabControlPages;
        ProductTypeManagement _productTypeManagement;
        AddToCart _cart;
        const String MODEL_KEY = "model";
        const String SEPARATE_LINE = "\n----------------------------------------------\n"; // 我是分隔線
        const String DETAIL_KEY = "detail";
        const String TYPE_KEY = "type";
        const String STOCK_KEY = "stock";
        const String PRICE_KEY = "price";
        const String PAGE = "page";
        const String FORMAT = "#, 0";
        const String NEXT_PAGE_BUTTON = "_nextPageButton";
        const String LAST_PAGE_BUTTON = "_lastPageButton";
        const String FIRST_PAGE = "1";
        const String ZERO = "0";
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int FIVE = 5;
        const int BUTTON_NUMBER = 6;
        String _currentItemSection;
        Dictionary<string, string> _itemNameAndSellNumber = new Dictionary<string, string>();
        int _currentTabIndex;
        int _rowCount;
        // current page
        int _motherBoardCurrentPage = 1;
        int _centralProcessUnitCurrentPage = 1;
        int _diskCurrentPage = 1;
        int _memoryCurrentPage = 1;
        int _graphicsProcessUnitCurrentPage = 1;
        int _computerCurrentPage = 1;
        int[] _allCurrentPage;
        // total page
        int _motherBoardTotalPage = TWO;
        int _centralProcessUnitTotalPage = TWO;
        int _diskTotalPage = TWO;
        int _memoryTotalPage = TWO;
        int _graphicsProcessUnitTotalPage = TWO;
        int _computerTotalPage = TWO;
        int[] _allTotalPage;
        // tab Index
        const int MOTHER_BOARD = 0;
        const int CENTRAL_PROCESS_UNIT = 1;
        const int DISK = TWO;
        const int MEMORY = THREE;
        const int GRAPHICS_PROCESS_UNIT = FOUR;
        const int COMPUTER = FIVE;
        #endregion
        
        public ShopListPresentationModel(Initial initial, ItemTabControlPages itemTabControlPages, ProductTypeManagement productTypeManagement)
        {
            this._initial = initial;
            this._itemTabControlPages = itemTabControlPages;
            this._productTypeManagement = productTypeManagement;
            _cart = new AddToCart(_initial);
            _allCurrentPage = new int[] { _motherBoardCurrentPage, _centralProcessUnitCurrentPage, _diskCurrentPage, _memoryCurrentPage, _graphicsProcessUnitCurrentPage, _computerCurrentPage };
            _allTotalPage = new int[] { _motherBoardTotalPage, _centralProcessUnitTotalPage, _diskTotalPage, _memoryTotalPage, _graphicsProcessUnitTotalPage, _computerTotalPage };
            _currentTabIndex = 0;
            _rowCount = 0;
        }

        // 購物車商品數量
        public void SetRowCount(int rowCount)
        {
            _rowCount = rowCount;
        }

        // 取得商品名稱
        public void GetCurrentItemSection(int tag, String tabName)
        {
            int index = BUTTON_NUMBER * (int.Parse(_itemTabControlPages.GetCurrentPage()) - 1) + tag;
            Console.WriteLine(tag);
            _currentItemSection = _productTypeManagement.GetCurrentTypeItemSections(tabName)[index];
        }

        // 顯示商品詳細資訊
        public String GetDetail()
        {
            return _initial.GetDescription(_currentItemSection);
        }

        // 刪除購物車內容
        public void DeleteCartItem(int rowIndex)
        {
            _cart.DeleteItem(rowIndex);
        }

        // 加入商品至購物車
        public void AddItemToCart()
        {
            _cart.AddItem(_currentItemSection);
        }

        // 更新購物車表格
        public String[] GetCartItem()
        {
            return _initial.GetOrderItemRow(_currentItemSection);
        }

        // 取得商品的整個row
        public String[] GetCartItem(String section)
        {
            return _initial.GetOrderItemRow(section);
        }

        // 顯示商品庫存
        public String GetStock()
        {
            return _initial.Read(_currentItemSection, STOCK_KEY);
        }

        // 顯示商品價錢
        public String GetPrice()
        {
            if (_currentItemSection != null)
                return int.Parse(_initial.Read(_currentItemSection, PRICE_KEY)).ToString(FORMAT);
            return string.Empty;
        }

        // 翻頁
        public void ChangePage(String itemName)
        {
            if (itemName == NEXT_PAGE_BUTTON)
                int.Parse(_itemTabControlPages.ChangePage(1));
            if (itemName == LAST_PAGE_BUTTON)
                int.Parse(_itemTabControlPages.ChangePage(-1));

        }

        //是否為第一頁
        public bool IsFirstPage()
        {
            return int.Parse(_itemTabControlPages.GetCurrentPage()) == 1;
        }

        // 是否為最後一頁
        public bool IsLastPage()
        {
            return int.Parse(_itemTabControlPages.GetCurrentPage()) == int.Parse(_itemTabControlPages.GetTotalPage());
        }

        // 確認訂購按鈕可以按下
        public bool CheckConfirmButton()
        {
            if (_rowCount == 0)
                return false;
            else
                return true;
        }

        // 清空購物車所有東西並取得rowCount
        public void ResetCart(int rowCount)
        {
            _cart.GetItemList().Clear();
            this.SetRowCount(rowCount);
        }

        // 已加入購物車
        public bool IsAlreadyInCart()
        {
            // 如果已經在DGV上或是庫存沒了都不可以
            return !(_cart.GetItemList().Contains(_currentItemSection) || _initial.GetStock(_currentItemSection) == ZERO);
        }

        // 單一商品總價
        public int GetSubtotal(int number, int rowIndex)
        {
            String value = ZERO;
            _itemNameAndSellNumber.TryGetValue(_cart.GetItemList()[rowIndex], out value); // 確認字典中無重複的key
            if (value == ZERO)
                _itemNameAndSellNumber.Add(_cart.GetItemList()[rowIndex], number.ToString());
            else
                _itemNameAndSellNumber[_cart.GetItemList()[rowIndex]] = number.ToString(); // 存入商品名稱和購買數量
            return number * int.Parse(_initial.GetPrice(_cart.GetItemList()[rowIndex]));
        }

        // 更新購買後庫存(寫入ini檔)
        public void UpdateStockAndWriteInInitial()
        {
            foreach (String key in _itemNameAndSellNumber.Keys)
            {
                int originalStock = int.Parse(_initial.GetStock(key));
                _initial.Write(key, STOCK_KEY, (originalStock - int.Parse(_itemNameAndSellNumber[key])).ToString());
            }
        }

        // 庫存不足
        public bool OutOfStock(int rowIndex, int orderNumber)
        {
            if (int.Parse(_initial.GetStock(_cart.GetItemList()[rowIndex])) < orderNumber)
                return true;
            return false;
        }

        // 改成庫存量
        public String ChangeToMaximumStock(int rowIndex)
        {
            return _initial.GetStock(_cart.GetItemList()[rowIndex]);
        }

        // 取得已經加入購物車所有商品的section
        public List<String> GetItemList()
        {
            return _cart.GetItemList();
        }

        // 如果修改的商品有放在購物車 回傳row index
        public int GetChangedItemRowIndex()
        {
            for (int i = 0; i < this.GetItemList().Count; i++)
            {
                if (this.GetItemList()[i] == _initial.GetChangeSection())
                    return i;
            }
            return 0;
        }
    }
}
