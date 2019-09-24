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
            _shopList = new ShopList();
            _inventorySystem = new InventorySystem();
        }

        // 開啟網購視窗
        private void _orderSystemButtonClick(object sender, EventArgs e)
        {
            _shopList.Show();
            _orderSystemButton.Enabled = false;
        }

        // 開啟資料庫
        private void _inventorySystemButtonClick(object sender, EventArgs e)
        {
            _inventorySystem.Show();
            _inventorySystemButton.Enabled = false;
        }

        // 關閉程式
        private void _exitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
