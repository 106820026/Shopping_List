using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class ReplenishmentControl
    {
        const int DELETE_BUTTON = 8;
        readonly Initial _initial = new Initial(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";
        const String STOCK_KEY = "stock";
        private int _replenishmentNumber;

        // 輸入項目為0或空白
        public bool IsZero(String inputText)
        {
            if (inputText == "" || int.Parse(inputText) + 1 == 1)
                return false;
            return true;
        }

        // 只能輸入數字
        public bool InputOnlyNumber(char inputChar)
        {
            if (char.IsNumber(inputChar) != true && inputChar != DELETE_BUTTON)
                return true;
            return false;

        }

        // 取得補貨數量
        public void GetReplenishmentNumber(String number)
        {
            if (number != "")
                _replenishmentNumber = int.Parse(number);
        }

        // 補貨完 更新庫存數量
        public void UpdateStockNumber(String itemName)
        {
            int originalStock = int.Parse(_initial.Read(itemName, STOCK_KEY));
            _initial.Write(itemName, STOCK_KEY, (originalStock + _replenishmentNumber).ToString());
        }
    }
}
