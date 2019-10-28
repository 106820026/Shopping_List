using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class InventorySystemPresentationModel
    {
        Initial _initial;
        const String PICTURE_KEY = "picture";

        public InventorySystemPresentationModel(Initial initial)
        {
            this._initial = initial;
        }

        // 取得所有商品詳細資料
        public List<String[]> GetAllItemDetail()
        {
            return _initial.GetAllItemList();
        }

        // 取得所有Section的集合
        public StringCollection GetAllSelection()
        {
            return _initial.GetAllSections();
        }

        // 取得圖片
        public Image GetImageFilePath(int index)
        {
            return Image.FromFile(_initial.Read(this.GetAllSelection()[index], PICTURE_KEY));
        }

        // 取得詳細資訊
        public String GetItemDetail(int index)
        {
            return _initial.GetDescription(this.GetAllSelection()[index]);
        }

        // 開啟補貨頁面
        public void OpenReplenishmentPage(int index)
        {
            Replenishment replenishment = new Replenishment(index, _initial);
            replenishment.ShowDialog();
        }

        // 用Section取得RowIndex
        public int GetRowIndexBySection(String section)
        {
            for (int i = 0; i < this.GetAllSelection().Count; i++)
                if (this.GetAllSelection()[i] == section)
                    return i;
            return 0;
        }

        // 取得庫存量
        public String GetStock(String section)
        {
            return _initial.GetStock(section);
        }

        // 取得名稱
        public String GetName(String section)
        {
            return _initial.GetName(section);
        }

        // 取得類別
        public String GetType(String section)
        {
            return _initial.GetType(section);
        }

        // 取得價錢
        public String GetPrice(String section)
        {
            return _initial.GetPrice(section);
        }
    }
}
