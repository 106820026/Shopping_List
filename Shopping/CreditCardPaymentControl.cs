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
        bool firstNameValid, lastNameValid, cardNumber1Valid, cardNumber2Valid,
             cardNumber3Valid, cardNumber4Valid, backNumberValid, mailValid, addressValid;

        const String FIRST_NAME_TEXTBOX = "_firstNameTextBox";
        const String LAST_NAME_TEXTBOX = "_lastNameTextBox";
        const String ADDRESS_TEXTBOX = "_addressTextBox";
        const String CARD_NUMBER1_TEXTBOX = "_cardNumber1textBox";
        const String CARD_NUMBER2_TEXTBOX = "_cardNumber2textBox";
        const String CARD_NUMBER3_TEXTBOX = "_cardNumber3textBox";
        const String CARD_NUMBER4_TEXTBOX = "_cardNumber4textBox";
        const String BACK_CARD_TEXTBOX = "_backNumberTextBox";
        const String MAIL_TEXTBOX = "_mailTextBox";
        const String PATERN = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        // 錯誤訊息
        const String NO_NUMBER_INPUT = "no number input";
        const String YOU_MUST_INPUT_SOMETHING = "U must input something!";
        const String ONLY_NUMBER_INPUT = "only number input";
        const String INPUT_VALID_MAIL = "Plz enter a valid email address!";
        const String YOU_MUST_INPUT_3_NUMBERS = "U must input 3 numbers!";
        const String YOU_MUST_INPUT_4_NUMBERS = "U must input 4 numbers!";
        const String NO_ERROR = "";
        String _errorMessage;

        public CreditCardPaymentControl()
        {
            firstNameValid = lastNameValid = cardNumber1Valid = cardNumber2Valid = cardNumber3Valid =
            cardNumber4Valid = backNumberValid = mailValid = addressValid = false;
        }

        // 確認姓名輸入
        public void ConfirmName(String itemName,int length, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9') // 不可輸入數字
            {
                e.Handled = true;
                _errorMessage = NO_NUMBER_INPUT;
            }
            else
            {
                e.Handled = false;
                if (e.KeyChar == 8 && length <= 1) // 按下刪除鍵
                {
                    if (itemName == FIRST_NAME_TEXTBOX)
                        firstNameValid = false;
                    if (itemName == LAST_NAME_TEXTBOX)
                        lastNameValid = false;
                    _errorMessage = YOU_MUST_INPUT_SOMETHING;
                }
                else
                {
                    if (itemName == FIRST_NAME_TEXTBOX)
                        firstNameValid = true;
                    if (itemName == LAST_NAME_TEXTBOX)
                        lastNameValid = true;
                    _errorMessage = NO_ERROR;
                }
            }
        }

        // 確認地址輸入
        public void ConfirmAddress(int length, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 && length <= 1) // 按下刪除鍵
            {
                addressValid = false;
                _errorMessage = YOU_MUST_INPUT_SOMETHING;
            }
            else
            {
                addressValid = true;
                _errorMessage = NO_ERROR;
            }
        }

        // 卡號只能輸入數字
        public void InputOnlyNumber(String itemName, int length, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != 8)) //輸入非數字
            {
                e.Handled = true;
                _errorMessage = ONLY_NUMBER_INPUT;
            }
            else if (e.KeyChar == 8) // 按下刪除鍵
            {
                _errorMessage = YOU_MUST_INPUT_4_NUMBERS;
                if (itemName == CARD_NUMBER1_TEXTBOX)
                    cardNumber1Valid = false;
                if (itemName == CARD_NUMBER2_TEXTBOX)
                    cardNumber2Valid = false;
                if (itemName == CARD_NUMBER3_TEXTBOX)
                    cardNumber3Valid = false;
                if (itemName == CARD_NUMBER4_TEXTBOX)
                    cardNumber4Valid = false;
                if (itemName == BACK_CARD_TEXTBOX)
                {
                    backNumberValid = false;
                    _errorMessage = YOU_MUST_INPUT_3_NUMBERS;
                }
                    
            }
            else
            {
                e.Handled = false;
                _errorMessage = NO_ERROR;
                if (length >= 3)
                {
                    if (itemName == CARD_NUMBER1_TEXTBOX)
                        cardNumber1Valid = true;
                    if (itemName == CARD_NUMBER2_TEXTBOX)
                        cardNumber2Valid = true;
                    if (itemName == CARD_NUMBER3_TEXTBOX)
                        cardNumber3Valid = true;
                    if (itemName == CARD_NUMBER4_TEXTBOX)
                        cardNumber4Valid = true;
                }
                if (itemName == BACK_CARD_TEXTBOX && length >= 2)
                    backNumberValid = true;
            }
        }

        // 確認信箱格式
        public void ConfirmMailFormat(String text)
        {
            if (!Regex.IsMatch(text, PATERN))
            {
                _errorMessage = INPUT_VALID_MAIL;
                mailValid = false;
            }
            else
            {
                _errorMessage = NO_ERROR;
                mailValid = true;
            }
        }

        // 禁止出現空字串
        public void CheckNoEmpty(String itemName, String text)
        {
            if (text == "")
            {
                _errorMessage = YOU_MUST_INPUT_SOMETHING;
                if (itemName == FIRST_NAME_TEXTBOX)
                    firstNameValid = false;
                if (itemName == LAST_NAME_TEXTBOX)
                    lastNameValid = false;
                if (itemName == MAIL_TEXTBOX)
                    mailValid = false;
                if (itemName == ADDRESS_TEXTBOX)
                    addressValid = false;
            }
        }


        // 卡號字數不足
        public void LackNumber(String itemName, int length)
        {
            // 背面末3碼字數問題
            if (itemName == BACK_CARD_TEXTBOX)
            {
                if (length < 3)
                {
                    _errorMessage = YOU_MUST_INPUT_3_NUMBERS;
                    backNumberValid = false;
                }
            }
            // 卡號字數問題
            else
            {
                if (length < 4)
                {
                    _errorMessage = YOU_MUST_INPUT_4_NUMBERS;
                    if (itemName == CARD_NUMBER1_TEXTBOX)
                        cardNumber1Valid = false;
                    if (itemName == CARD_NUMBER2_TEXTBOX)
                        cardNumber2Valid = false;
                    if (itemName == CARD_NUMBER3_TEXTBOX)
                        cardNumber3Valid = false;
                    if (itemName == CARD_NUMBER4_TEXTBOX)
                        cardNumber4Valid = false;
                }
            }
        }

        // 確認資料輸入完整
        public bool ConfirmAll()
        {
            if (firstNameValid == true && lastNameValid == true && cardNumber1Valid == true && cardNumber2Valid == true && cardNumber3Valid == true && cardNumber4Valid == true && backNumberValid == true && mailValid == true && addressValid == true)
                return true;
            else
                return false;
        }

        // 顯示錯誤訊息
        public String ErrorMessage()
        {
            return _errorMessage;
        }
    }
}
