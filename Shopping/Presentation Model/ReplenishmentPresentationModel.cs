using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    public class ReplenishmentPresentationModel
    {
        const int DELETE_BUTTON = 8;
        ProductManagement _productManagement;
        private String _replenishmentNumber;

        public ReplenishmentPresentationModel(ProductManagement productManagement)
        {
            _productManagement = productManagement;
        }

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
                _replenishmentNumber = number;
        }

        // 取得被修改的商品
        public Product GetEditProduct(int rowIndex)
        {
            return _productManagement.AllProducts[rowIndex];
        }

        // 補貨完 更新庫存數量
        public void UpdateQuantity(int rowIndex)
        {
            _productManagement.EditProductQuantity(this.GetEditProduct(rowIndex), int.Parse(_replenishmentNumber));
        }
    }
}
