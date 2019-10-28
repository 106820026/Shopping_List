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
        Initial _initial;
        ProductManagementSystemPresentationModel _productManagementSystemPresentationModel;
        ProductTypeManagement _productTypeManagement;
        OpenFileDialog _openFileDialog = new OpenFileDialog();
        List<String> _allSection = new List<string>();
        int _currentItemIndex; //目前選取item的Index
        bool _editMode = false;
        bool _addMode = false;
        const String OPEN = "開啟";
        const String FILE_FORMAT = "圖片格式(*.jpg,*.gif,*.bmp)|*.jpg;*.gif;*.bmp";
        const String EDIT_ITEM = "編輯商品";
        const String ADD_ITEM = "新增商品";
        const String SAVE = "儲存";
        const String ADD_NEW = "新增";
        #endregion

        public ProductManagementSystem(Initial initial, ProductTypeManagement productTypeManagement)
        {
            InitializeComponent();
            _initial = initial;
            _initial._writeNewData += UpdateListBox;
            _productTypeManagement = productTypeManagement;
            _productManagementSystemPresentationModel = new ProductManagementSystemPresentationModel(_initial, _productTypeManagement);
            this.InitialForm();
            this.ShowAllItemNames();
        }

        // 初始化視窗
        private void InitialForm()
        {
            this.UpdateSection();
            this.InitialComboBox();
            _saveButton.Enabled = false;
        }

        // 更新目前所有Section
        private void UpdateSection()
        {
            _allSection = _initial.GetAllSections().Cast<String>().ToList(); // 取得所有商品Section的List
        }

        // 初始化ComboBox選項
        private void InitialComboBox()
        {
            List<String> types = _productManagementSystemPresentationModel.GetTypes();
            _itemCategoryComboBox.DataSource = types;
            _itemCategoryComboBox.SelectedIndex = -1;
        }

        // 點擊ListBox,顯示右方詳細資訊
        private void GetItemDetail(object sender, EventArgs e)
        {
            _currentItemIndex = ((ListBox)sender).SelectedIndex;
            ShowAllDetails(_currentItemIndex);
            _saveButton.Enabled = false;
            _addNewItemButton.Enabled = true;
            _titleGroupBox.Text = EDIT_ITEM;
            _saveButton.Text = SAVE;
            this.SetEditAndAddMode(true, false);
            this.EnableEdit(true);
        }

        // 在ListBox中顯示所有商品名稱
        public void ShowAllItemNames()
        {
            foreach (String section in _allSection)
                _itemsListBox.Items.Add(_initial.GetName(section));
        }

        // 顯示所有詳細資訊
        private void ShowAllDetails(int index)
        {
            _itemNameTextBox.Text = _itemsListBox.SelectedItem.ToString();
            _itemPriceTextBox.Text = _initial.GetPrice(_allSection[index]);
            _itemPicturePathTextBox.Text = _initial.GetPicturePath(_allSection[index]);
            _itemDescriptionTextBox.Text = _initial.GetDetail(_allSection[index]);
            _itemCategoryComboBox.Text = _initial.GetType(_allSection[index]);
        }

        // 編輯名稱
        private void EditName(object sender, KeyEventArgs e)
        {
            this.CheckAllInput();
        }

        // 限制輸入只能數字
        private void InputOnlyNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = _productManagementSystemPresentationModel.InputOnlyNumber(e.KeyChar);
        }

        // 編輯價錢
        private void EditPrice(object sender, KeyEventArgs e)
        {
            this.CheckAllInput();
        }

        //編輯型態
        private void EditType(object sender, EventArgs e)
        {
            this.CheckAllInput();
        }

        // 編輯圖片路徑(手動輸入)
        private void EditPath(object sender, KeyEventArgs e)
        {
            this.CheckAllInput();
        }

        // 編輯詳細資料
        private void EditDetail(object sender, KeyEventArgs e)
        {
            this.CheckAllInput();
        }

        // 開啟編輯
        private void EnableEdit(bool flag)
        {
            _itemNameTextBox.Enabled = flag;
            _itemPriceTextBox.Enabled = flag;
            _itemCategoryComboBox.Enabled = flag;
            _itemPicturePathTextBox.Enabled = flag;
            _itemDescriptionTextBox.Enabled = flag;
            _searchButton.Enabled = flag;
        }

        // 檢查所有欄位
        private void CheckAllInput()
        {
            if (_editMode && _saveButton.Enabled == false)
                _saveButton.Enabled = true;
            else
            {
                _productManagementSystemPresentationModel.ConfirmName(_itemNameTextBox.Text);
                _productManagementSystemPresentationModel.ConfirmPrice(_itemPriceTextBox.Text);
                _productManagementSystemPresentationModel.ConfirmType(_itemCategoryComboBox.SelectedIndex);
                _productManagementSystemPresentationModel.ConfirmPath(_itemPicturePathTextBox.Text);
                _saveButton.Enabled = _productManagementSystemPresentationModel.ConfirmSaveButton();
            }
        }

        // 設定狀態
        private void SetEditAndAddMode(bool flag1, bool flag2)
        {
            _editMode = flag1;
            _addMode = flag2;
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
                this.CheckAllInput();
            }
        }

        // 新增商品
        private void ClickAddNewItemButton(object sender, EventArgs e)
        {
            this.SetEditAndAddMode(false, true);
            this.CleanAllDetail();
            this.EnableEdit(true);
            _titleGroupBox.Text = ADD_ITEM;
            _saveButton.Text = ADD_NEW;
            _saveButton.Enabled = false;
            _addNewItemButton.Enabled = false;
        }

        // 清除所有欄位
        private void CleanAllDetail()
        {
            _itemNameTextBox.Text = "";
            _itemPriceTextBox.Text = "";
            _itemPicturePathTextBox.Text = "";
            _itemDescriptionTextBox.Text = "";
            _itemCategoryComboBox.SelectedIndex = -1;
        }

        //按下新增或修改按鈕
        private void ClickSaveButton(object sender, EventArgs e)
        {
            _saveButton.Enabled = false;
            if (_editMode) // 修改
                _productManagementSystemPresentationModel.ModifyItem(_currentItemIndex, this.GetAllInput());
            if(_addMode) // 新增
                _productManagementSystemPresentationModel.AddNewItem(this.GetAllInput());
            this.SetEditAndAddMode(true, false);
        }

        // 取得所有修改或新增的資料
        private String[] GetAllInput()
        {
            String[]  _content = new String[] { _itemNameTextBox.Text, _itemPriceTextBox.Text, _itemCategoryComboBox.Text, _itemPicturePathTextBox.Text, _itemDescriptionTextBox.Text }; //儲存所有輸入的資料
            return _content;
        }

        // 更新儲存完的ListBox
        private void UpdateListBox()
        {
            if (_editMode) // 修改
            {
                _itemsListBox.Items[_currentItemIndex] = String.Empty;
                _itemsListBox.Items[_currentItemIndex] = _itemNameTextBox.Text;
            }
            else if (_addMode) // 新增
            {
                this.UpdateSection();
                _itemsListBox.Items.Insert(0, _initial.GetName(_allSection[_allSection.Count - 1]));
            }
            this.SetEditAndAddMode(false, false);
        }

        // 解除event
        private void CancelEvent(object sender, FormClosedEventArgs e)
        {
            _initial._writeNewData -= UpdateListBox;
            this.Dispose();
        }
    }
}
