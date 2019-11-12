using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    public partial class ProductManagementSystem : Form
    {
        #region Member Data
        ProductManagementSystemPresentationModel _productManagementSystemPresentationModel;
        CategoryManagement _categoryManagement;
        ProductManagement _productManagement;
        OpenFileDialog _openFileDialog = new OpenFileDialog();
        int _currentItemIndex; //目前選取item的Index
        int _currentCategoryIndex; //目前選取category的Index
        bool _editItemMode = false;
        bool _addItemMode = false;
        bool _addCategoryMode = false;
        List<String> _emptyList = new List<String>(); // 空List
        const String OPEN = "開啟";
        const String FILE_FORMAT = "圖片格式(*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp";
        const String EDIT_ITEM = "編輯商品";
        const String ADD_ITEM = "新增商品";
        const String SAVE_ITEM = "儲存";
        const String ADD_NEW_ITEM = "新增";
        const String CATEGORY = "類別";
        const String ADD_NEW_CATEGORY = "新增類別";
        const String FORMAT = "#,0";
        const int CATEGORY_INDEX = 2;
        #endregion

        public ProductManagementSystem(ReadFile initial, CategoryManagement categoryManagement, ProductManagement productManagement)
        {
            InitializeComponent();
            _categoryManagement = categoryManagement;
            _productManagement = productManagement;
            _productManagement._writeNewData += UpdateListBox;
            _categoryManagement._addNewCategory += UpdateComboBoxSelection;
            _productManagementSystemPresentationModel = new ProductManagementSystemPresentationModel(_categoryManagement, _productManagement);
            this.InitialForm();
            this.InitialListBox();
        }

        // 初始化視窗
        private void InitialForm()
        {
            this.InitialComboBox();
            _saveItemButton.Enabled = false;
        }

        // 初始化ComboBox選項
        private void InitialComboBox()
        {
            _itemCategoryComboBox.DataSource = _categoryManagement.GetCategoryName();
            _itemCategoryComboBox.SelectedIndex = -1;
        }

        // 點擊ListBox,顯示右方詳細資訊
        private void GetItemDetail(object sender, EventArgs e)
        {
            _currentItemIndex = ((ListBox)sender).SelectedIndex;
            ShowItemDetails(_currentItemIndex);
            _saveItemButton.Enabled = false;
            _addNewItemButton.Enabled = true;
            _categoryNameTextBox.Enabled = false;
            this.SetEditAndAddMode(true, false);
            this.EnableEditItem(true);
        }

        // 在ListBox中顯示所有商品名稱
        public void InitialListBox()
        {
            foreach (Product product in _productManagement.AllProducts)
                _itemsListBox.Items.Add(product.ProductName);
            foreach (Category category in _categoryManagement.Categories)
                _categoryListBox.Items.Add(category.CategoryName);
        }

        // 顯示所有詳細資訊
        private void ShowItemDetails(int index)
        {
            _itemNameTextBox.Text = _itemsListBox.SelectedItem.ToString();
            _itemPriceTextBox.Text = _productManagement.AllProducts[index].ProductPrice;
            _itemPicturePathTextBox.Text = _productManagement.AllProducts[index].ProductPicturePath;
            _itemDescriptionTextBox.Text = _productManagement.AllProducts[index].ProductDetail;
            _itemCategoryComboBox.Text = _productManagement.AllProducts[index].ProductCategory;
        }

        // 編輯名稱
        private void EditName(object sender, KeyEventArgs e)
        {
            this.CheckAllItemInput();
        }

        // 限制輸入只能數字
        private void InputOnlyNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = _productManagementSystemPresentationModel.InputOnlyNumber(e.KeyChar);
        }

        // 編輯價錢
        private void EditPrice(object sender, KeyEventArgs e)
        {
            this.CheckAllItemInput();
        }

        // 編輯型態
        private void EditType(object sender, EventArgs e)
        {
            this.CheckAllItemInput();
        }

        // 編輯圖片路徑(手動輸入)
        private void EditPath(object sender, KeyEventArgs e)
        {
            this.CheckAllItemInput();
        }

        // 編輯詳細資料
        private void EditDetail(object sender, KeyEventArgs e)
        {
            this.CheckAllItemInput();
        }

        // 開啟編輯
        private void EnableEditItem(bool flag)
        {
            _itemNameTextBox.Enabled = flag;
            _itemPriceTextBox.Enabled = flag;
            _itemCategoryComboBox.Enabled = flag;
            _itemPicturePathTextBox.Enabled = flag;
            _itemDescriptionTextBox.Enabled = flag;
            _searchButton.Enabled = flag;
        }

        // 檢查所有欄位
        private void CheckAllItemInput()
        {
            if (_editItemMode && _saveItemButton.Enabled == false)
                _saveItemButton.Enabled = true;
            else
            {
                _productManagementSystemPresentationModel.ConfirmName(_itemNameTextBox.Text);
                _productManagementSystemPresentationModel.ConfirmPrice(_itemPriceTextBox.Text);
                _productManagementSystemPresentationModel.ConfirmType(_itemCategoryComboBox.SelectedIndex);
                _productManagementSystemPresentationModel.ConfirmPath(_itemPicturePathTextBox.Text);
                _saveItemButton.Enabled = _productManagementSystemPresentationModel.ConfirmSaveButton();
            }
        }

        // 設定狀態
        private void SetEditAndAddMode(bool flag1, bool flag2)
        {
            _editItemMode = flag1;
            _addItemMode = flag2;
            if (flag1 == true)
            {
                _titleGroupBox.Text = EDIT_ITEM;
                _saveItemButton.Text = SAVE_ITEM;
            }
            else
            {
                _titleGroupBox.Text = ADD_ITEM;
                _saveItemButton.Text = ADD_NEW_ITEM;
            }
        }

        // 按下瀏覽按鈕
        private void ClickSearchButton(object sender, EventArgs e)
        {
            this.ShowPicturePathDialog();
        }

        // 顯示選取圖片dialog
        private void ShowPicturePathDialog()
        {
            _openFileDialog.Title = OPEN;
            _openFileDialog.Filter = FILE_FORMAT;
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _itemPicturePathTextBox.Text = _openFileDialog.FileName;
                this.CheckAllItemInput();
            }
        }

        // 新增商品
        private void ClickAddNewItemButton(object sender, EventArgs e)
        {
            this.SetEditAndAddMode(false, true);
            this.CleanAllItemDetail();
            this.EnableEditItem(true);
            _saveItemButton.Enabled = false;
            _addNewItemButton.Enabled = false;
        }

        // 清除所有欄位
        private void CleanAllItemDetail()
        {
            _itemNameTextBox.Text = "";
            _itemPriceTextBox.Text = "";
            _itemPicturePathTextBox.Text = "";
            _itemDescriptionTextBox.Text = "";
            _itemCategoryComboBox.SelectedIndex = -1;
        }

        // 按下新增或修改按鈕
        private void ClickSaveButton(object sender, EventArgs e)
        {
            _saveItemButton.Enabled = false;
            if (_editItemMode) // 修改
                _productManagementSystemPresentationModel.ModifyProduct(_currentItemIndex, this.GetAllInput());
            if (_addItemMode) // 新增
            {
                _productManagementSystemPresentationModel.AddNewProduct(this.GetAllInput());
                ClearAll();
            }
        }

        // 清除所有可輸入欄位
        private void ClearAll()
        {
            _itemNameTextBox.ResetText();
            _itemPriceTextBox.ResetText();
            _itemPicturePathTextBox.ResetText();
            _itemDescriptionTextBox.ResetText();
            _itemCategoryComboBox.SelectedIndex = -1;
        }

        // 取得所有修改或新增的資料
        private String[] GetAllInput()
        {
            String[] content = new String[] { _itemNameTextBox.Text, int.Parse(_itemPriceTextBox.Text).ToString(), _itemCategoryComboBox.Text, _itemPicturePathTextBox.Text, _itemDescriptionTextBox.Text }; //儲存所有輸入的資料
            return content;
        }

        // 更新儲存完的ListBox
        private void UpdateListBox()
        {
            if (_editItemMode) // 修改
            {
                _itemsListBox.Items[_currentItemIndex] = _itemNameTextBox.Text;
                _productOfCategoryListBox.DataSource = _productManagementSystemPresentationModel.GetProductOfCategory(_currentCategoryIndex);
            }  
            else if (_addItemMode) // 新增
            {
                _itemsListBox.Items.Add(_productManagement.GetLatestProduct().ProductName);
                _productOfCategoryListBox.DataSource = _productManagementSystemPresentationModel.GetProductOfCategory(_currentCategoryIndex);
            }
        }

        // 解除event
        private void CancelEvent(object sender, FormClosedEventArgs e)
        {
            _productManagement._writeNewData -= UpdateListBox;
            this.Dispose();
        }

        // 按下新增類別按鈕
        private void ClickAddNewCategoryButton(object sender, EventArgs e)
        {
            this.EnableEditCategory(true);
            this.CleanCategoryDetail();
        }

        // 清除類別頁面
        private void CleanCategoryDetail()
        {
            _productOfCategoryListBox.Items.Clear();
        }

        // 顯示該類別詳細資訊
        private void ShowCategoryDetail(object sender, MouseEventArgs e)
        {
            this.EnableEditCategory(false);
            _categoryGroupBox.Text = CATEGORY;
            _currentCategoryIndex = ((ListBox)sender).SelectedIndex;
            _categoryNameTextBox.Text = _itemCategoryComboBox.Items[_currentCategoryIndex].ToString();
            _productOfCategoryListBox.DataSource = _productManagementSystemPresentationModel.GetProductOfCategory(_currentCategoryIndex);
        }

        // 可以編輯類別
        private void EnableEditCategory(bool flag)
        {
            _addCategoryMode = flag;
            _categoryNameTextBox.Enabled = flag;
            _addNewCategoryButton.Enabled = !flag;
            _categoryGroupBox.Text = ADD_NEW_CATEGORY;
        }

        // 確認創建類型名稱是否正確
        private void EditCategoryName(object sender, KeyEventArgs e)
        {
            if (_productManagementSystemPresentationModel.ConfirmCategoryName(_categoryNameTextBox.Text))
                _saveCategoryButton.Enabled = true;
            else 
                _saveCategoryButton.Enabled = false;
        }

        // 名稱不能輸入數字
        private void InputNoNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = _productManagementSystemPresentationModel.InputNoNumber(e.KeyChar);
        }

        // 按下新增種類按鈕
        private void ClickSaveCategoryButton(object sender, EventArgs e)
        {
            _productManagementSystemPresentationModel.AddNewCategory(_categoryNameTextBox.Text);
            _categoryListBox.Items.Add(_categoryNameTextBox.Text);
            _saveCategoryButton.Enabled = false;
            _categoryNameTextBox.Text = "";
        }

        // 更新ComboBox的選項
        private void UpdateComboBoxSelection()
        {
            int index = _itemCategoryComboBox.SelectedIndex;
            _itemCategoryComboBox.DataSource = _categoryManagement.GetCategoryName();
            _itemCategoryComboBox.SelectedIndex = index;
        }
    }
}
