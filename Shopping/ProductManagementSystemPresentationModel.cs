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
        Initial _initial;
        ProductTypeManagement _productTypeManagement;
        const String ZERO = "0";
        const String MODEL = "model";
        const String PRICE = "price";
        const String TYPE = "type";
        const String PATH = "picture";
        const String DETAIL = "detail";
        const String STOCK = "stock";
        const String DESTINATION = "../../Resources/";
        String[] _keys = { MODEL, PRICE, TYPE, PATH, DETAIL};
        bool _nameValid = false;
        bool _priceValid = false;
        bool _typeValid = false;
        bool _pathValid = false;
        const int DELETE_BUTTON = 8;
        const int NAME_INDEX = 0;
        const int PRICE_INDEX = 1;
        const int TYPE_INDEX = 2;
        const int PATH_INDEX = 3;
        const int DETAIL_INDEX = 4;
        #endregion

        public ProductManagementSystemPresentationModel(Initial initial, ProductTypeManagement productTypeManagement)
        {
            _initial = initial;
            _productTypeManagement = productTypeManagement;
        }

        // 設定類別的comboBox
        public  List<String> GetTypes()
        {
            return _initial.GetAllType();
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
        public void ModifyItem(int itemIndex, String[] content)
        {
            String section = _initial.GetAllSections()[itemIndex];
            content[3] = this.CopyFileToResources(content[3]);
            for (int i = 0; i < content.Length; i++)
                _initial.Write(section, _keys[i], content[i]);
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

            }
            return DESTINATION + file.Name;
        }

        // 新增商品
        public void AddNewItem(String[] content)
        {
            _initial.Write(content[NAME_INDEX], MODEL, content[NAME_INDEX]);
            _initial.Write(content[NAME_INDEX], TYPE, content[TYPE_INDEX]);
            _initial.Write(content[NAME_INDEX], DETAIL, content[DETAIL_INDEX]);
            _initial.Write(content[NAME_INDEX], PRICE, content[PRICE_INDEX]);
            _initial.Write(content[NAME_INDEX], STOCK, ZERO);
            _initial.Write(content[NAME_INDEX], PATH, content[PATH_INDEX]);
        }
    }
}
