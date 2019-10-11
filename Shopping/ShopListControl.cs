using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    class ShopListControl
    {
        #region Member Data
        readonly Initial _initialFile = new Initial(FILE_PATH);
        AddToCart _cart = new AddToCart();
        const String FILE_PATH = "../../Data Info.ini";
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
        const String OUT_OF_STOCK = "庫存不足";
        const String STOCK_STATUS = "庫存狀態";
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int FIVE = 5;
        String _currentItemName;
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
        
        public ShopListControl()
        {
            _allCurrentPage = new int[] { _motherBoardCurrentPage, _centralProcessUnitCurrentPage, _diskCurrentPage, _memoryCurrentPage, _graphicsProcessUnitCurrentPage, _computerCurrentPage };
            _allTotalPage = new int[] { _motherBoardTotalPage, _centralProcessUnitTotalPage, _diskTotalPage, _memoryTotalPage, _graphicsProcessUnitTotalPage, _computerTotalPage };
            _currentTabIndex = 0;
            _rowCount = 0;
        }

        // 取得目前Tab Index
        public void SetCurrentTabIndex(int tabIndex)
        {
            _currentTabIndex = tabIndex;
        }

        // 購物車商品數量
        public void SetRowCount(int rowCount)
        {
            _rowCount = rowCount;
        }

        // 取得商品名稱
        public void GetCurrentItemName(String buttonName)
        {
            _currentItemName = buttonName + PAGE + _allCurrentPage[_currentTabIndex];
        }

        // 顯示商品詳細資訊
        public String GetDetail()
        {
            return _initialFile.GetDescription(_currentItemName);
        }

        // 顯示目前頁數
        public String GetCurrentPage()
        {
            return _allCurrentPage[_currentTabIndex].ToString();
        }

        // 顯示總頁數
        public String GetTotalPage()
        {
            return _allTotalPage[_currentTabIndex].ToString();
        }

        // 刪除購物車內容
        public void DeleteCartItem(int rowIndex)
        {
            _cart.DeleteItem(rowIndex);
        }

        // 加入商品至購物車
        public void AddItemToCart()
        {
            _cart.AddItem(_currentItemName);
        }

        // 更新購物車表格
        public String[] GetCartItem()
        {
            return _initialFile.GetOrderItemRow(_currentItemName);
        }

        // 顯示商品庫存
        public String GetStock()
        {
            return int.Parse(_initialFile.Read(_currentItemName, STOCK_KEY)).ToString(FORMAT);
        }

        // 顯示商品價錢
        public String GetPrice()
        {
            return int.Parse(_initialFile.Read(_currentItemName, PRICE_KEY)).ToString(FORMAT);
        }

        // 翻頁
        public void ChangePage(String itemName)
        {
            if (itemName == NEXT_PAGE_BUTTON)
                _allCurrentPage[_currentTabIndex] += 1; // 頁數+1
            if (itemName == LAST_PAGE_BUTTON)
                _allCurrentPage[_currentTabIndex] -= 1; // 頁數-1
        }

        //是否為第一頁
        public bool IsFirstPage()
        {
            return _allCurrentPage[_currentTabIndex] == 1;
        }

        // 是否為最後一頁
        public bool IsLastPage()
        {
            return _allCurrentPage[_currentTabIndex] == _allTotalPage[_currentTabIndex];
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
            return !_cart.GetItemList().Contains(_currentItemName);
        }

        // 單一商品總價
        public int GetSubtotal(int number, int rowIndex)
        {
            return number * int.Parse(_initialFile.GetPrice(_cart.GetItemList()[rowIndex]));
        }

        // 確認庫存量
        public String CheckStock(int rowIndex, int orderNumber)
        {
            if (this.OutOfStock(rowIndex, orderNumber)) // 如果庫存不足
                return this.GetStockNumber(rowIndex); //值設定成庫存量
            return orderNumber.ToString(FORMAT);
        }

        // 庫存不足
        public bool OutOfStock(int rowIndex, int orderNumber)
        {
            if (int.Parse(_initialFile.GetStock(_cart.GetItemList()[rowIndex])) < orderNumber)
            {
                MessageBox.Show(OUT_OF_STOCK, STOCK_STATUS);
                return true;
            }
            return false;
        }

        // 取得庫存
        public String GetStockNumber(int rowIndex)
        {
            return _initialFile.GetStock(_cart.GetItemList()[rowIndex]);
        }
    }
}
