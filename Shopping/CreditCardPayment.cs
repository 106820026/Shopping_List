using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    public partial class CreditCardPayment : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        CreditCardPaymentControl _creditCardPaymentControl = new CreditCardPaymentControl();

        public CreditCardPayment()
        {
            InitializeComponent();
            _monthComboBox.SelectedIndex = 0;
            _yearComboBox.SelectedIndex = 0;
            _confirmButton.Enabled = false;
        }

        // 名字只能輸入無數字字串
        private void NoNumberString(object sender, KeyPressEventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.ConfirmName(_textBox.Name, _textBox.TextLength, e);
            ShowError(_textBox);
        }

        // 地址只能輸入字串
        private void OnlyString(object sender, KeyPressEventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.ConfirmAddress(_textBox.TextLength, e);
            ShowError(_textBox);
        }

        // 只能輸入數字
        private void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.InputOnlyNumber(_textBox.Name, _textBox.TextLength, e);
            ShowError(_textBox);
        }

        // 信箱格式確認
        private void MailValidator(object sender, KeyPressEventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.ConfirmMailFormat(_textBox.Text);
            ShowError(_textBox);
        }

        // 不能為空字串
        private void IsEmpty(object sender, EventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.CheckNoEmpty(_textBox.Name, _textBox.Text);
            ShowError(_textBox);
        }

        // 字數不夠
        private void NotEnoughWords(object sender, EventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.LackNumber(_textBox.Name, _textBox.TextLength);
            ShowError(_textBox);
        }

        // 確認資料完整性
        private void CheckDataComplete(object sender, EventArgs e)
        {
            _confirmButton.Enabled = _creditCardPaymentControl.ConfirmAll();
        }

        // 按下確認按鈕
        private void _clickConfirmButton(object sender, EventArgs e)
        {
            MessageBox.Show("訂購完成");
            _backNumberTextBox.ResetText();
            this.Close();
        }

        // 顯示錯誤訊息
        private void ShowError(Object control)
        {
            errorProvider.SetError((Control)control, _creditCardPaymentControl.ErrorMessage());
        }
    }
}
