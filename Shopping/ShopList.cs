using ShopList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    public partial class ShopList : Form
    {
        // ini file
        readonly Initial _initialFile = new Initial(FILE_PATH);
        const String FILE_PATH = "../../Data Info.ini";
        const String FORMAT = "#, 0";
        // ini key
        const String MODEL_KEY = "model";
        const String DETAIL_KEY = "detail";
        const String PRICE_KEY = "price";
        const String TYPE_KEY = "type";
        const String DELETE_COLUMN = "_delete";
        AddToCart _cart = new AddToCart();
        PageManagement _pages = new PageManagement();
        String _currentItemName;
        String _currentTabName;
        TableLayoutPanel[] _tabTableLayoutPanel;

        public ShopList()
        {
            InitializeComponent();
            _addToCartButton.Enabled = _orderButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
            // 初始化頁數
            _currentPageLabel.Text = _pages.GetCurrentPage(_itemTabControl.TabIndex).ToString();
            _totalPageLabel.Text = _pages.GetTotalPage(_itemTabControl.TabIndex).ToString();
            _currentTabName = _itemTabControl.SelectedTab.Name;
            _lastPageButton.Enabled = false;
            // 為了取得每頁的按鈕
            _tabTableLayoutPanel = new TableLayoutPanel[] { _motherBoardTableLayoutPanel, _centralProcessUnitTableLayoutPanel, _diskTableLayoutPanel, _memoryTableLayoutPanel, _graphicsProcessUnitTableLayoutPanel, _computerTableLayoutPanel };
        }

        // 處理所有商品點擊事件
        private void ButtonClick(object sender, EventArgs e)
        {
            const String PAGE = "page";
            _addToCartButton.Enabled = true; // 啟用按鍵

            const String SEPARATE_LINE = "\n----------------------------------------------\n"; // 我是分隔線
            _descriptionRichTextBox.ResetText(); // 清除目前字串

            Button button; // 取得商品物件
            button = (Button)sender;
            _currentItemName = button.Name + PAGE + _pages.GetCurrentPage(_itemTabControl.SelectedIndex); // 取得目前商品id
            if (_initialFile.Read(_currentItemName, MODEL_KEY) != String.Empty) // 如果找的到ini檔的話
                _descriptionRichTextBox.AppendText(_initialFile.Read(_currentItemName, MODEL_KEY) + SEPARATE_LINE + _initialFile.Read(_currentItemName, DETAIL_KEY));
            else
                _addToCartButton.Enabled = false;
            _priceLabel.Text = GetPrice();
        }

        // 按下加入購物車
        private void AddToCartButtonClick(object sender, EventArgs e)
        {
            _cart.AddItem(_currentItemName);
            _orderDataGridView.Rows.Add(String.Empty, _initialFile.Read(_currentItemName, MODEL_KEY), _initialFile.Read(_currentItemName, TYPE_KEY), GetPrice());
            _totalPriceLabel.Text = _cart.GetTotalPrice().ToString(FORMAT);
            CheckConfirmButton();
        }

        // 幫button加icon
        void PaintDataGridViewCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (_orderDataGridView.Columns[e.ColumnIndex].Name == DELETE_COLUMN)
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

        // 刪除購物車內容
        void ClickDataGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;

            if (_orderDataGridView.Columns[e.ColumnIndex].Name == DELETE_COLUMN)
            {
                _orderDataGridView.Rows.Remove(_orderDataGridView.Rows[e.RowIndex]);
                _cart.DeleteItem(e.RowIndex);
                _totalPriceLabel.Text = _cart.GetTotalPrice().ToString(FORMAT);
                CheckConfirmButton();
            }
        }

        // 取得格式化價錢
        private String GetPrice()
        {
            if (_initialFile.Read(_currentItemName, PRICE_KEY) != String.Empty)
                return int.Parse(_initialFile.Read(_currentItemName, PRICE_KEY)).ToString(FORMAT);
            else
                return String.Empty;
        }

        // 設定頁數 & 切換Tab時 詳細資料空白
        private void ChangeTabIndex(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            _addToCartButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
            _currentTabName = _itemTabControl.SelectedTab.Name; // 取得目前tab的id
            
            _currentPageLabel.Text = _pages.GetCurrentPage(_itemTabControl.SelectedIndex).ToString(); // 取得目前頁數
            _totalPageLabel.Text = _pages.GetTotalPage(_itemTabControl.SelectedIndex).ToString(); // 取得總頁數
            CheckChangePageButton();
        }

        // 確認換頁按鈕是否可以按下
        private void CheckChangePageButton()
        {
            const String FIRST_PAGE = "1";
            _nextPageButton.Enabled = _lastPageButton.Enabled = true;
            if (_currentPageLabel.Text == FIRST_PAGE)
                _lastPageButton.Enabled = false; // 禁用上一頁按鈕
            if (_currentPageLabel.Text == _totalPageLabel.Text)
                _nextPageButton.Enabled = false;// 禁用下一頁按鈕
        }

        // 換頁
        private void ClickChangePageButton(object sender, EventArgs e)
        {
            const String NEXT_PAGE_BUTTON = "_nextPageButton";
            const String LAST_PAGE_BUTTON = "_lastPageButton";

            this.CleanDetail(); // 清除物品詳細資料
            Button button; // 取得商品物件
            button = (Button)sender;

            if (button.Name == NEXT_PAGE_BUTTON)
                _pages.SwitchPage(_itemTabControl.SelectedIndex, 1); // 頁數+1
            if (button.Name == LAST_PAGE_BUTTON)
                _pages.SwitchPage(_itemTabControl.SelectedIndex, -1); // 頁數-1
                
            _currentPageLabel.Text = _pages.GetCurrentPage(_itemTabControl.SelectedIndex).ToString(); // 顯示目前頁數
            CheckChangePageButton(); // 確認換頁按鈕
        }

        // 詳細資訊清除
        private void CleanDetail()
        {
            _descriptionRichTextBox.ResetText();
            _priceLabel.ResetText();
        }

        // 設定按鈕圖片
        private void SetPicture(int currentTabIndex)
        {
            foreach (Control button in _tabTableLayoutPanel[currentTabIndex].Controls)
            {
                Image i = Image.FromFile("../../Resource/"+"");
                //button.BackgroundImage = global::ShopList.Properties.Resources.
                System.Diagnostics.Debug.Print(button.Name.ToString());
            }
        }

        // 點選訂購
        private void ClickOrderButton(object sender, EventArgs e)
        {
            CreditCardPayment _creditCardPayment = new CreditCardPayment();
            _creditCardPayment.ShowDialog();
        }

        // 確認訂購按鈕可以按下
        private void CheckConfirmButton()
        {
            if (_orderDataGridView.Rows.Count == 0)
                _orderButton.Enabled = false;
            else
                _orderButton.Enabled = true;
        }
    }
}
