using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    public class Product
    {
        const String SEPARATE_LINE = "\n----------------------------------------------\n"; // 分隔線
        const String FORMAT = "#, 0";

        public Product()
        {

        }

        public String ProductName
        {
            get;set;
        }

        public String ProductPrice
        {
            get; set;
        }

        public String ProductQuantity
        {
            get; set;
        }

        public String ProductCategory
        {
            get; set;
        }

        public String ProductPicturePath
        {
            get; set;
        }

        public String ProductDetail
        {
            get; set;
        }

        // 取得商品說明
        public String GetProductCaption()
        {
            return ProductName + SEPARATE_LINE + ProductDetail;
        }

        // 取得商品購物車表格資料
        public String[] GetProductCartForm()
        {
            return new string[] { String.Empty, ProductName, ProductCategory, int.Parse(ProductPrice).ToString(FORMAT), 1.ToString(), int.Parse(ProductPrice).ToString(FORMAT) };
        }

        // 取得商品補貨表格資料
        public String[] GetProductInventoryForm()
        {
            return new string[] { ProductName, ProductCategory, int.Parse(ProductPrice).ToString(FORMAT), ProductQuantity };
        }
    }
}
