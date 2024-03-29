﻿using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text;

namespace ShopList.Model
{
    public class ReadFile
    {
        #region Member Data
        //public event WriteNewDataEventHandler _writeNewData;// 自訂事件
        //public delegate void WriteNewDataEventHandler();
        private string _filePath;
        StringCollection _sectionList = new StringCollection();
        //String _changedSection;
        const String SEPARATE_LINE = "\n-----------------------------------\n"; // 我是分隔線
        const String NAME_KEY = "name";
        const String DETAIL_KEY = "detail";
        const String TYPE_KEY = "type";
        const String PRICE_KEY = "price";
        const String STOCK_KEY = "stock";
        const String PICTURE_KEY = "picture";
        const String FORMAT = "#,0";
        const String ONE = "1";
        const int SIZE = 65535;
        const int CAPACITY = 255;

        //聲明讀寫INI文件的API函數
        [DllImport("kernel32")]

        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        //聲明讀寫INI文件的API函數
        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section, string key, string definition, StringBuilder value, int size, string filePath);

        //聲明讀寫INI文件的API函數
        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section, string key, string definition, byte[] returnValue, int size, string filePath);
        #endregion

        // 讀取檔案位置
        public ReadFile(string filePath)
        {
            this._filePath = filePath;
        }

        //// 寫入檔案
        //public void Write(string section, string key, string value)
        //{
        //    WritePrivateProfileString(section, key, value, this._filePath);
        //    _changedSection = section;
        //    if (_writeNewData != null)
        //        this._writeNewData(); // 如果ini檔有變動 發出訊號
        //}

        // 讀取檔案
        public string Read(string section, string key)
        {
            StringBuilder stringBuilder = new StringBuilder(CAPACITY);
            int length = GetPrivateProfileString(section, key, "", stringBuilder, CAPACITY, this._filePath);
            return stringBuilder.ToString();
        }

        #region 讀所有Section的function
        // 從Ini文件中，讀取所有的Sections的名稱
        private void ReadSections(StringCollection sectionList)
        {
            byte[] buffer = new byte[SIZE];
            int bufferLength = 0;
            bufferLength = GetPrivateProfileString(null, null, null, buffer, buffer.GetUpperBound(0), _filePath);
            GetStringsFromBuffer(buffer, bufferLength, sectionList);
        }

        // 對Section進行解析
        private void GetStringsFromBuffer(Byte[] buffer, int bufferLength, StringCollection strings)
        {
            strings.Clear();
            if (bufferLength != 0)
            {
                int start = 0;
                for (int i = 0; i < bufferLength; i++)
                {
                    if ((buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(buffer, start, i - start);
                        strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }
        #endregion
        
        // 回傳所有Section
        public StringCollection GetAllSections()
        {
            this.ReadSections(_sectionList);
            return _sectionList;
        }

        //檔案位置
        //public string FilePath
        //{
        //    get
        //    {
        //        return this._filePath;
        //    }
        //    set
        //    {
        //        this._filePath = value;
        //    }
        //}

        // 取得名稱(用section來取)
        public String GetName(String currentItemName)
        {
            return this.Read(currentItemName, NAME_KEY);
        }

        // 取得詳細資訊(用section來取)
        public String GetDetail(String currentItemName)
        {
            return this.Read(currentItemName, DETAIL_KEY);
        }

        // 取得類別(用section來取)
        public String GetCategory(String currentItemName)
        {
            return this.Read(currentItemName, TYPE_KEY);
        }

        // 取得價格(用section來取)
        public String GetPrice(String currentItemName)
        {
            return this.Read(currentItemName, PRICE_KEY);
        }

        // 取得庫存(用section來取)
        public String GetStock(String currentItemName)
        {
            return this.Read(currentItemName, STOCK_KEY);
        }

        // 取得圖片路徑(用section來取)
        public String GetPicturePath(String currentItemName)
        {
            return this.Read(currentItemName, PICTURE_KEY);
        }

        //// 取得被更改的item的Section
        //public String GetChangeSection()
        //{
        //    return _changedSection;
        //}
    }
}
