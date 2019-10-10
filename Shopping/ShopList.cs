using ShopList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ShopList
{
    public partial class ShopList : Form
    {
        const String FOLDER = "../../Resources/";
        const String PAGE = "Page";
        const String ITEM = "Item";
        const String ATTACHMENT_NAME = ".jpg";
        const String DELETE_COLUMN = "_delete";
        const String NUMBER_COLUMN = "_number";
        const String FORMAT = "#, 0";
        const int NUMBER_COLUMN_INDEX = 4;
        const int SUBPRICE_COLUMN_INDEX = 5;
        String _currentTabName;
        TableLayoutPanel[] _tabTableLayoutPanel;
        ShopListControl _shopListControl = new ShopListControl();
        CreditCardPayment _creditCardPayment = new CreditCardPayment();

        public ShopList()
        {
            InitializeComponent();
            _addToCartButton.Enabled = _orderButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
            // 初始化頁數和換頁按鈕
            _currentPageLabel.Text = _shopListControl.GetCurrentPage();
            _totalPageLabel.Text = _shopListControl.GetTotalPage();
            this.CheckChangePageButton();
            _tabTableLayoutPanel = new TableLayoutPanel[] { _motherBoardTableLayoutPanel, _centralProcessUnitTableLayoutPanel, _memoryTableLayoutPanel, _diskTableLayoutPanel, _graphicsProcessUnitTableLayoutPanel, _computerTableLayoutPanel };
            _shopListControl.SetCurrentTabIndex(_itemTabControl.SelectedIndex); // 目前Tab頁數
            _shopListControl.SetRowCount(_orderDataGridView.RowCount); // 購物車商品數量
        }

        // 處理所有商品點擊事件
        private void ButtonClick(object sender, EventArgs e)
        {
            _addToCartButton.Enabled = true; // 啟用按鍵

            Button button; // 取得商品物件
            button = (Button)sender;
            this.UpdateItemClick(button);
        }

        // 按下加入購物車
        private void AddToCartButtonClick(object sender, EventArgs e)
        {
            _shopListControl.AddItemToCart(); // 加入購物車
            this.UpdateAddToCart(); // 更新顯示
        }

        // 幫button加icon
        void PaintDataGridViewCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (senderGrid.Columns[e.ColumnIndex].Name == DELETE_COLUMN)
            {
                const int LEFT_OFFSET = 15;
                const int TOP_OFFSET = 3;
                const int PICTURE_SIZE = 20;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                // DrawImage(圖片, x軸, y軸, 長, 寬)
                e.Graphics.DrawImage(global::ShopList.Properties.Resources._deleteIcon, e.CellBounds.Left + LEFT_OFFSET, e.CellBounds.Top + TOP_OFFSET, PICTURE_SIZE, PICTURE_SIZE);
                e.Handled = true;//false的話 圖片不穩定
            }
        }

        // 點選DataGridView內容
        void ClickDataGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (senderGrid.Columns[e.ColumnIndex].Name == DELETE_COLUMN) // 點選刪除
            {
                _orderDataGridView.Rows.Remove(_orderDataGridView.Rows[e.RowIndex]);
                _shopListControl.DeleteCartItem(e.RowIndex);
                _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT); // 顯示總價錢
                this.CleanDetail();
            }
            _shopListControl.SetRowCount(_orderDataGridView.RowCount); // 取得目前購物車商品數量
            _orderButton.Enabled = _shopListControl.CheckConfirmButton(); // 確認訂購按鈕可以按下
        }

        // 設定頁數 & 切換Tab時 詳細資料空白
        private void ChangeTabIndex(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            _currentTabName = _itemTabControl.SelectedTab.Name; // 取得目前tab的id
            _shopListControl.SetCurrentTabIndex(_itemTabControl.SelectedIndex);
            _currentPageLabel.Text = _shopListControl.GetCurrentPage(); // 取得目前頁數
            _totalPageLabel.Text = _shopListControl.GetTotalPage(); // 取得總頁數
            this.CheckChangePageButton(); // 確認換頁按鈕
            _shopListControl.SetCurrentTabIndex(_itemTabControl.SelectedIndex);
        }

        // 換頁
        private void ClickChangePageButton(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            Button button; // 取得商品物件
            button = (Button)sender;

            _shopListControl.ChangePage(button.Name);
            _currentPageLabel.Text = _shopListControl.GetCurrentPage(); // 顯示目前頁數
            _currentTabName = _itemTabControl.SelectedTab.Name;
            this.SetPicture(); //  換圖片
            this.CheckChangePageButton(); // 確認換頁按鈕
        }

        // 確認換頁按鈕是否可以按下
        public void CheckChangePageButton()
        {
            _nextPageButton.Enabled = _lastPageButton.Enabled = true;
            _lastPageButton.Enabled = !_shopListControl.IsFirstPage(); // 禁(啟)用上一頁按鈕
            _nextPageButton.Enabled = !_shopListControl.IsLastPage();// 禁(啟)用下一頁按鈕
        }

        // 詳細資訊清除
        private void CleanDetail()
        {
            _descriptionRichTextBox.ResetText(); // 清除詳細資訊欄位
            _stockLabel.ResetText(); // 清除庫存
            _priceLabel.ResetText(); // 清除價錢
            _addToCartButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
        }

        // 設定按鈕圖片
        private void SetPicture()
        {
            foreach (Control button in _tabTableLayoutPanel[_itemTabControl.SelectedIndex].Controls)
            {
                String _filePath = FOLDER + _currentTabName + PAGE + _currentPageLabel.Text.ToString() + ITEM + button.Tag.ToString() + ATTACHMENT_NAME;
                if (File.Exists(_filePath))
                {
                    button.BackgroundImage = Image.FromFile(_filePath);
                    ChangeButtonStatus(button, true);
                }
                else
                {
                    button.BackgroundImage = null;
                    ChangeButtonStatus(button, false);
                }
            }
        }

        // 點選訂購
        private void ClickOrderButton(object sender, EventArgs e)
        {
            if (_creditCardPayment.ShowDialog() == DialogResult.OK)
            {
                _orderDataGridView.Rows.Clear(); // 清空右邊欄位
                _totalPriceLabel.ResetText(); // 清空總金額
                _shopListControl.ResetCart(_orderDataGridView.Rows.Count); // 清空購物車
                _orderButton.Enabled = _shopListControl.CheckConfirmButton(); // 訂購按鈕不能再按下
                this.CleanDetail();
            }
        }

        //按下加入購物車後更新視窗
        private void UpdateAddToCart()
        {
            _addToCartButton.Enabled = false;
            _orderDataGridView.Rows.Add(_shopListControl.GetCartItem()); // 顯示物品到右邊表格
            _shopListControl.SetRowCount(_orderDataGridView.RowCount); // 取得目前購物車商品數量
            _orderButton.Enabled = _shopListControl.CheckConfirmButton(); // 確認訂購按鈕可以按下
            _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT); // 顯示總價錢
        }

        // 選取商品後更新視窗
        private void UpdateItemClick(Button button)
        {
            _shopListControl.GetCurrentItemName(button.Name); // 取得目前商品id
            _descriptionRichTextBox.Text = _shopListControl.GetDetail(); // 顯示商品詳細資料
            _stockLabel.Text = _shopListControl.GetStock(); // 顯示庫存
            _priceLabel.Text = _shopListControl.GetPrice(); // 顯示價錢
            _addToCartButton.Enabled = _shopListControl.IsAlreadyInCart(); // 如已加入購物車 就不可再次加入
        }

        // 設定商品按鈕狀態
        private void ChangeButtonStatus(Control button, bool flag)
        {
            ((Button)button).Enabled = flag;
            ((Button)button).Visible = flag;
        }

        // 更改單一商品總價錢
        private void UpdateSubPrice(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex].Name == NUMBER_COLUMN) // 增加數量
            {
                _orderDataGridView.Rows[e.RowIndex].Cells[SUBPRICE_COLUMN_INDEX].Value = _shopListControl.GetSubprice(int.Parse(_orderDataGridView.CurrentCell.Value.ToString()), e.RowIndex).ToString(FORMAT);
                if (_shopListControl.OutOfStock(e.RowIndex, int.Parse(_orderDataGridView.CurrentCell.Value.ToString()))) // 如果庫存不足
                    _orderDataGridView.CurrentCell.Value = _shopListControl.GetStockNumber(e.RowIndex); //值設定成庫存量
                _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT);
            }
        }

        // 取得總價錢
        private int GetTotalPrice()
        {
            int totalPrice = 0;
            for (int i = 0; i < _orderDataGridView.RowCount; i++)
            {
                totalPrice += _shopListControl.GetSubprice(int.Parse(_orderDataGridView.Rows[i].Cells[NUMBER_COLUMN_INDEX].Value.ToString()), i);
            }
            return totalPrice;
        }
    }
}