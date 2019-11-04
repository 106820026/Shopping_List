using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class ProductManagementSystemPresentationModel
    {
        #region Member Data
        CategoryManagement _productTypeManagement;
        ProductManagement _productManagement;
        const String DESTINATION = "../../Resources/";
        bool _nameValid = false;
        bool _priceValid = false;
        bool _typeValid = false;
        bool _pathValid = false;
        const int DELETE_BUTTON = 8;
        const int NAME_INDEX = 0;
        const int PRICE_INDEX = 1;
        const int CATEGORY_INDEX = 2;
        const int PATH_INDEX = 3;
        const int DETAIL_INDEX = 4;
        #endregion

        public ProductManagementSystemPresentationModel(CategoryManagement productTypeManagement, ProductManagement productManagement)
        {
            _productTypeManagement = productTypeManagement;
            _productManagement = productManagement;
        }

        // 名字是否為空
        public void ConfirmName(String text)
        {
            _nameValid = text == "" ? false : true;
        }

        // 限制輸入只能數字
        public bool InputOnlyNumber(char inputChar)
        {
            if ((!char.IsDigit(inputChar) && inputChar != DELETE_BUTTON)) //輸入非數字
                return true;
            return false;
        }

        // 價錢是否正確
        public void ConfirmPrice(String text)
        {
            if (text == "" || int.Parse(text) == 0)
                _priceValid = false;
            else
                _priceValid = true;
        }

        // 是否有選擇類別
        public void ConfirmType(int index)
        {
            _typeValid = index == -1 ? false : true;
        }

        // 是否有圖片路徑
        public void ConfirmPath(String text)
        {
            _pathValid = text == "" ? false : true;
        }

        // 是否可按下儲存
        public bool ConfirmSaveButton()
        {
            if (_nameValid == true && _priceValid == true && _typeValid == true && _pathValid == true)
                return true;
            return false;
        }

        // 修改商品
        public void ModifyProduct(int rowIndex, String[] content)
        {
            List<Product> products = _productManagement.GetAllProducts();
            content[PATH_INDEX] = this.CopyFileToResources(content[PATH_INDEX]);
            _productManagement.EditProductName(products[rowIndex], content[NAME_INDEX]);
            _productManagement.EditProductPrice(products[rowIndex], content[PRICE_INDEX]);
            _productManagement.EditProductCategory(products[rowIndex], content[CATEGORY_INDEX]);
            _productManagement.EditProductPicturePath(products[rowIndex], content[PATH_INDEX]);
            _productManagement.EditProductDetail(products[rowIndex], content[DETAIL_INDEX]);
        }

        // 把選取的相片存到內部資料夾
        public String CopyFileToResources(String filePath)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            try
            {
                file.CopyTo(DESTINATION + file.Name);
            }
            catch (IOException ex)
            {
                ex.GetType();
            }
            return DESTINATION + file.Name;
        }

        // 新增商品
        public void AddNewProduct(String[] content)
        {
            _productManagement.AddNewProduct(content);
        }
    }
}
