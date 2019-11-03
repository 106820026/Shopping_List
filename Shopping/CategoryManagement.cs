using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    public class CategoryManagement
    {
        ProductManagement _productManagement;
        List<Category> _categories = new List<Category>();

        public CategoryManagement(ProductManagement productManagement)
        {
            _productManagement = productManagement;
            this.InitialCategories();
        }

        /// 存所有類別(只有在有新增類別的時候才要重call)
        public void InitialCategories()
        {
            _categories.Clear();
            foreach (Product product in _productManagement.GetAllProducts())
                if (!this.GetCategoryName().Contains(product.ProductCategory))
                    _categories.Add(new Category(product.ProductCategory));
        }

        /// 取得所有類別
        public List<Category> GetCategories()
        {
            return _categories;
        }

        /// 取得所有類別名稱
        public List<String> GetCategoryName()
        {
            List<String> category = new List<string>();
            foreach (Category c in this.GetCategories())
                if (!category.Contains(c.CategoryName))
                    category.Add(c.CategoryName);
            return category;
        }

        /// 取得類別的總頁數
        public int GetTotalPage(String category)
        {
            float quantity = this.GetCurrentCategoryProduct(category).Count;
            return (int)(Math.Ceiling(quantity / 6.0F));
        }

        /// 取得目前類別的所有商品
        public List<Product> GetCurrentCategoryProduct(String category)
        {
            List<Product> currentCategoryProduct = new List<Product>();
            foreach (Product product in _productManagement.GetAllProducts())
                if (product.ProductCategory == category)
                    currentCategoryProduct.Add(product);
            return currentCategoryProduct;
        }
    }
}
