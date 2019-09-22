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
    }
}
