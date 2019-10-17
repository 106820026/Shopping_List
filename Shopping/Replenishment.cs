using System;
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
        Initial _initial;
        ReplenishmentPresentationModel _replenishmentControl;
        StringCollection _sectionList = new StringCollection();
        const String FILE_PATH = "../../Data Info.ini";
        const String MODEL_KEY = "model";
        const String TYPE_KEY = "type";
        const String PRICE_KEY = "price";
        const String STOCK_KEY = "stock";
        private int _rowCount;

        public Replenishment(int rowCount, Initial initial)
        {
            InitializeComponent();
            this._initial = initial;
            _replenishmentControl = new ReplenishmentPresentationModel(_initial);
            _sectionList = _initial.GetAllSections(); // 取得Section列表
            _rowCount = rowCount; // 取得按下的行數
            this.ShowDialogInformation();
        }

        // 顯示視窗資訊
        void ShowDialogInformation()
        {
            _itemNameLabel.Text = _initial.Read(_sectionList[_rowCount], MODEL_KEY);
            _itemTypeLabel.Text = _initial.Read(_sectionList[_rowCount], TYPE_KEY);
            _itemPriceLabel.Text = _initial.Read(_sectionList[_rowCount], PRICE_KEY);
            _itemStockLabel.Text = _initial.Read(_sectionList[_rowCount], STOCK_KEY);
        }
        
        // 關閉視窗
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }

        // 確認確認按鈕
        private void ConfirmConfirmButton(object sender, EventArgs e)
        {
            TextBox textBox;
            textBox = (TextBox)sender;
            _confirmButton.Enabled = _replenishmentControl.IsZero(_replenishmentTextBox.Text);
            _replenishmentControl.GetReplenishmentNumber(_replenishmentTextBox.Text);
        }

        // 只能輸入數字
        private void InputOnlyNumber(object sender, KeyPressEventArgs e)
        {
            e.Handled = _replenishmentControl.InputOnlyNumber(e.KeyChar);
        }

        // 按下確認按鈕
        private void ClickConfirmButton(object sender, EventArgs e)
        {
            _replenishmentControl.UpdateStockNumber(_sectionList[_rowCount]);
            this.Close();
        }
    }
}
