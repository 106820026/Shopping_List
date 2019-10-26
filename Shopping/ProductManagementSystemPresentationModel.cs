﻿using System;
using System.Collections.Generic;
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
        //const String MOTHER_BOARD = "主機板";
        //const String CENTRAL_PROCESS_UNIT = "CPU";
        //const String MEMORY = "記憶體";
        //const String DISK = "硬碟";
        //const String GRAPHICS_PROCESS_UNIT = "顯卡";
        //const String COMPUTER = "套裝電腦";
        //String[] _types = { MOTHER_BOARD, CENTRAL_PROCESS_UNIT, MEMORY, DISK, GRAPHICS_PROCESS_UNIT, COMPUTER };
        const String MODEL = "model";
        const String PRICE = "price";
        const String TYPE = "type";
        const String PATH = "picture";
        const String DETAIL = "detail";
        String[] _keys = { MODEL, PRICE, TYPE, PATH, DETAIL};
        bool _nameValid = false;
        bool _priceValid = false;
        bool _typeValid = false;
        bool _pathValid = false;
        const int DELETE_BUTTON = 8;
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

        // 回傳商品類別的index
        public int GetItemType(String itemType)
        {
            for (int i = 0; i < this.GetTypes().Count; i++)
                if (itemType == this.GetTypes()[i])
                    return i;
            return 0;
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
            for (int i = 0; i < content.Length; i++)
                _initial.Write(section, _keys[i], content[i]);
        }
    }
}
