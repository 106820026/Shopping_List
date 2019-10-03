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
        String _currentTabName;
        ShopListControl _shopListControl = new ShopListControl();
        TableLayoutPanel[] _tabTableLayoutPanel;
        CreditCardPayment _creditCardPayment = new CreditCardPayment();

        public ShopList()
        {
            InitializeComponent();
            _addToCartButton.Enabled = _orderButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
            // 初始化頁數
            _currentPageLabel.Text = _shopListControl.ShowCurrentPage(_itemTabControl);
            _totalPageLabel.Text = _shopListControl.ShowTotalPage(_itemTabControl);
            _currentTabName = _itemTabControl.SelectedTab.Name;
            _lastPageButton.Enabled = false;
            // 為了取得每頁的按鈕
            _tabTableLayoutPanel = new TableLayoutPanel[] { _motherBoardTableLayoutPanel, _centralProcessUnitTableLayoutPanel, _memoryTableLayoutPanel, _diskTableLayoutPanel, _graphicsProcessUnitTableLayoutPanel, _computerTableLayoutPanel };
        }

        // 處理所有商品點擊事件
        private void ButtonClick(object sender, EventArgs e)
        {
            _addToCartButton.Enabled = true; // 啟用按鍵
            _descriptionRichTextBox.ResetText(); // 清除目前字串

            Button button; // 取得商品物件
            button = (Button)sender;
            _shopListControl.GetCurrentItemName(button, _itemTabControl); // 取得目前商品id
            _descriptionRichTextBox.Text = _shopListControl.GetDetail();
            _priceLabel.Text = _shopListControl.ShowPrice();
        }

        // 按下加入購物車
        private void AddToCartButtonClick(object sender, EventArgs e)
        {
            _shopListControl.AddItemToCart();
            _shopListControl.ShowCartItem(_orderDataGridView);
            _totalPriceLabel.Text = _shopListControl.GetTotalPrice();
            _shopListControl.CheckConfirmButton(_orderDataGridView.Rows.Count, _orderButton); // 確認訂購按鈕可以按下
        }

        // 幫button加icon
        void PaintDataGridViewCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            _shopListControl.AddDeleteButtonIcon(_orderDataGridView, e);
        }

        // 刪除購物車內容
        void ClickDataGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            _shopListControl.DeleteCartItem(_orderDataGridView, e);
            _totalPriceLabel.Text = _shopListControl.GetTotalPrice();
            _shopListControl.CheckConfirmButton(_orderDataGridView.Rows.Count, _orderButton); // 確認訂購按鈕可以按下
        }

        // 設定頁數 & 切換Tab時 詳細資料空白
        private void ChangeTabIndex(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            _addToCartButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
            _currentTabName = _itemTabControl.SelectedTab.Name; // 取得目前tab的id
            
            _currentPageLabel.Text = _shopListControl.ShowCurrentPage(_itemTabControl); // 取得目前頁數
            _totalPageLabel.Text = _shopListControl.ShowTotalPage(_itemTabControl); // 取得總頁數
            _shopListControl.CheckChangePageButton(_nextPageButton, _lastPageButton, _itemTabControl); // 確認換頁按鈕
        }

        // 換頁
        private void ClickChangePageButton(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            Button button; // 取得商品物件
            button = (Button)sender;

            _shopListControl.ChangePage(button.Name, _itemTabControl);
            _currentPageLabel.Text = _shopListControl.ShowCurrentPage(_itemTabControl); // 顯示目前頁數
            SetPicture();
            _shopListControl.CheckChangePageButton(_nextPageButton, _lastPageButton, _itemTabControl); // 確認換頁按鈕
        }

        // 詳細資訊清除
        private void CleanDetail()
        {
            _descriptionRichTextBox.ResetText();
            _priceLabel.ResetText();
        }

        // 設定按鈕圖片
        private void SetPicture()
        {
            foreach (Control button in _tabTableLayoutPanel[_itemTabControl.SelectedIndex].Controls)
            {
                String _filePath = FOLDER + _currentTabName + PAGE + _currentPageLabel.Text.ToString() + ITEM + button.Tag.ToString() + ATTACHMENT_NAME;
                _shopListControl.ConfirmPictureExist(button, _filePath);
            }
        }

        // 點選訂購
        private void ClickOrderButton(object sender, EventArgs e)
        {
            _creditCardPayment.ShowDialog();
        }
    }
}
