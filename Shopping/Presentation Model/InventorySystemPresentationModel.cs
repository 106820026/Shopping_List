using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    public class InventorySystemPresentationModel
    {
        ProductManagement _productManagement;
        const String PICTURE_KEY = "picture";
        const String FORMAT = "#,0";
        const String DEFAULT_PICTURE = "../../Resources/notFound.jpg";

        public InventorySystemPresentationModel(ProductManagement productManagement)
        {
            _productManagement = productManagement;
        }

        // 取得所有商品詳細資料
        public List<String[]> GetAllItemDetail()
        {
            List<String[]> data = new List<string[]>();
            foreach (Product product in _productManagement.AllProducts)
            {
                data.Add(new string[] { product.ProductName, product.ProductCategory, int.Parse(product.ProductPrice).ToString(FORMAT), product.ProductQuantity });
            }
            return data;
        }

        // 取得新增商品詳細資料
        public String[] GetLatestItemDetail()
        {
            Product product = _productManagement.GetLatestProduct();
            return product.GetProductInventoryForm();
        }

        // 取得圖片
        public Image GetImageFilePath(int index)
        {
            try
            {
                return Image.FromFile(_productManagement.AllProducts[index].ProductPicturePath);
            }
            catch
            {
                return Image.FromFile(DEFAULT_PICTURE);
            }
        }

        // 取得詳細資訊
        public String GetItemDetail(int index)
        {
            return _productManagement.AllProducts[index].ProductDetail;
        }

        // 取得名稱
        public String GetName()
        {
            return _productManagement.GetEditProduct().ProductName;
        }

        // 取得庫存量
        public String GetStock()
        {
            return _productManagement.GetEditProduct().ProductQuantity;
        }

        // 取得類別
        public String GetCategory()
        {
            return _productManagement.GetEditProduct().ProductCategory;
        }

        // 取得價錢
        public String GetPrice()
        {
            return int.Parse(_productManagement.GetEditProduct().ProductPrice).ToString(FORMAT);
        }
    }
}
