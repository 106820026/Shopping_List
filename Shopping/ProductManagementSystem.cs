﻿using System;
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
        Initial _initial;
        ProductManagementSystemPresentationModel _productManagementSystemPresentationModel = new ProductManagementSystemPresentationModel();
        OpenFileDialog _openFileDialog = new OpenFileDialog();
        List<String> _allSectionList = new List<string>();
        int _currentItemIndex; //目前選取item的Index
        bool _editMode = false;
        bool _addMode = false;
        const String OPEN = "開啟";
        const String FILE_FORMAT = "圖片格式(*.jpg,*.gif,*.bmp)|*.jpg;*.gif;*.bmp";

        public ProductManagementSystem(Initial initial)
        {
            InitializeComponent();
            _initial = initial;
            this.InitialForm();
            this.ShowAllItemNames();
        }

        // 初始化視窗
        private void InitialForm()
        {
            _allSectionList = _initial.GetAllSections().Cast<String>().ToList(); // 取得所有商品Section的List
            _saveButton.Enabled = false;
        }

        // 點擊ListBox,顯示右方詳細資訊
        private void GetItemDetail(object sender, EventArgs e)
        {
            _currentItemIndex = ((ListBox)sender).SelectedIndex;
            ShowAllDetails(_currentItemIndex);
            _saveButton.Enabled = false;
            this.SetEditMode(true);
            this.EnableEdit(true);
        }

        // 在ListBox中顯示所有商品名稱
        public void ShowAllItemNames()
        {
            foreach (String section in _allSectionList)
                _itemsListBox.Items.Add(_initial.GetName(section));
        }

        // 顯示所有詳細資訊
        private void ShowAllDetails(int index)
        {
            _itemNameTextBox.Text = _itemsListBox.SelectedItem.ToString();
            _itemPriceTextBox.Text = _initial.GetPrice(_allSectionList[index]);
            _itemPicturePathTextBox.Text = _initial.GetPicturePath(_allSectionList[index]);
            _itemDescriptionTextBox.Text = _initial.GetDetail(_allSectionList[index]);
            _itemCategoryComboBox.SelectedIndex = _productManagementSystemPresentationModel.GetItemType(_initial.GetType(_allSectionList[index]));
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
        private void SetEditMode(bool flag)
        {
            _editMode = flag;
            _addMode = !flag;
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
                this.CheckAllInput();
                _itemPicturePathTextBox.Text = _openFileDialog.FileName.Replace(Directory.GetCurrentDirectory(), "");// ToString();
            }
        }

        // 新增商品
        private void ClickAddNewItemButton(object sender, EventArgs e)
        {
            this.SetEditMode(false);
            this.CleanAllDetail();
            this.EnableEdit(true);
            _saveButton.Enabled = false;
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
    }
}
