﻿using ShopList;
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
        Initial _initialFile = new Initial(FILE_PATH);
        AddToCart _cart = new AddToCart();
        String _currentItemName;
        /*// current page
        int _motherBoardCurrentPage = 1;
        int _centralProcessUnitCurrentPage = 1;
        int _diskCurrentPage = 1;
        int _memoryCurrentPage = 1;
        int _graphicsProcessUnitCurrentPage = 1;
        int _computerCurrentPage = 1;
        // total page
        int _motherBoardTotalPage = 1;
        int _centralProcessUnitTotalPage = 1;
        int _diskTotalPage = 1;
        int _memoryTotalPage = 1;
        int _graphicsProcessUnitTotalPage = 1;
        int _computerTotalPage = 1;*/
        // ini data
        const String MODEL_KEY = "model";
        const String DETAIL_KEY = "detail";
        const String PRICE_KEY = "price";
        const String TYPE_KEY = "type";

        public ShopList()
        {
            InitializeComponent();
            _addToCartButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
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
            _cart.AddItem(_currentItemName, int.Parse(_initialFile.Read(_currentItemName, PRICE_KEY)));
            _orderDataGridView.Rows.Add("", _initialFile.Read(_currentItemName, MODEL_KEY), _initialFile.Read(_currentItemName, TYPE_KEY), GetPrice());
            _totalPriceLabel.Text = _cart.GetTotalPrice().ToString(FORMAT);
        }

        //  切換Tab時 詳細資料空白
        private void ChangeTab(object sender, EventArgs e)
        {
            _descriptionRichTextBox.ResetText(); // 清除目前字串
            _priceLabel.ResetText(); // 清除目前字串
            _addToCartButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
        }

        // 取得格式化價錢
        private String GetPrice()
        {
            return int.Parse(_initialFile.Read(_currentItemName, PRICE_KEY)).ToString(FORMAT);
        }
    }
}
