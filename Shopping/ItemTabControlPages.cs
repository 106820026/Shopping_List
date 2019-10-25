using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    class ItemTabControlPages
    {
        Initial _initial;
        TabPage _tabPage;
        TableLayoutPanel _tableLayoutPanel;

       public ItemTabControlPages(TabControl tabControl, Initial initial)
        {
            _initial = initial;
            this.InitialAllTabPages(tabControl);
        }

        //初始化所有tabPage
        private void InitialAllTabPages(TabControl tabControl)
        {
            int tabCount = _initial.GetAllType().Count;
            //Console.WriteLine(tabCount);
            for(int i = 0; i < tabCount; i++)
            {
                this.AddLayout();
                _tabPage = new TabPage(_initial.GetAllType()[i]);
                _tabPage.Controls.Add(this.AddLayout());
                tabControl.Controls.Add(_tabPage);
            }
        }

        // 新增TableLayoutPanel
        private TableLayoutPanel AddLayout()
        {
            _tableLayoutPanel = new TableLayoutPanel();
            _tableLayoutPanel.ColumnCount = 3;
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _tableLayoutPanel.RowCount = 3;
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            _tableLayoutPanel.Size = new System.Drawing.Size(505, 340);
            return _tableLayoutPanel;
        }

        //新增每個Item的button
        public void AddItemButton()
        {

        }
    }
}
