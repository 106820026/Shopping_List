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

        public MenuForm()
        {
            InitializeComponent();
        }

        // 開啟網購視窗
        private void ClickOrderSystemButton(object sender, EventArgs e)
        {
            _shopList = new ShopList();
            _shopList.Show();
            _orderSystemButton.Enabled = false;
            this._shopList.FormClosed += ResetOrderButton;
        }

        // 開啟資料庫
        private void ClickInventorySystemButton(object sender, EventArgs e)
        {
            _inventorySystem = new InventorySystem();
            _inventorySystem.Show();
            _inventorySystemButton.Enabled = false;
            this._inventorySystem.FormClosed += ResetInventoryButton; 
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
    }
}
