using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class InventorySystemPresentationModel
    {
        ProductManagement _productManagement;
        const String PICTURE_KEY = "picture";
        const String FORMAT = "#,0";

        public InventorySystemPresentationModel(ProductManagement productManagement)
        {
            _productManagement = productManagement;
        }

        /// 取得所有商品詳細資料
        public List<String[]> GetAllItemDetail()
        {
            List<String[]> data = new List<string[]>();
            foreach (Product product in _productManagement.GetAllProducts())
            {
                data.Add(new string[] { product.ProductName, product.ProductCategory, int.Parse(product.ProductPrice).ToString(FORMAT), product.ProductQuantity });
            }
            return data;
        }

        /// 取得新增商品詳細資料
        public String[] GetLastestItemDetail()
        {
            Product product = _productManagement.GetLastestProduct();
            return new string[] { product.ProductName, product.ProductCategory, int.Parse(product.ProductPrice).ToString(FORMAT), product.ProductQuantity };
        }

        /// 取得圖片
        public Image GetImageFilePath(int index)
        {
            return Image.FromFile(_productManagement.GetAllProducts()[index].ProductPicturePath);
        }

        /// 取得詳細資訊
        public String GetItemDetail(int index)
        {
            return _productManagement.GetAllProducts()[index].ProductDetail;
        }

        /// 開啟補貨頁面
        public void OpenReplenishmentPage(int index)
        {
            Replenishment replenishment = new Replenishment(index, _productManagement);
            replenishment.ShowDialog();
        }

        /// 用Name取得RowIndex
        public int GetRowIndexBySection(String name)
        {
            for (int i = 0; i < _productManagement.GetAllProducts().Count; i++)
                if (_productManagement.GetAllProducts()[i].ProductName == name)
                    return i;
            return 0;
        }

        /// 取得名稱
        public String GetName()
        {
            return _productManagement.GetEditProduct().ProductName;
        }

        /// 取得庫存量
        public String GetStock()
        {
            return _productManagement.GetEditProduct().ProductQuantity;
        }

        /// 取得類別
        public String GetCategory()
        {
            return _productManagement.GetEditProduct().ProductCategory;
        }

        /// 取得價錢
        public String GetPrice()
        {
            return _productManagement.GetEditProduct().ProductPrice;
        }
    }
}
