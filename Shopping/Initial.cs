using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class Initial
    {
        private string _filePath;
        StringCollection _sectionList = new StringCollection();
        const String MODEL_KEY = "model";
        const String SEPARATE_LINE = "\n-----------------------------------\n"; // 我是分隔線
        const String DETAIL_KEY = "detail";
        const String TYPE_KEY = "type";
        const String PRICE_KEY = "price";
        const String STOCK_KEY = "stock";
        const String FORMAT = "#, 0";
        const String ONE = "1";
        const int SIZE = 65535;
        const int CAPACITY = 255;

        //// 自訂事件
        //public event WriteNewDataEventHandler WriteNewData;
        //public delegate void WriteNewDataEventHandler();
        //public WriteNewDataEventHandler stockAction;

        //聲明讀寫INI文件的API函數
        [DllImport("kernel32")]

        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        //聲明讀寫INI文件的API函數
        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section, string key, string definition, StringBuilder value, int size, string filePath);

        //聲明讀寫INI文件的API函數
        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section, string key, string definition, byte[] returnValue, int size, string filePath);

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

        //// 如果有寫入資料 所有view都要更新
        //private void UpdateView()
        //{
        //    WriteNewData?.Invoke();
        //}

        // 讀取檔案
        public string Read(string section, string key)
        {
            StringBuilder stringBuilder = new StringBuilder(CAPACITY);
            int length = GetPrivateProfileString(section, key, "", stringBuilder, CAPACITY, this._filePath);
            return stringBuilder.ToString();
        }

        //從Ini文件中，讀取所有的Sections的名稱
        public void ReadSections(StringCollection sectionList)
        {
            byte[] buffer = new byte[SIZE];
            int bufferLength = 0;
            bufferLength = GetPrivateProfileString(null, null, null, buffer, buffer.GetUpperBound(0), _filePath);
            GetStringsFromBuffer(buffer, bufferLength, sectionList);
        }

        //對Section進行解析
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

        // 回傳所有Section
        public StringCollection GetAllSections()
        {
            this.ReadSections(_sectionList);
            return _sectionList;
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

        // 取得價格
        public String GetPrice(String currentItemName)
        {
            return this.Read(currentItemName, PRICE_KEY);
        }

        // 取得庫存
        public String GetStock(String currentItemName)
        {
            return this.Read(currentItemName, STOCK_KEY);
        }

        // 格式化商品資訊(_descriptionRichTextBox用)
        public String GetDescription(String currentItemName)
        {
            return this.Read(currentItemName, MODEL_KEY) + SEPARATE_LINE + this.Read(currentItemName, DETAIL_KEY);
        }

        // 格式化表格資訊 (適用於按下addToCart Button)
        public String[] GetOrderItemRow(String currentItemName)
        {
            return new string[] { String.Empty, this.Read(currentItemName, MODEL_KEY), this.Read(currentItemName, TYPE_KEY), int.Parse(this.Read(currentItemName, PRICE_KEY)).ToString(FORMAT), ONE, int.Parse(this.Read(currentItemName, PRICE_KEY)).ToString(FORMAT) };
        }

        // 取得商品所有資訊 (InventorySystem用)
        public List<String[]> GetAllItemList()
        {
            this.ReadSections(_sectionList); // 讀取所有Section
            List<String[]> allInformationList = new List<string[]>();
            foreach (string currentItemName in _sectionList)
                allInformationList.Add( new String[] { this.Read(currentItemName, MODEL_KEY), this.Read(currentItemName, TYPE_KEY), this.Read(currentItemName, PRICE_KEY), this.Read(currentItemName, STOCK_KEY), String.Empty });
            return allInformationList;
        }
    }
}
