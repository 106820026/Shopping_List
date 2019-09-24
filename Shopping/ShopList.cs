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
        Initial _initialFile = new Initial(FILE_PATH);
        AddToCart _cart = new AddToCart();
        Int32 _currentHashCode;
        // current page
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
        int _computerTotalPage = 1;
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
            _currentHashCode = sender.GetHashCode(); // 取得目前Hash Code

            Button button; // 取得商品物件
            button = (Button)sender;

            _descriptionRichTextBox.AppendText(_initialFile.Read(button.Name, MODEL_KEY) + SEPARATE_LINE + _initialFile.Read(button.Name, DETAIL_KEY));
            _priceLabel.Text = _initialFile.Read(button.Name, PRICE_KEY);
            _cart.MakeDictionary(_currentHashCode, button.Name);
        }

        // 按下加入購物車
        private void AddToCartButtonClick(object sender, EventArgs e)
        {
            _cart.AddItem(_currentHashCode, int.Parse(_initialFile.Read(_cart.GetItemCode()[_currentHashCode], PRICE_KEY)));
            _orderDataGridView.Rows.Add("", _initialFile.Read(_cart.GetItemCode()[_currentHashCode], MODEL_KEY), _initialFile.Read(_cart.GetItemCode()[_currentHashCode], TYPE_KEY), _initialFile.Read(_cart.GetItemCode()[_currentHashCode], PRICE_KEY));
            _totalPriceLabel.Text = FormatNumber(_cart.GetTotalPrice());
        }

        //  切換Tab時 詳細資料空白
        private void ChangeTab(object sender, EventArgs e)
        {
            _descriptionRichTextBox.ResetText(); // 清除目前字串
            _addToCartButton.Enabled = false; // 尚未選擇任何商品 按鍵無效
        }

        private String FormatNumber(int price)
        {
            return price.ToString("#,0");
        }
    }
}
