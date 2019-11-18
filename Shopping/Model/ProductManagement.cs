using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Model
{
    public class ProductManagement
    {
        #region Member Data
        public event WriteNewDataEventHandler _writeNewData;// 自訂事件
        public delegate void WriteNewDataEventHandler();
        ReadFile _initial;
        List<Product> _products; // 所有商品
        Product _editProduct;
        const int NAME_INDEX = 0;
        const int PRICE_INDEX = 1;
        const int CATEGORY_INDEX = 2;
        const int PATH_INDEX = 3;
        const int DETAIL_INDEX = 4;
        #endregion

        public ProductManagement(ReadFile initial)
        {
            _products = new List<Product>();
            _initial = initial;
            this.InitialProduct();
        }

        //初始化所有商品
        private void InitialProduct()
        {
            foreach (String section in _initial.GetAllSections().Cast<String>().ToList())
                _products.Add(new Product(section));
        }

        //取得所有商品
        public List<Product> AllProducts
        {
            get
            {
                return _products;
            }
        }

        //取得category的所有商品
        public List<Product> GetProducts(String category)
        {
            List<Product> products = new List<Product>();
            foreach (Product product in AllProducts)
                if (product.ProductCategory == category)
                    products.Add(product);
            return products;
        }

        //取得修改商品在所有商品中的index
        public int GetEditProductIndexOfAllProducts()
        {
            return _products.IndexOf(_editProduct);
        }

        ////取得修改商品在分類商品中的index
        //public int GetEditProductIndexOfProducts(String category)
        //{
        //    return GetProducts(category).IndexOf(_editProduct);
        //}

        //取得最後一筆加入的資料
        public Product GetLatestProduct()
        {
            return _products[_products.Count - 1];
        }

        //修改商品名稱
        public void EditProductName(Product product, String newName)
        {
            _editProduct = product;
            product.ProductName = newName;
            if (_writeNewData != null)
                this._writeNewData(); // 如果檔案有變動 發出訊號
        }

        //修改商品類別
        public void EditProductCategory(Product product, String newCategory)
        {
            _editProduct = product;
            product.ProductCategory = newCategory;
            if (_writeNewData != null)
                this._writeNewData(); // 如果檔案有變動 發出訊號
        }

        //修改商品價格
        public void EditProductPrice(Product product, String newPrice)
        {
            _editProduct = product;
            product.ProductPrice = newPrice;
            if (_writeNewData != null)
                this._writeNewData(); // 如果檔案有變動 發出訊號
        }

        //修改商品內容
        public void EditProductDetail(Product product, String newDetail)
        {
            _editProduct = product;
            product.ProductDetail = newDetail;
            if (_writeNewData != null)
                this._writeNewData(); // 如果檔案有變動 發出訊號
        }

        //修改商品數量
        public void EditProductQuantity(Product product, int addQuantity)
        {
            _editProduct = product;
            product.ProductQuantity = (int.Parse(product.ProductQuantity) + addQuantity).ToString();
            if (_writeNewData != null)
                this._writeNewData(); // 如果檔案有變動 發出訊號
        }

        //修改商品圖片路徑
        public void EditProductPicturePath(Product product, String newPath)
        {
            _editProduct = product;
            product.ProductPicturePath = newPath;
            if (_writeNewData != null)
                this._writeNewData(); // 如果檔案有變動 發出訊號
        }

        //新增商品
        public void AddNewProduct(String[] content)
        {
            _products.Add(new Product());
            _products[_products.Count - 1].ProductName = content[NAME_INDEX];
            _products[_products.Count - 1].ProductPrice = content[PRICE_INDEX];
            _products[_products.Count - 1].ProductCategory = content[CATEGORY_INDEX];
            _products[_products.Count - 1].ProductPicturePath = content[PATH_INDEX];
            _products[_products.Count - 1].ProductDetail = content[DETAIL_INDEX];
            _products[_products.Count - 1].ProductQuantity = 0.ToString();
            _editProduct = _products[_products.Count - 1];
            if (_writeNewData != null)
                this._writeNewData(); // 如果檔案有變動 發出訊號
        }

        //取得被修改的商品
        public Product GetEditProduct()
        {
            return _editProduct;
        }
    }
}
