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
    public partial class MenuForm : Form
    {
        ShopList _shopList;
        InventorySystem _inventorySystem;
        ProductManagementSystem _productManagementSystem;
        Initial _initial = new Initial(FILE_PATH);
        ProductTypeManagement _productTypeManagerment;
        const String FILE_PATH = "../../Data Info.ini";

        public MenuForm()
        {
            InitializeComponent();
            _productTypeManagerment = new ProductTypeManagement(_initial);
        }

        // 開啟網購視窗
        private void ClickOrderSystemButton(object sender, EventArgs e)
        {
            _shopList = new ShopList(_initial, _productTypeManagerment);
            _shopList.Show();
            _orderSystemButton.Enabled = false;
            this._shopList.FormClosed += ResetOrderButton;
        }

        // 開啟庫存視窗
        private void ClickInventorySystemButton(object sender, EventArgs e)
        {
            _inventorySystem = new InventorySystem(_initial);
            _inventorySystem.Show();
            _inventorySystemButton.Enabled = false;
            this._inventorySystem.FormClosed += ResetInventoryButton; 
        }

        // 開啟庫存管理視窗
        private void ClickProductManagementSystemButton(object sender, EventArgs e)
        {
            _productManagementSystem = new ProductManagementSystem(_initial, _productTypeManagerment);
            _productManagementSystem.Show();
            _productManagementSystemButton.Enabled = false;
            this._productManagementSystem.FormClosed += ResetProductManagementSystemButton;
        }

        // 關閉程式
        private void ClickExitButton(object sender, EventArgs e)
        {
            this.Close();
        }

        // 使按鈕可再次使用 
        private void ResetOrderButton(object sender, EventArgs e)
        {
            _orderSystemButton.Enabled = true;
        }

        // 使按鈕可再次使用
        private void ResetInventoryButton(object sender, EventArgs e)
        {
            _inventorySystemButton.Enabled = true;
        }

        // 使按鈕可再次使用
        private void ResetProductManagementSystemButton(object sender, EventArgs e)
        {
            _productManagementSystemButton.Enabled = true;
        }
    }
}
