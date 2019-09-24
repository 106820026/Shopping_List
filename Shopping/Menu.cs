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
    public partial class Menu : Form
    {
        ShopList _shopList;
        InventorySystem _inventorySystem;

        public Menu()
        {
            InitializeComponent();
        }

        // 開啟網購視窗
        private void _orderSystemButtonClick(object sender, EventArgs e)
        {
            _shopList = new ShopList();
            _shopList.Show();
            _orderSystemButton.Enabled = false;
            this._shopList.FormClosed += ResetOrderButton;
        }

        // 開啟資料庫
        private void _inventorySystemButtonClick(object sender, EventArgs e)
        {
            _inventorySystem = new InventorySystem();
            _inventorySystem.Show();
            _inventorySystemButton.Enabled = false;
            this._inventorySystem.FormClosed += ResetInventoryButton;
        }

        // 關閉程式
        private void _exitButtonClick(object sender, EventArgs e)
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
