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
        const String FILE_PATH = "../../Data Info.ini";
        const String FORMAT = "#, 0";
        readonly Initial _initialFile = new Initial(FILE_PATH);
        AddToCart _cart = new AddToCart();
        PageManagement _pages = new PageManagement();
        String _currentItemName;
        // ini key
        const String MODEL_KEY = "model";
        const String DETAIL_KEY = "detail";
        const String PRICE_KEY = "price";
        const String TYPE_KEY = "type";

        public ShopList()
        {
            InitializeComponent();
            _addToCartButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
            _orderDataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(DataGridViewCellPainting);
            _orderDataGridView.CellClick += new DataGridViewCellEventHandler(DataGridViewCellClick);
            // 初始化頁數
            _currentPageLabel.Text = _pages.GetCurrentPage(_itemTabControl.TabIndex).ToString();
            _totalPageLabel.Text = _pages.GetTotalPage(_itemTabControl.TabIndex).ToString();
            _lastPageButton.Enabled = false;
        }

        // 處理所有商品點擊事件
        private void ButtonClick(object sender, EventArgs e)
        {
            _addToCartButton.Enabled = true; // 啟用按鍵

            const String SEPARATE_LINE = "\n----------------------------------------------\n"; // 我是分隔線
            _descriptionRichTextBox.ResetText(); // 清除目前字串

            Button button; // 取得商品物件
            button = (Button)sender;
            _currentItemName = button.Name; // 取得目前商品id

            _descriptionRichTextBox.AppendText(_initialFile.Read(button.Name, MODEL_KEY) + SEPARATE_LINE + _initialFile.Read(button.Name, DETAIL_KEY));
            _priceLabel.Text = GetPrice();
        }

        // 按下加入購物車
        private void AddToCartButtonClick(object sender, EventArgs e)
        {
            _cart.AddItem(_currentItemName);
            _orderDataGridView.Rows.Add(String.Empty, _initialFile.Read(_currentItemName, MODEL_KEY), _initialFile.Read(_currentItemName, TYPE_KEY), GetPrice());
            _totalPriceLabel.Text = _cart.GetTotalPrice().ToString(FORMAT);
        }

        // 幫button加icon
        void DataGridViewCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;

            if (_orderDataGridView.Columns[e.ColumnIndex].Name == "_delete")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                //DrawImage(圖片, x軸, y軸, 長, 寬)
                e.Graphics.DrawImage(global::ShopList.Properties.Resources._deleteIcon, e.CellBounds.Left + 17, e.CellBounds.Top + 3, 20, 20);
                e.Handled = true;//false的話 圖片不穩定
            }
        }

        // 刪除購物車內容
        void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;

            if (_orderDataGridView.Columns[e.ColumnIndex].Name == "_delete")
            {
                _orderDataGridView.Rows.Remove(_orderDataGridView.Rows[e.RowIndex]);
                _cart.DeleteItem(e.RowIndex);
                _totalPriceLabel.Text = _cart.GetTotalPrice().ToString(FORMAT);
            }
        }

        // 取得格式化價錢
        private String GetPrice()
        {
            return int.Parse(_initialFile.Read(_currentItemName, PRICE_KEY)).ToString(FORMAT);
        }

        // 設定頁數 & 切換Tab時 詳細資料空白
        private void TabIndexChange(object sender, EventArgs e)
        {   
            _descriptionRichTextBox.ResetText(); // 清除目前字串
            _priceLabel.ResetText(); // 清除目前字串
            _addToCartButton.Enabled = false; // 尚未選擇任何商品 按鍵無效

            String FIRST_PAGE = "1";
            _currentPageLabel.Text = _pages.GetCurrentPage(_itemTabControl.SelectedIndex).ToString(); // 取得目前頁數
            _totalPageLabel.Text = _pages.GetTotalPage(_itemTabControl.SelectedIndex).ToString(); // 取得總頁數

            _nextPageButton.Enabled = true;
            _lastPageButton.Enabled = true;
            if (_currentPageLabel.Text == FIRST_PAGE)
                _lastPageButton.Enabled = false;
            if(_currentPageLabel.Text == _totalPageLabel.Text)
                _nextPageButton.Enabled = false;
        }
    }
}
