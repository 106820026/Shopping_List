using System;

namespace ShopList.Model
{
    public class Product
    {
        #region Member Data
        const String SEPARATE_LINE = "\n----------------------------------------------\n"; // 分隔線
        const String FORMAT = "#,0";
        ReadFile _initial = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";
        #endregion

        public Product()
        {

        }

        public Product(String section)
        {

            this.ProductPicturePath = _initial.GetPicturePath(section);
            this.ProductName = _initial.GetName(section);
            this.ProductCategory = _initial.GetCategory(section);
            this.ProductDetail = _initial.GetDetail(section);
            this.ProductPrice = _initial.GetPrice(section);
            this.ProductQuantity = _initial.GetStock(section);
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
