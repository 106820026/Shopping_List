using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    public class ProductManagement
    {
        #region Member Data
        public event WriteNewDataEventHandler _writeNewData;// 自訂事件
        public delegate void WriteNewDataEventHandler();
        ReadFile _initial = new ReadFile(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";
        List<Product> _products; // 所有商品
        Product _editProduct;
        const int NAME_INDEX = 0;
        const int PRICE_INDEX = 1;
        const int CATEGORY_INDEX = 2;
        const int PATH_INDEX = 3;
        const int DETAIL_INDEX = 4;
        #endregion

        public ProductManagement()
        {
            _products = new List<Product>();
            this.InitialProduct();
        }

        //初始化所有商品
        public void InitialProduct()
        {
            foreach (String section in _initial.GetAllSections())
            {
                _products.Add(new Product());
                _products[_products.Count - 1].ProductPicturePath = _initial.GetPicturePath(section);
                _products[_products.Count - 1].ProductName = _initial.GetName(section);
                _products[_products.Count - 1].ProductCategory = _initial.GetType(section);
                _products[_products.Count - 1].ProductDetail = _initial.GetDetail(section);
                _products[_products.Count - 1].ProductPrice = _initial.GetPrice(section);
                _products[_products.Count - 1].ProductQuantity = _initial.GetStock(section);
            }
        }

        //取得所有商品
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        //取得category的所有商品
        public List<Product> GetProducts(String category)
        {
            List<Product> products = new List<Product>();
            foreach (Product product in _products)
                if (product.ProductCategory == category)
                    products.Add(product);
            return products;
        }

        //取得修改商品在所有商品中的index
        public int GetEditProductIndexOfAllProducts()
        {
            return _products.IndexOf(_editProduct);
        }

        //取得修改商品在分類商品中的index
        public int GetEditProductIndexOfProducts(String category)
        {
            return GetProducts(category).IndexOf(_editProduct);
        }

        //取得最後一筆加入的資料
        public Product GetLastestProduct()
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
