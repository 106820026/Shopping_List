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
        ErrorProvider _errorProvider = new ErrorProvider();
        CreditCardPaymentPresentationModel _creditCardPaymentControl = new CreditCardPaymentPresentationModel();
        TextBox _textBox; // 取得商品物件
        const String SUCCESS = "訂購完成";

        public CreditCardPayment()
        {
            InitializeComponent();
            _monthComboBox.SelectedIndex = 0;
            _yearComboBox.SelectedIndex = 0;
            _confirmButton.Enabled = false;
        }

        /// 名字只能輸入無數字字串
        private void InputNoNumberString(object sender, KeyPressEventArgs e)
        {
            _textBox = (TextBox)sender;

            e.Handled = _creditCardPaymentControl.ConfirmName(int.Parse(_textBox.Tag.ToString()), _textBox.TextLength, e.KeyChar);
            ShowError(_textBox);
        }

        /// 地址只能輸入字串
        private void InputOnlyString(object sender, KeyPressEventArgs e)
        {
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.ConfirmAddress(_textBox.TextLength, e.KeyChar);
            ShowError(_textBox);
        }

        /// 只能輸入數字
        private void InputOnlyNumber(object sender, KeyPressEventArgs e)
        {
            _textBox = (TextBox)sender;

            e.Handled = _creditCardPaymentControl.InputOnlyNumber(int.Parse(_textBox.Tag.ToString()), _textBox.TextLength, e.KeyChar);
            ShowError(_textBox);
        }

        /// 信箱格式確認
        private void MailValid(object sender, KeyPressEventArgs e)
        {
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.ConfirmMailFormat(_textBox.Text);
            ShowError(_textBox);
        }

        /// 不能為空字串
        private void IsEmpty(object sender, EventArgs e)
        {
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.CheckNoEmpty(int.Parse(_textBox.Tag.ToString()), _textBox.Text);
            ShowError(_textBox);
        }

        /// 字數不夠
        private void InputNotEnoughWords(object sender, EventArgs e)
        {
            _textBox = (TextBox)sender;

            _creditCardPaymentControl.LackNumber(int.Parse(_textBox.Tag.ToString()), _textBox.TextLength);
            ShowError(_textBox);
        }

        /// 確認資料完整性
        private void CheckDataComplete(object sender, EventArgs e)
        {
            _confirmButton.Enabled = _creditCardPaymentControl.ConfirmAll();
        }

        /// 按下確認按鈕
        private void ClickConfirmButton(object sender, EventArgs e)
        {
            _backNumberTextBox.Text = _creditCardPaymentControl.CleanBackNumber(); // 清除後3碼
            _confirmButton.Enabled = _creditCardPaymentControl.ConfirmAll(); // 重新確認按鈕狀態
            this.DialogResult = DialogResult.OK;
            MessageBox.Show(SUCCESS);
            this.Close();
        }

        /// 顯示錯誤訊息
        private void ShowError(Object control)
        {
            _errorProvider.SetError((Control)control, _creditCardPaymentControl.GetErrorMessage());
        }
    }
}
