using System;
using System.Collections.Generic;
using System.Linq;
using ShopList.Model;

namespace ShopList.PresentationModel
{
    public class ShopListPresentationModel
    {
        #region Member Data
        CategoryManagement _productTypeManagement;
        AddToCart _cart;
        ProductManagement _productManagement;
        const String FORMAT = "#,0";
        const int BUTTON_NUMBER = 6;
        Dictionary<Product, string> _itemNameAndSellNumber = new Dictionary<Product, string>();
        #endregion
        
        public ShopListPresentationModel(CategoryManagement productTypeManagement, ProductManagement productManagement)
        {
            this._productTypeManagement = productTypeManagement;
            _productManagement = productManagement;
            _cart = new AddToCart();
            RowCount = 0;
        }

        // 購物車商品數量
        public int RowCount
        {
            get;set;
        }

        // 目前選取的商品
        public Product CurrentProduct
        {
            get;set;
        }

        // 取得商品
        public void GetCurrentProduce(String currentPage, int tag, String category)
        {
            int index = BUTTON_NUMBER * (int.Parse(currentPage) - 1) + tag;
            CurrentProduct = _productManagement.GetProducts(category)[index];
        }

        // 修改的商品是否有加入購物車
        public bool IsEditItemInCart()
        {
            if (_cart.Cart.Contains(_productManagement.GetEditProduct()))
                return true;
            return false;
        }

        // 顯示商品詳細資訊
        public String GetDetail()
        {
            return CurrentProduct.GetProductCaption();
        }

        // 刪除購物車內容
        public void DeleteCartItem(int rowIndex)
        {
            _cart.DeleteItem(rowIndex);
            RowCount -= 1;
        }

        // 加入商品至購物車
        public void AddItemToCart()
        {
            _cart.AddItem(CurrentProduct);
            RowCount += 1;
        }

        // 更新購物車表格
        public String[] GetCartItem()
        {
            return CurrentProduct.GetProductCartForm();
        }

        // 顯示商品庫存
        public String GetQuantity()
        {
            return CurrentProduct.ProductQuantity;
        }

        // 顯示商品價錢
        public String GetPrice()
        {
            if (CurrentProduct != null)
                return int.Parse(CurrentProduct.ProductPrice).ToString(FORMAT);
            return string.Empty;
        }

        // 確認訂購按鈕可以按下
        public bool CheckConfirmButton()
        {
            if (RowCount == 0)
                return false;
            else
                return true;
        }

        // 清空購物車所有東西並取得rowCount
        public void ResetCart()
        {
            _cart.Cart.Clear();
            RowCount = 0;
        }

        // 已加入購物車
        public bool IsAlreadyInCart()
        {
            // 如果已經在DGV上或是庫存沒了都不可以
            return !(_cart.Cart.Contains(CurrentProduct) || CurrentProduct.ProductQuantity == 0.ToString());
        }

        // 單一商品總價
        public int GetSubtotal(int number, int rowIndex)
        {
            _itemNameAndSellNumber[_cart.Cart[rowIndex]] = number.ToString(); // 存入商品名稱和購買數量
            return number * int.Parse(_cart.Cart[rowIndex].ProductPrice);
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
            if (int.Parse(_cart.Cart[rowIndex].ProductQuantity) < orderNumber)
                return true;
            return false;
        }

        // 改成庫存量
        public String ChangeToMaximumStock(int rowIndex)
        {
            return _cart.Cart[rowIndex].ProductQuantity;
        }

        // 取得已經加入購物車的所有商品
        public List<Product> GetProductList()
        {
            return _cart.Cart;
        }

        // 如果修改的商品有放在購物車 回傳row index
        public int GetChangedProductRowIndex()
        {
            for (int i = 0; i < this.GetProductList().Count; i++)
                if (_cart.Cart[i] == _productManagement.GetEditProduct())
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
