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
        bool firstNameValid, lastNameValid, cardNumber1Valid, cardNumber2Valid,
             cardNumber3Valid, cardNumber4Valid, backNumberValid, mailValid, addressValid;

        public CreditCardPayment()
        {
            InitializeComponent();
            _monthComboBox.SelectedIndex = 0;
            _yearComboBox.SelectedIndex = 0;
            firstNameValid = lastNameValid = cardNumber1Valid = cardNumber2Valid = cardNumber3Valid =
            cardNumber4Valid = backNumberValid = mailValid = addressValid = false;
            _confirmButton.Enabled = false;
        }

        // 只能輸入字串
        private void OnlyString(object sender, KeyPressEventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            if(_textBox == _addressTextBox && _textBox.Text != "")
            {
                addressValid = true;
            }
            else if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                e.Handled = true;
                errorProvider.SetError(_textBox, "no number input");
            }
            else
            {
                e.Handled = false;
                errorProvider.Clear();
                if (_textBox == _firstNameTextBox)
                    firstNameValid = true;
                if (_textBox == _lastNameTextBox)
                    lastNameValid = true;
            }
        }

        // 只能輸入數字
        private void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != 8))
            {
                e.Handled = true;
                errorProvider.SetError(_textBox, "only number input");
            }
            else
            {
                e.Handled = false;
                errorProvider.Clear();
                if (_textBox == _cardNumber1textBox)
                    cardNumber1Valid = true;
                if (_textBox == _cardNumber2textBox)
                    cardNumber2Valid = true;
                if (_textBox == _cardNumber3textBox)
                    cardNumber3Valid = true;
                if (_textBox == _cardNumber4textBox)
                    cardNumber4Valid = true;
                if (_textBox == _backNumberTextBox)
                    backNumberValid = true;
            }
        }

        // 信箱格式確認
        private void MailValidator(object sender, KeyPressEventArgs e)
        {
            String pattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(_mailTextBox.Text, pattern))
            {
                errorProvider.SetError(_mailTextBox, "Plz enter a valid email address!");
            }
            else
            {
                errorProvider.Clear();
                mailValid = true;
            }
        }

        // 不能為空字串
        private void IsEmpty(object sender, EventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            if (_textBox.Text == "")
            {
                errorProvider.SetError(_textBox, "U must input something!");
                if (_textBox == _firstNameTextBox)
                    firstNameValid = false;
                if (_textBox == _lastNameTextBox)
                    lastNameValid = false;
                if (_textBox == _mailTextBox)
                    mailValid = false;
                if (_textBox == _addressTextBox)
                    addressValid = false;
            }
            if(_addressTextBox.Text != "")
                addressValid = true;
        }

        // 字數不夠
        private void NotEnoughWords(object sender, EventArgs e)
        {
            TextBox _textBox; // 取得商品物件
            _textBox = (TextBox)sender;

            // 背面末3碼字數問題
            if (_textBox == _backNumberTextBox)
            {
                if (_textBox.Text.Length < 3)
                {
                    errorProvider.SetError(_textBox, "U must input 3 numbers!");
                    backNumberValid = false;
                }

            }
            // 卡號字數問題
            else
            {
                if (_textBox.Text.Length < 4)
                {
                    errorProvider.SetError(_textBox, "U must input 4 numbers!");
                    if (_textBox == _cardNumber1textBox)
                        cardNumber1Valid = false;
                    if (_textBox == _cardNumber2textBox)
                        cardNumber2Valid = false;
                    if (_textBox == _cardNumber3textBox)
                        cardNumber3Valid = false;
                    if (_textBox == _cardNumber4textBox)
                        cardNumber4Valid = false;
                }
            }
        }

        // 確認資料完整性
        private void CheckDataComplete(object sender, EventArgs e)
        {
            if (ConfirmAll())
                _confirmButton.Enabled = true;
            else
                _confirmButton.Enabled = false;
            System.Diagnostics.Debug.Print("firstNameValid = " + firstNameValid.ToString());
            System.Diagnostics.Debug.Print("lastNameValid = " + lastNameValid.ToString());
            System.Diagnostics.Debug.Print("cardNumber1Valid = " + cardNumber1Valid.ToString());
            System.Diagnostics.Debug.Print("cardNumber2Valid = " + cardNumber2Valid.ToString());
            System.Diagnostics.Debug.Print("cardNumber3Valid = " + cardNumber3Valid.ToString());
            System.Diagnostics.Debug.Print("cardNumber4Valid = " + cardNumber4Valid.ToString());
            System.Diagnostics.Debug.Print("backNumberValid = " + backNumberValid.ToString());
            System.Diagnostics.Debug.Print("mailValid = " + mailValid.ToString());
            System.Diagnostics.Debug.Print("addressValid = " + addressValid.ToString());
            System.Diagnostics.Debug.Print("all = " + ConfirmAll().ToString());
            System.Diagnostics.Debug.Print("-------------------------------------");
        }

        // 確認資料輸入完整
        private bool ConfirmAll()
        {
            if (firstNameValid == true && lastNameValid == true && cardNumber1Valid == true && cardNumber2Valid == true && cardNumber3Valid == true && cardNumber4Valid == true && backNumberValid == true && mailValid == true && addressValid == true)
                return true;
            else
                return false;
            //int parsedValue;
            //if (Regex.IsMatch(_firstNameTextBox.Text, "[^A-Z|^a-z|^ |^\t]") && Regex.IsMatch(_lastNameTextBox.Text, "[^A-Z|^a-z|^ |^\t]") &&
            //    (!int.TryParse(_cardNumber1textBox.Text, out parsedValue) == true && _cardNumber1textBox.Text.Length == 4) &&
            //    (!int.TryParse(_cardNumber2textBox.Text, out parsedValue) == true && _cardNumber2textBox.Text.Length == 4) &&
            //    (!int.TryParse(_cardNumber3textBox.Text, out parsedValue) == true && _cardNumber3textBox.Text.Length == 4) &&
            //    (!int.TryParse(_cardNumber4textBox.Text, out parsedValue) == true && _cardNumber4textBox.Text.Length == 4) &&
            //    (!int.TryParse(_backNumberTextBox.Text, out parsedValue) == true && _backNumberTextBox.Text.Length == 4) &&
            //    Regex.IsMatch(_mailTextBox.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*") && _addressTextBox.Text != "")
            //    return true;
            //else
            //    return false;
        }

        // 按下確認按鈕
        private void _clickConfirmButton(object sender, EventArgs e)
        {
            MessageBox.Show("訂購完成");
            this.Close();
            
        }
    }
}
