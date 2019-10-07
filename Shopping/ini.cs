using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class Initial
    {
        private string _filePath;
        const String MODEL_KEY = "model";
        const String SEPARATE_LINE = "\n----------------------------------------------\n"; // 我是分隔線
        const String DETAIL_KEY = "detail";
        const String TYPE_KEY = "type";
        const String PRICE_KEY = "price";

        // 我也不知道這在幹嘛
        [DllImport("kernel32")]

        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        // 我也不知道這在幹嘛
        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section, string key, string definition, StringBuilder value, int size, string filePath);

        // 讀取檔案位置
        public Initial(string filePath)
        {
            this._filePath = filePath;
        }

        // 寫入檔案
        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value.ToLower(), this._filePath);
        }

        // 讀取檔案
        public string Read(string section, string key)
        {
            const int CAPACITY = 255;
            StringBuilder stringBuilder = new StringBuilder(CAPACITY);
            int length = GetPrivateProfileString(section, key, "", stringBuilder, CAPACITY, this._filePath);
            return stringBuilder.ToString();
        }

        // 檔案位置
        public string FilePath
        {
            get
            {
                return this._filePath;
            }
            set
            {
                this._filePath = value;
            }
        }

        // 格式化商品資訊
        public String GetDescription(String currentItemName)
        {
            return this.Read(currentItemName, MODEL_KEY) + SEPARATE_LINE + this.Read(currentItemName, DETAIL_KEY);
        }

        // 格式化表格資訊
        public String[] GetItemRow(String currentItemName)
        {
            return new string[] { String.Empty, this.Read(currentItemName, MODEL_KEY), this.Read(currentItemName, TYPE_KEY), this.Read(currentItemName, PRICE_KEY) };
        }
    }
}
