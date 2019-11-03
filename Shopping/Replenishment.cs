﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    public partial class Replenishment : Form
    {
        ReplenishmentPresentationModel _replenishmentControl;
        ProductManagement _productManagement;
        StringCollection _sectionList = new StringCollection();
        private int _rowIndex;

        public Replenishment(int rowCount, ProductManagement productManagement)
        {
            InitializeComponent();
            this._productManagement = productManagement;
            _confirmButton.Enabled = false;
            _replenishmentControl = new ReplenishmentPresentationModel(_productManagement);
            _rowIndex = rowCount; // 取得按下的行數
            this.ShowDialogInformation();
        }

        /// 顯示視窗資訊
        void ShowDialogInformation()
        {
            _itemNameLabel.Text = _productManagement.GetAllProducts()[_rowIndex].ProductName;
            _itemTypeLabel.Text = _productManagement.GetAllProducts()[_rowIndex].ProductCategory;
            _itemPriceLabel.Text = _productManagement.GetAllProducts()[_rowIndex].ProductPrice;
            _itemStockLabel.Text = _productManagement.GetAllProducts()[_rowIndex].ProductQuantity;
        }

        /// 關閉視窗
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }

        /// 確認確認按鈕
        private void ConfirmConfirmButton(object sender, EventArgs e)
        {
            TextBox textBox;
            textBox = (TextBox)sender;
            _confirmButton.Enabled = _replenishmentControl.IsZero(_replenishmentTextBox.Text);
            _replenishmentControl.GetReplenishmentNumber(_replenishmentTextBox.Text);
        }

        /// 只能輸入數字
        private void InputOnlyNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = _replenishmentControl.InputOnlyNumber(e.KeyChar);
        }

        /// 按下確認按鈕
        private void ClickConfirmButton(object sender, EventArgs e)
        {
            _replenishmentControl.UpdateQuantity(_rowIndex);
            this.Close();
        }
    }
}
