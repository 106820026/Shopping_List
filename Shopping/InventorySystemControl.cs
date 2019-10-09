using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList
{
    class InventorySystemControl
    {
        Initial _initial = new Initial(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";
        const String PICTURE_KEY = "picture";

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
            Replenishment _replenishment = new Replenishment(index);
            _replenishment.ShowDialog();
        }
    }
}
