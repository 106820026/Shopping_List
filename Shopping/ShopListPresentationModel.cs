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
        ItemTabControlPages _itemTabControlPages;
        CategoryManagement _productTypeManagement;
        AddToCart _cart;
        ProductManagement _productManagement;
        const String FORMAT = "#, 0";
        const String NEXT_PAGE_BUTTON = "_nextPageButton";
        const String LAST_PAGE_BUTTON = "_lastPageButton";
        const int BUTTON_NUMBER = 6;
        Product _product;
        Dictionary<Product, string> _itemNameAndSellNumber = new Dictionary<Product, string>();
        int _rowCount;
        #endregion
        
        public ShopListPresentationModel(ItemTabControlPages itemTabControlPages, CategoryManagement productTypeManagement, ProductManagement productManagement)
        {
            this._itemTabControlPages = itemTabControlPages;
            this._productTypeManagement = productTypeManagement;
            _productManagement = productManagement;
            _cart = new AddToCart();
            _rowCount = 0;
        }

        // 購物車商品數量
        public void SetRowCount(int rowCount)
        {
            _rowCount = rowCount;
        }

        // 取得商品
        public void GetCurrentProduce(int tag, String category)
        {
            int index = BUTTON_NUMBER * (int.Parse(_itemTabControlPages.GetCurrentPage()) - 1) + tag;
            _product = _productManagement.GetProducts(category)[index];
        }

        // 修改的商品是否有加入購物車
        public bool IsInCart()
        {
            if (_cart.GetProductList().Contains(_productManagement.GetEditProduct()))
                return true;
            return false;
        }

        // 顯示商品詳細資訊
        public String GetDetail()
        {
            return _product.GetProductCaption();
        }

        // 刪除購物車內容
        public void DeleteCartItem(int rowIndex)
        {
            _cart.DeleteItem(rowIndex);
        }

        // 加入商品至購物車
        public void AddItemToCart()
        {
            _cart.AddItem(_product);
        }

        // 更新購物車表格
        public String[] GetCartItem()
        {
            return _product.GetProductCartForm();
        }

        // 顯示商品庫存
        public String GetStock()
        {
            return _product.ProductQuantity;
        }

        // 顯示商品價錢
        public String GetPrice()
        {
            if (_product != null)
                return int.Parse(_product.ProductPrice).ToString(FORMAT);
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

        // 是否為第一頁
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
            _cart.GetProductList().Clear();
            this.SetRowCount(rowCount);
        }

        // 已加入購物車
        public bool IsAlreadyInCart()
        {
            // 如果已經在DGV上或是庫存沒了都不可以
            return !(_cart.GetProductList().Contains(_product) || _product.ProductQuantity == 0.ToString());
        }

        // 單一商品總價
        public int GetSubtotal(int number, int rowIndex)
        {
            String value = 0.ToString();
            _itemNameAndSellNumber.TryGetValue(_cart.GetProductList()[rowIndex], out value); // 確認字典中無重複的key
            if (value == 0.ToString())
                _itemNameAndSellNumber.Add(_cart.GetProductList()[rowIndex], number.ToString());
            else
                _itemNameAndSellNumber[_cart.GetProductList()[rowIndex]] = number.ToString(); // 存入商品名稱和購買數量
            return number * int.Parse(_cart.GetProductList()[rowIndex].ProductPrice);
        }

        // 更新購買後庫存
        public void UpdateProductQuantity()
        {
            foreach (Product product in _itemNameAndSellNumber.Keys.ToArray())
            {
                int originalStock = int.Parse(product.ProductQuantity);
                _productManagement.EditProductQuantity(product, -int.Parse(_itemNameAndSellNumber[product]));
            }
            _itemNameAndSellNumber.Clear();
        }

        // 庫存不足
        public bool OutOfStock(int rowIndex, int orderNumber)
        {
            if (int.Parse(_cart.GetProductList()[rowIndex].ProductQuantity) < orderNumber)
                return true;
            return false;
        }

        // 改成庫存量
        public String ChangeToMaximumStock(int rowIndex)
        {
            return _cart.GetProductList()[rowIndex].ProductQuantity;
        }

        // 取得已經加入購物車的所有商品
        public List<Product> GetProductList()
        {
            return _cart.GetProductList();
        }

        // 如果修改的商品有放在購物車 回傳row index
        public int GetChangedProductRowIndex()
        {
            for (int i = 0; i < this.GetProductList().Count; i++)
                if (_cart.GetProductList()[i] == _productManagement.GetEditProduct())
                    return i;
            return 0;
        }

        // 取得修改商品的名稱
        public String GetEditProductName()
        {
            return _productManagement.GetEditProduct().ProductName;
        }

        // 取得修改商品的類別
        public String GetEditProductCategory()
        {
            return _productManagement.GetEditProduct().ProductCategory;
        }

        // 取得修改商品的價格
        public String GetEditProductPrice()
        {
            return int.Parse(_productManagement.GetEditProduct().ProductPrice).ToString(FORMAT);
        }
    }
}
