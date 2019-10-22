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
    public partial class ProductManagementSystem : Form
    {
        Initial _initial;
        ProductManagementSystemPresentationModel _productManagementSystemPresentationModel = new ProductManagementSystemPresentationModel();
        List<String> _allSectionList = new List<string>();

        public ProductManagementSystem(Initial initial)
        {
            InitializeComponent();
            _initial = initial;
            _allSectionList = _initial.GetAllSections().Cast<String>().ToList(); // 取得所有商品Section的List
            ShowAllItemNames();
        }

        //顯示右方詳細資訊
        private void GetItemDetail(object sender, EventArgs e)
        {
            int index = ((ListBox)sender).SelectedIndex;
            ShowAllDetails(index);
        }

        // 在ListBox中顯示所有商品名稱
        public void ShowAllItemNames()
        {
            foreach (String section in _allSectionList)
                _itemsListBox.Items.Add(_initial.GetName(section));
        }

        // 顯示所有詳細資訊
        private void ShowAllDetails(int index)
        {
            _itemNameTextBox.Text = _itemsListBox.SelectedItem.ToString();
            _itemPriceTextBox.Text = _initial.GetPrice(_allSectionList[index]);
            _itemCategoryComboBox.SelectedIndex = _productManagementSystemPresentationModel.GetItemType(_initial.GetType(_allSectionList[index]));
            _itemPicturePathTextBox.Text = _initial.GetPicturePath(_allSectionList[index]);
            _itemDescriptionTextBox.Text = _initial.GetDetail(_allSectionList[index]);
        }
    }
}
