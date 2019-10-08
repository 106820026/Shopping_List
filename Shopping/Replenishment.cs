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
    public partial class Replenishment : Form
    {
        public Replenishment()
        {
            InitializeComponent();
        }

        // 關閉視窗
        private void ClickCancelButton(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
