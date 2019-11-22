using System;
using System.Collections.Generic;

namespace ShopList.Model
{
    public class CategoryManagement
    {
        #region Member Data
        public event AddNewCategoryEventHandler _addNewCategory;// 自訂事件
        public delegate void AddNewCategoryEventHandler();
        ProductManagement _productManagement;
        List<Category> _categories = new List<Category>();
        #endregion

        public CategoryManagement(ProductManagement productManagement)
        {
            _productManagement = productManagement;
            this.InitialCategories();
        }

        // 存所有類別(只有在有新增類別的時候才要重call)
        public void InitialCategories()
        {
            _categories.Clear();
            foreach (Product product in _productManagement.AllProducts)
                if (!this.GetCategoryName().Contains(product.ProductCategory))
                    _categories.Add(new Category(product.ProductCategory));
        }

        // 取得所有類別
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
            
        }

        // 新增類別
        public void AddCategory(Category category)
        {
            _categories.Add(category);
            if (_addNewCategory != null)
                this._addNewCategory(); // 如果有新增類別 發出訊號
        }

        // 取得所有類別名稱
        public List<String> GetCategoryName()
        {
            List<String> category = new List<string>();
            foreach (Category c in Categories)
                if (!category.Contains(c.CategoryName))
                    category.Add(c.CategoryName);
            return category;
        }

        // 取得類別的總頁數
        public int GetTotalPage(int categoryIndex)
        {
            float quantity = this.GetCurrentCategoryProduct(categoryIndex).Count;
            int totalPage = (int)(Math.Ceiling(quantity / 6.0F));
            return totalPage > 0 ? totalPage : 1;
        }

        // 取得目前類別的所有商品
        public List<Product> GetCurrentCategoryProduct(int categoryIndex)
        {
            List<Product> currentCategoryProduct = new List<Product>();
            foreach (Product product in _productManagement.AllProducts)
                if (product.ProductCategory == Categories[categoryIndex].CategoryName)
                    currentCategoryProduct.Add(product);
            return currentCategoryProduct;
        }

        // 取得目前類別的所有商品名稱
        public List<String> GetCurrentCategoryProductName(int categoryIndex)
        {
            List<String> currentCategoryProductName = new List<String>();
            foreach (Product product in _productManagement.AllProducts)
                if (product.ProductCategory == Categories[categoryIndex].CategoryName)
                    currentCategoryProductName.Add(product.ProductName);
            return currentCategoryProductName;
        }

        // 查看類別是否存在
        public bool ExistCategory(string categoryName)
        {
            foreach (Category category in _categories)
                if (category.CategoryName == categoryName)
                    return true;
            return false;
        }

        // 取得最新的類別
        public Category GetLatestCategory()
        {
            return _categories[_categories.Count - 1];
        }
    }
}
