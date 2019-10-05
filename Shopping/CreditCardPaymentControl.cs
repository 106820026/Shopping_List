using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    class CreditCardPaymentControl
    {
        #region Member Data
        bool[] _allValid;
        const String FIRST_NAME_TEXT_BOX = "_firstNameTextBox";
        const String LAST_NAME_TEXT_BOX = "_lastNameTextBox";
        const String ADDRESS_TEXT_BOX = "_addressTextBox";
        const String CARD_NUMBER1_TEXT_BOX = "_cardNumber1textBox";
        const String CARD_NUMBER2_TEXT_BOX = "_cardNumber2textBox";
        const String CARD_NUMBER3_TEXT_BOX = "_cardNumber3textBox";
        const String CARD_NUMBER4_TEXT_BOX = "_cardNumber4textBox";
        const String BACK_CARD_TEXT_BOX = "_backNumberTextBox";
        const String MAIL_TEXT_BOX = "_mailTextBox";
        const String PATTERN = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        // 錯誤訊息
        const String NO_NUMBER_INPUT = "no number input";
        const String YOU_MUST_INPUT_SOMETHING = "U must input something!";
        const String ONLY_NUMBER_INPUT = "only number input";
        const String INPUT_VALID_MAIL = "Plz enter a valid email address!";
        const String YOU_MUST_INPUT_3_NUMBERS = "U must input 3 numbers!";
        const String YOU_MUST_INPUT_4_NUMBERS = "U must input 4 numbers!";
        const String NO_ERROR = "";
        // 所有值確認
        bool _firstNameValid = false;
        bool _lastNameValid = false;
        bool _cardNumber1Valid = false;
        bool _cardNumber2Valid = false;
        bool _cardNumber3Valid = false;
        bool _cardNumber4Valid = false;
        bool _backNumberValid = false;
        bool _mailValid = false;
        bool _addressValid = false;
        String _errorMessage;
        const char ZERO = '0';
        const char NINE = '9';
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        const int DELETE_BUTTON = 8;
        #endregion

        public CreditCardPaymentControl()
        {
            _allValid = new bool[] { _firstNameValid, _lastNameValid, _cardNumber1Valid, _cardNumber2Valid, _cardNumber3Valid, _cardNumber4Valid, _backNumberValid, _mailValid, _addressValid };
        }

        // 確認姓名輸入
        public void ConfirmName(String itemName, int length, KeyPressEventArgs e)
        {
            if (e.KeyChar >= ZERO && e.KeyChar <= NINE) // 不可輸入數字
            {
                e.Handled = true;
                _errorMessage = NO_NUMBER_INPUT;
            }
            else
            {
                e.Handled = false;
                if (e.KeyChar == DELETE_BUTTON && length <= 1) // 按下刪除鍵
                {
                    if (itemName == FIRST_NAME_TEXT_BOX)
                        _firstNameValid = false;
                    if (itemName == LAST_NAME_TEXT_BOX)
                        _lastNameValid = false;
                    _errorMessage = YOU_MUST_INPUT_SOMETHING;
                }
                else
                {
                    if (itemName == FIRST_NAME_TEXT_BOX)
                        _firstNameValid = true;
                    if (itemName == LAST_NAME_TEXT_BOX)
                        _lastNameValid = true;
                    _errorMessage = NO_ERROR;
                }
            }
        }

        // 確認地址輸入
        public void ConfirmAddress(int length, KeyPressEventArgs e)
        {
            if (e.KeyChar == DELETE_BUTTON && length <= 1) // 按下刪除鍵
            {
                _addressValid = false;
                _errorMessage = YOU_MUST_INPUT_SOMETHING;
            }
            else
            {
                _addressValid = true;
                _errorMessage = NO_ERROR;
            }
        }

        // 卡號只能輸入數字
        public void InputOnlyNumber(String itemName, int length, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != DELETE_BUTTON)) //輸入非數字
            {
                e.Handled = true;
                _errorMessage = ONLY_NUMBER_INPUT;
            }
            else if (e.KeyChar == DELETE_BUTTON) // 按下刪除鍵
            {
                _errorMessage = YOU_MUST_INPUT_4_NUMBERS;
                if (itemName == CARD_NUMBER1_TEXT_BOX)
                    _cardNumber1Valid = false;
                if (itemName == CARD_NUMBER2_TEXT_BOX)
                    _cardNumber2Valid = false;
                if (itemName == CARD_NUMBER3_TEXT_BOX)
                    _cardNumber3Valid = false;
                if (itemName == CARD_NUMBER4_TEXT_BOX)
                    _cardNumber4Valid = false;
                if (itemName == BACK_CARD_TEXT_BOX)
                {
                    _backNumberValid = false;
                    _errorMessage = YOU_MUST_INPUT_3_NUMBERS;
                }
                    
            }
            else
            {
                e.Handled = false;
                _errorMessage = NO_ERROR;
                if (length >= THREE)
                {
                    if (itemName == CARD_NUMBER1_TEXT_BOX)
                        _cardNumber1Valid = true;
                    if (itemName == CARD_NUMBER2_TEXT_BOX)
                        _cardNumber2Valid = true;
                    if (itemName == CARD_NUMBER3_TEXT_BOX)
                        _cardNumber3Valid = true;
                    if (itemName == CARD_NUMBER4_TEXT_BOX)
                        _cardNumber4Valid = true;
                }
                if (itemName == BACK_CARD_TEXT_BOX && length >= TWO)
                    _backNumberValid = true;
            }
        }

        // 確認信箱格式
        public void ConfirmMailFormat(String text)
        {
            if (!Regex.IsMatch(text, PATTERN))
            {
                _errorMessage = INPUT_VALID_MAIL;
                _mailValid = false;
            }
            else
            {
                _errorMessage = NO_ERROR;
                _mailValid = true;
            }
        }

        // 禁止出現空字串
        public void CheckNoEmpty(String itemName, String text)
        {
            if (text == "")
            {
                _errorMessage = YOU_MUST_INPUT_SOMETHING;
                if (itemName == FIRST_NAME_TEXT_BOX)
                    _firstNameValid = false;
                if (itemName == LAST_NAME_TEXT_BOX)
                    _lastNameValid = false;
                if (itemName == MAIL_TEXT_BOX)
                    _mailValid = false;
                if (itemName == ADDRESS_TEXT_BOX)
                    _addressValid = false;
            }
        }

        // 卡號字數不足
        public void LackNumber(String itemName, int length)
        {
            // 背面末3碼字數問題
            if (itemName == BACK_CARD_TEXT_BOX)
            {
                if (length < THREE)
                {
                    _errorMessage = YOU_MUST_INPUT_3_NUMBERS;
                    _backNumberValid = false;
                }
            }
            // 卡號字數問題
            else
            {
                if (length < FOUR)
                {
                    _errorMessage = YOU_MUST_INPUT_4_NUMBERS;
                    if (itemName == CARD_NUMBER1_TEXT_BOX)
                        _cardNumber1Valid = false;
                    if (itemName == CARD_NUMBER2_TEXT_BOX)
                        _cardNumber2Valid = false;
                    if (itemName == CARD_NUMBER3_TEXT_BOX)
                        _cardNumber3Valid = false;
                    if (itemName == CARD_NUMBER4_TEXT_BOX)
                        _cardNumber4Valid = false;
                }
            }
        }

        // 確認資料輸入完整
        public bool ConfirmAll()
        {
            if (_firstNameValid == true && _lastNameValid == true && _cardNumber1Valid == true && _cardNumber2Valid == true && _cardNumber3Valid == true && _cardNumber4Valid == true && _backNumberValid == true && _mailValid == true && _addressValid == true)
                return true;
            else
                return false;
        }

        // 顯示錯誤訊息
        public String GetErrorMessage()
        {
            return _errorMessage;
        }

        // 清除末3碼
        public String CleanBackNumber()
        {
            _backNumberValid = false;
            return "";
        }
    }
}
