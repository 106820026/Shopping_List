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
        #region Member Data
        const String FOLDER = "../../Resources/";
        const String PAGE = "Page";
        const String ITEM = "Item";
        const String ATTACHMENT_NAME = ".jpg";
        const String DELETE_COLUMN = "_delete";
        const String NUMBER_COLUMN = "_number";
        const String FORMAT = "#, 0";
        const String OUT_OF_STOCK = "庫存不足";
        const String STOCK_STATUS = "庫存狀態";
        const int NUMBER_COLUMN_INDEX = 4;
        const int SUBTOTAL_COLUMN_INDEX = 5;
        String _currentTabName;
        Initial _initial;
        TableLayoutPanel[] _tabTableLayoutPanel;
        ShopListPresentationModel _shopListControl;
        CreditCardPayment _creditCardPayment = new CreditCardPayment();
        #endregion

        public ShopList(Initial initial)
        {
            InitializeComponent();
            this._initial = initial;
            _shopListControl = new ShopListPresentationModel(_initial);
            _initial._writeNewData += UpdateStock;
            this.InitialForm();
        }

        // 初始化視窗
        private void InitialForm()
        {
            this.CheckChangePageButton();
            this.ShowCurrentAndTotalPage();
            _addToCartButton.Enabled = _orderButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
            _tabTableLayoutPanel = new TableLayoutPanel[] { _motherBoardTableLayoutPanel, _centralProcessUnitTableLayoutPanel, _memoryTableLayoutPanel, _diskTableLayoutPanel, _graphicsProcessUnitTableLayoutPanel, _computerTableLayoutPanel };
            this.GetCurrentTabIndex(); // 目前Tab頁數
            _shopListControl.SetRowCount(_orderDataGridView.RowCount); // 購物車商品數量
            _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT); //顯示總價錢
        }

        // 處理所有商品點擊事件
        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender; // 取得商品物件
            _addToCartButton.Enabled = true; // 啟用按鍵
            this.UpdateItemClick(button);
        }

        // 按下加入購物車
        private void AddToCartButtonClick(object sender, EventArgs e)
        {
            this.UpdateAddToCart(); // 更新顯示
        }

        // 幫button加垃圾桶icon 
        void PaintDataGridViewCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == DELETE_COLUMN)
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
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == DELETE_COLUMN) // 點選刪除
            {
                this.DeleteItem(e);
                this.ShowTotalPrice();
                this.CleanDetail();
            }
            _shopListControl.SetRowCount(_orderDataGridView.RowCount); // 取得目前購物車商品數量
            _orderButton.Enabled = _shopListControl.CheckConfirmButton(); // 確認訂購按鈕可以按下
        }

        // 設定頁數 & 切換Tab時 詳細資料空白
        private void ChangeTabIndex(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            this.GetCurrentTabName();
            this.GetCurrentTabIndex();
            this.ShowCurrentAndTotalPage();
            this.CheckChangePageButton(); // 確認換頁按鈕
            this.GetCurrentTabIndex();
        }

        // 換頁
        private void ClickChangePageButton(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            Button button = (Button)sender; // 取得商品物件

            _shopListControl.ChangePage(button.Name);
            this.ShowCurrentAndTotalPage();
            this.GetCurrentTabName();
            this.SetPicture(); //  換圖片
            this.CheckChangePageButton(); // 確認換頁按鈕
        }

        // 點選訂購
        private void ClickOrderButton(object sender, EventArgs e)
        {
            if (_creditCardPayment.ShowDialog() == DialogResult.OK)
            {
                this.UpdateInitial();
                this.CleanOrderAndResetButton();
                this.CleanDetail();
            }
        }

        // 更改單一商品總價錢
        private void UpdateSubtotal(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex].Name == NUMBER_COLUMN) // 增減數量
            {
                if (_shopListControl.OutOfStock(e.RowIndex, int.Parse(senderGrid.Rows[e.RowIndex].Cells[NUMBER_COLUMN_INDEX].Value.ToString()))) // 如果庫存不足
                    NotifyOutOfStockAndChangeToMaximumStock(e);
                _orderDataGridView.Rows[e.RowIndex].Cells[SUBTOTAL_COLUMN_INDEX].Value = _shopListControl.GetSubtotal(int.Parse(_orderDataGridView.CurrentCell.Value.ToString()), e.RowIndex).ToString(FORMAT);
                _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT);
            }
        }

        // 解除event
        private void CancelEvent(object sender, FormClosedEventArgs e)
        {
            _initial._writeNewData -= UpdateStock;
            this.Dispose();
        }

        // 補貨時 更新庫存數量(自訂事件)
        private void UpdateStock()
        {
            _stockLabel.Text = _shopListControl.GetStock();
        }

        // 取得目前Tab的name
        private void GetCurrentTabName()
        {
            _currentTabName = _itemTabControl.SelectedTab.Name; // 取得目前tab的id
        }

        // 取得目前Tab的index
        private void GetCurrentTabIndex()
        {
            _shopListControl.SetCurrentTabIndex(_itemTabControl.SelectedIndex); // 目前Tab頁數
        }

        // 顯示目前頁數和總頁數
        private void ShowCurrentAndTotalPage()
        {
            _currentPageLabel.Text = _shopListControl.GetCurrentPage();
            _totalPageLabel.Text = _shopListControl.GetTotalPage();
        }

        // 刪除項目
        private void DeleteItem(DataGridViewCellEventArgs e)
        {
            _orderDataGridView.Rows.Remove(_orderDataGridView.Rows[e.RowIndex]);
            _shopListControl.DeleteCartItem(e.RowIndex);
        }

        //顯示總價錢
        private void ShowTotalPrice()
        {
            _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT); // 顯示總價錢
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

        // 更新ini檔
        private void UpdateInitial()
        {
            _shopListControl.UpdateStockAndWriteInInitial(); // 購買完後更新ini庫存
        }

        // 清空購物車
        private void CleanOrderAndResetButton()
        {
            _orderDataGridView.Rows.Clear(); // 清空右邊欄位
            _totalPriceLabel.ResetText(); // 清空總金額
            _shopListControl.ResetCart(_orderDataGridView.Rows.Count); // 清空購物車List
            _orderButton.Enabled = _shopListControl.CheckConfirmButton(); // 訂購按鈕不能再按下
        }

        //按下加入購物車後更新視窗
        private void UpdateAddToCart()
        {
            _shopListControl.AddItemToCart(); // 加入購物車
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

        // 取得總價錢
        private int GetTotalPrice()
        {
            int totalPrice = 0;
            for (int i = 0; i < _orderDataGridView.RowCount; i++)
                totalPrice += _shopListControl.GetSubtotal(int.Parse(_orderDataGridView.Rows[i].Cells[NUMBER_COLUMN_INDEX].Value.ToString()), i);
            return totalPrice;
        }

        // 提示庫存不足並且改回最大庫存
        private void NotifyOutOfStockAndChangeToMaximumStock(DataGridViewCellEventArgs e)
        {
            MessageBox.Show(OUT_OF_STOCK, STOCK_STATUS);
            _orderDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _shopListControl.ChangeToMaximumStock(e.RowIndex);
        }
    }
}