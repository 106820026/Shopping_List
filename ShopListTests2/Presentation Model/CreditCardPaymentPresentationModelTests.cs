using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopList.PresentationModel.Tests
{

    [TestClass()]
    public class CreditCardPaymentPresentationModelTests
    {
        CreditCardPaymentPresentationModel _creditCardPaymentPresentationModel;

        [TestInitialize]
        public void Initialize()
        {
            _creditCardPaymentPresentationModel = new CreditCardPaymentPresentationModel();
        }

        [TestMethod()]
        public void CreditCardPaymentPresentationModelTest()
        {
            foreach (bool flag in _creditCardPaymentPresentationModel.AllValid)
                Assert.IsFalse(flag);
        }

        [TestMethod()]
        public void ConfirmNameTest()
        {
            Assert.IsFalse(_creditCardPaymentPresentationModel.ConfirmName(1, 1, 'a'));
            Assert.IsTrue(_creditCardPaymentPresentationModel.ConfirmName(1, 1, '1'));
            _creditCardPaymentPresentationModel.ConfirmName(1, 1, (char)8);
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "U must input something!");
        }

        [TestMethod()]
        public void ConfirmAddressTest()
        {
            _creditCardPaymentPresentationModel.ConfirmAddress(2, 'a');
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "");
            _creditCardPaymentPresentationModel.ConfirmAddress(1, (char)8);
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "U must input something!");
        }

        [TestMethod()]
        public void InputOnlyNumberTest()
        {
            Assert.IsFalse(_creditCardPaymentPresentationModel.InputOnlyNumber(2, 1, '1'));
            Assert.IsTrue(_creditCardPaymentPresentationModel.InputOnlyNumber(2, 1, 'a'));
            Assert.IsFalse(_creditCardPaymentPresentationModel.InputOnlyNumber(2, 2, (char)8));
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "U must input more numbers!");
        }

        [TestMethod()]
        public void CheckLengthTest()
        {
            _creditCardPaymentPresentationModel.CheckLength(2, 3);
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "");
            _creditCardPaymentPresentationModel.CheckLength(6, 3);
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "");
        }

        [TestMethod()]
        public void ConfirmMailFormatTest()
        {
            _creditCardPaymentPresentationModel.ConfirmMailFormat("a");
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "Plz enter a valid email address!");
            _creditCardPaymentPresentationModel.ConfirmMailFormat("a@aa.aa");
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "");
        }

        [TestMethod()]
        public void CheckNoEmptyTest()
        {
            _creditCardPaymentPresentationModel.CheckNoEmpty(0, "");
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "U must input something!");
        }

        [TestMethod()]
        public void LackNumberTest()
        {
            _creditCardPaymentPresentationModel.LackNumber(2, 3);
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "U must input 4 numbers!");
            _creditCardPaymentPresentationModel.LackNumber(6, 2);
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "U must input 3 numbers!");
        }

        [TestMethod()]
        public void ConfirmAllTest()
        {
            _creditCardPaymentPresentationModel.ConfirmName(0, 4, 'a');
            _creditCardPaymentPresentationModel.ConfirmName(1, 4, 'a');
            _creditCardPaymentPresentationModel.InputOnlyNumber(2, 4, '1');
            _creditCardPaymentPresentationModel.InputOnlyNumber(3, 4, '1');
            _creditCardPaymentPresentationModel.InputOnlyNumber(4, 4, '1');
            _creditCardPaymentPresentationModel.InputOnlyNumber(5, 4, '1');
            _creditCardPaymentPresentationModel.InputOnlyNumber(6, 3, '1');
            _creditCardPaymentPresentationModel.ConfirmAddress(4, 'a');
            _creditCardPaymentPresentationModel.ConfirmMailFormat("a@aa");
            Assert.IsFalse(_creditCardPaymentPresentationModel.ConfirmAll());
            _creditCardPaymentPresentationModel.ConfirmMailFormat("a@aa.aa");
            Assert.IsTrue(_creditCardPaymentPresentationModel.ConfirmAll());
        }

        [TestMethod()]
        public void GetErrorMessageTest()
        {
            _creditCardPaymentPresentationModel.InputOnlyNumber(2, 3, 'a');
            Assert.AreEqual(_creditCardPaymentPresentationModel.GetErrorMessage(), "only number input");
        }
    }
}