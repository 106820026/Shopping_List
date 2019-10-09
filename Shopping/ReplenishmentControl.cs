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

        // 輸入項目為0或空白
        public bool IsZero(String inputText)
        {
            if (inputText == "" || int.Parse(inputText)+1 == 1)
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
    }
}
