using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    class ShopListControl
    {
        readonly Initial _initialFile = new Initial(FILE_PATH);
        AddToCart _cart = new AddToCart();

        const String FILE_PATH = "../../Data Info.ini";
        const String MODEL_KEY = "model";
        const String SEPARATE_LINE = "\n----------------------------------------------\n"; // 我是分隔線
        const String DETAIL_KEY = "detail";
        const String TYPE_KEY = "type";
        const String PRICE_KEY = "price";
        const String PAGE = "page";
        const String FORMAT = "#, 0";
        const String DELETE_COLUMN = "_delete";
        const String NEXT_PAGE_BUTTON = "_nextPageButton";
        const String LAST_PAGE_BUTTON = "_lastPageButton";
        const String FIRST_PAGE = "1";
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int FIVE = 5;
        // current page
        int _motherBoardCurrentPage = 1;
        int _centralProcessUnitCurrentPage = 1;
        int _diskCurrentPage = 1;
        int _memoryCurrentPage = 1;
        int _graphicsProcessUnitCurrentPage = 1;
        int _computerCurrentPage = 1;
        int[] _allCurrentPage;
        // total page
        int _motherBoardTotalPage = TWO;
        int _centralProcessUnitTotalPage = TWO;
        int _diskTotalPage = TWO;
        int _memoryTotalPage = TWO;
        int _graphicsProcessUnitTotalPage = TWO;
        int _computerTotalPage = TWO;
        int[] _allTotalPage;
        // tab Index
        const int MOTHER_BOARD = 0;
        const int CENTRAL_PROCESS_UNIT = 1;
        const int DISK = TWO;
        const int MEMORY = THREE;
        const int GRAPHICS_PROCESS_UNIT = FOUR;
        const int COMPUTER = FIVE;

        String _currentItemName;

        public ShopListControl()
        {
            _allCurrentPage = new int[] { _motherBoardCurrentPage, _centralProcessUnitCurrentPage, _diskCurrentPage, _memoryCurrentPage, _graphicsProcessUnitCurrentPage, _computerCurrentPage };
            _allTotalPage = new int[] { _motherBoardTotalPage, _centralProcessUnitTotalPage, _diskTotalPage, _memoryTotalPage, _graphicsProcessUnitTotalPage, _computerTotalPage };
        }

        // 取得商品名稱
        public void GetCurrentItemName(Control button, TabControl tabControl)
        {
            _currentItemName = button.Name + PAGE + this.ShowCurrentPage(tabControl);
        }

        // 顯示商品詳細資訊
        public String GetDetail()
        {
            return _initialFile.Read(_currentItemName, MODEL_KEY) + SEPARATE_LINE + _initialFile.Read(_currentItemName, DETAIL_KEY);
        }

        // 顯示目前頁數
        public String ShowCurrentPage(TabControl tabControl)
        {
            return _allCurrentPage[tabControl.SelectedIndex].ToString();
        }

        // 顯示總頁數
        public String ShowTotalPage(TabControl tabControl)
        {
            return _allTotalPage[tabControl.SelectedIndex].ToString();
        }

        // 加入商品至購物車
        public void AddItemToCart()
        {
            _cart.AddItem(_currentItemName);
        }

        // 顯示購物車商品至表格
        public void ShowCartItem(DataGridView dataGridView)
        {
            dataGridView.Rows.Add(String.Empty, _initialFile.Read(_currentItemName, MODEL_KEY), _initialFile.Read(_currentItemName, TYPE_KEY), this.ShowPrice());
        }

        // 顯示商品價錢
        public String ShowPrice()
        {
            if (_initialFile.Read(_currentItemName, PRICE_KEY) != String.Empty)
                return int.Parse(_initialFile.Read(_currentItemName, PRICE_KEY)).ToString(FORMAT);
            else
                return String.Empty;
        }

        // 顯示總價錢
        public String GetTotalPrice()
        {
            return _cart.GetTotalPrice().ToString(FORMAT);
        }

        // 加上Delete按鈕Icon
        public void AddDeleteButtonIcon(DataGridView dataGridView, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (dataGridView.Columns[e.ColumnIndex].Name == DELETE_COLUMN)
            {
                const int LEFT_OFFSET = 17;
                const int TOP_OFFSET = 3;
                const int PICTURE_SIZE = 20;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                // DrawImage(圖片, x軸, y軸, 長, 寬)
                e.Graphics.DrawImage(global::ShopList.Properties.Resources._deleteIcon, e.CellBounds.Left + LEFT_OFFSET, e.CellBounds.Top + TOP_OFFSET, PICTURE_SIZE, PICTURE_SIZE);
                e.Handled = true;//false的話 圖片不穩定
            }
        }

        // 刪除購物車商品
        public void DeleteCartItem(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;

            if (dataGridView.Columns[e.ColumnIndex].Name == DELETE_COLUMN)
            {
                dataGridView.Rows.Remove(dataGridView.Rows[e.RowIndex]);
                _cart.DeleteItem(e.RowIndex);
            }
        }

        // 翻頁
        public void ChangePage(String itemName, TabControl tabControl)
        {
            if (itemName == NEXT_PAGE_BUTTON)
                _allCurrentPage[tabControl.SelectedIndex] += 1; // 頁數+1
            if (itemName == LAST_PAGE_BUTTON)
                _allCurrentPage[tabControl.SelectedIndex] -= 1; // 頁數-1
        }

        // 確認換頁按鈕是否可以按下
        public void CheckChangePageButton(Button nextPageButton, Button lastPageButton, TabControl tabControl)
        {
            nextPageButton.Enabled = lastPageButton.Enabled = true;
            if (this.ShowCurrentPage(tabControl) == FIRST_PAGE)
                lastPageButton.Enabled = false; // 禁用上一頁按鈕
            if (this.ShowCurrentPage(tabControl) == this.ShowTotalPage(tabControl))
                nextPageButton.Enabled = false;// 禁用下一頁按鈕
        }

        // 確認圖片路徑存在
        public void ConfirmPictureExist(Control button, String filePath)
        {
            if (File.Exists(filePath))
            {
                button.BackgroundImage = Image.FromFile(filePath);
                button.Enabled = true;
            }
            else
            {
                button.BackgroundImage = null;
                button.Enabled = false;
            }
        }

        // 確認訂購按鈕可以按下
        public void CheckConfirmButton(int rowCount, Button orderButton)
        {
            if (rowCount == 0)
                orderButton.Enabled = false;
            else
                orderButton.Enabled = true;
        }
    }
}
