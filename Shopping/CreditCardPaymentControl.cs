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
        const String YOU_MUST_INPUT_MORE_NUMBERS = "U must input more numbers!";
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
        const int BACK_NUMBER_TAG = 6;
        const int MAIL_TAG = 7;
        const int ADDRESS_TAG = 8;
        const int TEXT_BOX_NUMBER = 9;
        #endregion

        public CreditCardPaymentControl()
        {
            _allValid = new bool[] { _firstNameValid, _lastNameValid, _cardNumber1Valid, _cardNumber2Valid, _cardNumber3Valid, _cardNumber4Valid, _backNumberValid, _mailValid, _addressValid };
        }

        // 確認姓名輸入
        public void ConfirmName(int itemTag, int length, KeyPressEventArgs e)
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
                    this.GetValidStatus(itemTag, false, YOU_MUST_INPUT_SOMETHING);
                }
                else
                {
                    this.GetValidStatus(itemTag, true, NO_ERROR);
                }
            }
        }

        // 確認地址輸入
        public void ConfirmAddress(int length, KeyPressEventArgs e)
        {
            if (e.KeyChar == DELETE_BUTTON && length <= 1) // 按下刪除鍵
                this.GetValidStatus(ADDRESS_TAG, false, YOU_MUST_INPUT_SOMETHING);
            else
                this.GetValidStatus(ADDRESS_TAG, true, NO_ERROR);
        }

        // 卡號只能輸入數字
        public void InputOnlyNumber(int itemTag, int length, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != DELETE_BUTTON)) //輸入非數字
            {
                e.Handled = true;
                _errorMessage = ONLY_NUMBER_INPUT;
            }
            else if (e.KeyChar == DELETE_BUTTON) // 按下刪除鍵
            {
                this.GetValidStatus(itemTag, false, YOU_MUST_INPUT_MORE_NUMBERS);
            }
            else
            {
                e.Handled = false;
                if (itemTag == BACK_NUMBER_TAG && length >= TWO)
                    this.GetValidStatus(itemTag, true, NO_ERROR); // 檢查長度
                if (length >= THREE)
                    this.GetValidStatus(itemTag, true, NO_ERROR); // 檢查長度
            }
        }

        // 確認信箱格式
        public void ConfirmMailFormat(String text)
        {
            if (!Regex.IsMatch(text, PATTERN))
                this.GetValidStatus(MAIL_TAG, false, INPUT_VALID_MAIL);
            else
                this.GetValidStatus(MAIL_TAG, true, NO_ERROR);
        }

        // 禁止出現空字串
        public void CheckNoEmpty(int itemTag, String text)
        {
            if (text == "")
                this.GetValidStatus(itemTag, false, YOU_MUST_INPUT_SOMETHING);
        }

        // 卡號字數不足
        public void LackNumber(int itemTag, int length)
        {
            // 背面末3碼字數問題
            if (itemTag == BACK_NUMBER_TAG)
            {
                if (length < THREE)
                    this.GetValidStatus(itemTag, false, YOU_MUST_INPUT_3_NUMBERS);
            }
            // 卡號字數問題
            else
            {
                if (length < FOUR)
                    this.GetValidStatus(itemTag, false, YOU_MUST_INPUT_4_NUMBERS);
            }
        }

        // 確認資料輸入完整
        public bool ConfirmAll()
        {
            for (int i = 0; i < TEXT_BOX_NUMBER; i++) // 如果有false的話就直接return false
            {
                if (_allValid[i] != true)
                    return false;
            }
            return true;
        }

        // 顯示錯誤訊息
        public String GetErrorMessage()
        {
            return _errorMessage;
        }

        // 清除末3碼
        public String CleanBackNumber()
        {
            _allValid[BACK_NUMBER_TAG] = false;
            return String.Empty;
        }

        // 輸入框狀態改變
        private void GetValidStatus(int itemTag, bool flag, String errorMessage)
        {
            _allValid[itemTag] = flag;
            _errorMessage = errorMessage;
        }
    }
}
