using ShopList.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ShopList.PresentationModel;

namespace ShopList.View
{
    public partial class ShopList : Form
    {
        #region Member Data
        const String FOLDER = "../../Resources/";
        const String ATTACHMENT_NAME = ".jpg";
        const String DELETE_COLUMN = "_delete";
        const String NUMBER_COLUMN = "_number";
        const String FORMAT = "#,0";
        const String OUT_OF_STOCK = "庫存不足";
        const String STOCK_STATUS = "庫存狀態";
        const String NEXT_PAGE_BUTTON = "_nextPageButton";
        const String LAST_PAGE_BUTTON = "_lastPageButton";
        const int NAME_COLUMN_INDEX = 1;
        const int CATEGORY_COLUMN_INDEX = 2;
        const int PRICE_COLUMN_INDEX = 3;
        const int NUMBER_COLUMN_INDEX = 4;
        const int SUBTOTAL_COLUMN_INDEX = 5;
        const int BUTTON_NUMBER = 6;
        ShopListPresentationModel _shopListPresentationModel;
        ItemTabControlPages _itemTabControlPages;
        CreditCardPayment _creditCardPayment = new CreditCardPayment();
        CategoryManagement _categoryManagement;
        ProductManagement _productManagement;
        #endregion

        public ShopList(CategoryManagement productTypeManagement, ProductManagement productManagement)
        {
            InitializeComponent();
            _categoryManagement = productTypeManagement;
            _productManagement = productManagement;
            _itemTabControlPages = new ItemTabControlPages(_itemTabControl, _categoryManagement);
            _shopListPresentationModel = new ShopListPresentationModel(_categoryManagement, _productManagement);
            _productManagement._writeNewData += UpdateProductData;
            _categoryManagement._addNewCategory += AddNewTabPage;
            this.InitialForm();
        }

        // 初始化視窗
        private void InitialForm()
        {
            this.CheckChangePageButton();
            _addToCartButton.Enabled = _orderButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
            this.ShowCurrentAndTotalPage(); // 顯示頁數
            this.ShowItemPicture(); //顯示商品圖片
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
            _orderButton.Enabled = _shopListPresentationModel.CheckConfirmButton(); // 確認訂購按鈕可以按下
        }
        
        // 設定頁數 & 切換Tab時 詳細資料空白
        private void ChangeTabIndex(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            this.ShowCurrentAndTotalPage(); // 顯示頁數
            this.ShowItemPicture(); //顯示商品圖片
            this.CheckChangePageButton(); // 確認換頁按鈕
        }
        
        // 換頁
        private void ClickChangePageButton(object sender, EventArgs e)
        {
            this.CleanDetail(); // 清除物品詳細資料
            Button button = (Button)sender; // 取得商品物件
            this.ChangePage(button.Name);
            this.ShowCurrentAndTotalPage(); // 顯示頁數
            this.ShowItemPicture(); //  換圖片
            this.CheckChangePageButton(); // 確認換頁按鈕
        }

        // 翻頁

        private void ChangePage(String itemName)
        {
            if (itemName == NEXT_PAGE_BUTTON)
                int.Parse(_itemTabControlPages.ChangePage(1));
            if (itemName == LAST_PAGE_BUTTON)
                int.Parse(_itemTabControlPages.ChangePage(-1));

        }

        // 點選訂購
        private void ClickOrderButton(object sender, EventArgs e)
        {
            if (_creditCardPayment.ShowDialog() == DialogResult.OK)
            {
                this.UpdateData();
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
                if (_shopListPresentationModel.OutOfStock(e.RowIndex, int.Parse(senderGrid.Rows[e.RowIndex].Cells[NUMBER_COLUMN_INDEX].Value.ToString()))) // 如果庫存不足
                    NotifyOutOfStockAndChangeToMaximumStock(e);
                _orderDataGridView.Rows[e.RowIndex].Cells[SUBTOTAL_COLUMN_INDEX].Value = _shopListPresentationModel.GetSubtotal(int.Parse(_orderDataGridView.CurrentCell.Value.ToString()), e.RowIndex).ToString(FORMAT);
                _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT);
            }
        }

        // 解除event
        private void CancelEvent(object sender, FormClosedEventArgs e)
        {
            _productManagement._writeNewData -= UpdateProductData;
            this.Dispose();
        }

        // 更新整個頁面
        public void UpdateProductData()
        {
            this.ShowCurrentAndTotalPage(); // 顯示頁數
            this.CleanDetail(); // 清空詳細資料
            this.ShowItemPicture(); //顯示商品圖片
            this.CheckChangePageButton(); // 換頁按鈕
            if (_shopListPresentationModel.IsEditItemInCart()) // 修改已經加入購物車的商品
                this.UpdateCart();
        }

        // 取得購物車內有被修改過商品的rowIndex
        private int GetChangedProductRowIndex()
        {
            return _shopListPresentationModel.GetChangedProductRowIndex();
        }

        // 修改購物車裡面的商品
        private void UpdateCart()
        {
            int rowIndex = this.GetChangedProductRowIndex();
            _orderDataGridView.Rows[rowIndex].Cells[NAME_COLUMN_INDEX].Value = _shopListPresentationModel.GetEditProductName();
            _orderDataGridView.Rows[rowIndex].Cells[CATEGORY_COLUMN_INDEX].Value = _shopListPresentationModel.GetEditProductCategory();
            _orderDataGridView.Rows[rowIndex].Cells[PRICE_COLUMN_INDEX].Value = _shopListPresentationModel.GetEditProductPrice();
            _orderDataGridView.Rows[rowIndex].Cells[SUBTOTAL_COLUMN_INDEX].Value = _shopListPresentationModel.GetSubtotal(int.Parse(_orderDataGridView.Rows[rowIndex].Cells[NUMBER_COLUMN_INDEX].Value.ToString()), rowIndex).ToString(FORMAT);
            _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT);
        }

        // 顯示目前頁數和總頁數
        private void ShowCurrentAndTotalPage()
        {
            _itemTabControlPages.UpdateTotalPage();
            _itemTabControlPages.CurrentTabIndex = _itemTabControl.SelectedIndex; // 取得目前Tab的index
            _currentPageLabel.Text = _itemTabControlPages.GetCurrentPage(); //顯示目前頁數
            _totalPageLabel.Text = _itemTabControlPages.GetTotalPage(); //顯示總頁數
        }

        // 刪除項目
        private void DeleteItem(DataGridViewCellEventArgs e)
        {
            _orderDataGridView.Rows.Remove(_orderDataGridView.Rows[e.RowIndex]);
            _shopListPresentationModel.DeleteCartItem(e.RowIndex);
        }

        // 顯示總價錢
        private void ShowTotalPrice()
        {
            _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT); // 顯示總價錢
        }

        // 確認換頁按鈕是否可以按下
        public void CheckChangePageButton()
        {
            _nextPageButton.Enabled = _lastPageButton.Enabled = true;
            _lastPageButton.Enabled = !this.IsFirstPage(); // 禁(啟)用上一頁按鈕
            _nextPageButton.Enabled = !this.IsLastPage();// 禁(啟)用下一頁按鈕
        }

        // 是否為第一頁
        private bool IsFirstPage()
        {
            return int.Parse(_itemTabControlPages.GetCurrentPage()) == 1;
        }

        // 是否為最後一頁
        private bool IsLastPage()
        {
            return int.Parse(_itemTabControlPages.GetCurrentPage()) == int.Parse(_itemTabControlPages.GetTotalPage());
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
        private void ShowItemPicture()
        {
            int currentTabIndex = _itemTabControl.SelectedIndex; //取得目前tab的index
            List<Product> currentTypeProduct = _categoryManagement.GetCurrentCategoryProduct(currentTabIndex); //取得目前類別的所有商品
            TableLayoutPanel tableLayoutPanel = _itemTabControlPages.GetTableLayoutPanel(currentTabIndex); //取得目前TableLayoutPanel
            int index = BUTTON_NUMBER * (int.Parse(_currentPageLabel.Text) - 1); //取得每個button的index
            foreach (Button button in tableLayoutPanel.Controls)
            {
                if (index < currentTypeProduct.Count)
                {
                    String _filePath = _productManagement.GetProducts(_itemTabControl.SelectedTab.Text)[index].ProductPicturePath;
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.Click += ButtonClick;
                    ChangeButtonStatus(button, true, _filePath);
                }
                else
                    ChangeButtonStatus(button, false, null);
                index++;
            }
        }

        // 更新商品資料
        private void UpdateData()
        {
            _shopListPresentationModel.UpdateProductQuantity();
        }

        // 清空購物車
        private void CleanOrderAndResetButton()
        {
            _orderDataGridView.Rows.Clear(); // 清空右邊欄位
            _totalPriceLabel.ResetText(); // 清空總金額
            _shopListPresentationModel.ResetCart(); // 清空購物車List
            _orderButton.Enabled = _shopListPresentationModel.CheckConfirmButton(); // 訂購按鈕不能再按下
        }

        // 按下加入購物車後更新視窗
        private void UpdateAddToCart()
        {
            _shopListPresentationModel.AddItemToCart(); // 加入購物車
            _addToCartButton.Enabled = false;
            _orderDataGridView.Rows.Add(_shopListPresentationModel.GetCartItem()); // 顯示物品到右邊表格
            _orderButton.Enabled = _shopListPresentationModel.CheckConfirmButton(); // 確認訂購按鈕可以按下
            _totalPriceLabel.Text = this.GetTotalPrice().ToString(FORMAT); // 顯示總價錢
        }

        // 選取商品後更新視窗
        private void UpdateItemClick(Button button)
        {
            _shopListPresentationModel.GetCurrentProduce(_itemTabControlPages.GetCurrentPage(), (int)(button.Tag), _itemTabControl.SelectedTab.Text); // 取得目前商品id
            _descriptionRichTextBox.Text = _shopListPresentationModel.GetDetail(); // 顯示商品詳細資料
            _stockLabel.Text = _shopListPresentationModel.GetQuantity(); // 顯示庫存
            _priceLabel.Text = _shopListPresentationModel.GetPrice(); // 顯示價錢
            _addToCartButton.Enabled = _shopListPresentationModel.IsAlreadyInCart(); // 如已加入購物車 就不可再次加入
        }

        // 設定商品按鈕狀態
        private void ChangeButtonStatus(Control button, bool flag, String filePath)
        {
            const String DEFAULT_PICTURE_PATH = "../../Resources/notFound.jpg";
            ((Button)button).Enabled = flag;
            ((Button)button).Visible = flag;
            if (flag == true)
            {
                try
                {
                    ((Button)button).BackgroundImage = Image.FromFile(filePath);
                }
                catch
                {
                    ((Button)button).BackgroundImage = Image.FromFile(DEFAULT_PICTURE_PATH);
                }
            }
            else
                ((Button)button).BackgroundImage = null;
        }

        // 取得總價錢
        private int GetTotalPrice()
        {
            int totalPrice = 0;
            for (int i = 0; i < _orderDataGridView.RowCount; i++)
                totalPrice += _shopListPresentationModel.GetSubtotal(int.Parse(_orderDataGridView.Rows[i].Cells[NUMBER_COLUMN_INDEX].Value.ToString()), i);
            return totalPrice;
        }

        // 提示庫存不足並且改回最大庫存
        private void NotifyOutOfStockAndChangeToMaximumStock(DataGridViewCellEventArgs e)
        {
            MessageBox.Show(OUT_OF_STOCK, STOCK_STATUS);
            _orderDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _shopListPresentationModel.ChangeToMaximumStock(e.RowIndex);
        }

        // 新增tab page
        private void AddNewTabPage()
        {
            _itemTabControlPages.AddNewTabPage();
        }
    }
}