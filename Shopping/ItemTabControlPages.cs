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
        ProductTypeManagement _allProductManagement;
        TabPage _tabPage;
        TableLayoutPanel _tableLayoutPanel;
        List<TableLayoutPanel> _tableLayoutPanels;
        List<int> _allCurrentPage = new List<int>();
        List<int> _allTotalPage = new List<int>();
        int _currentTabIndex;

        public ItemTabControlPages(TabControl tabControl, Initial initial, ProductTypeManagement allProductManagement)
        {
            _initial = initial;
            _allProductManagement = allProductManagement;
            _tableLayoutPanels = new List<TableLayoutPanel>();
            this.InitialAllTabPages(tabControl);
        }

        public int CurrentTabIndex
        {
            get { return _currentTabIndex; }
            set { _currentTabIndex = value; }
        }

        //初始化所有tabPage
        private void InitialAllTabPages(TabControl tabControl)
        {
            int tabCount = _initial.GetAllType().Count;
            for(int i = 0; i < tabCount; i++)
            {
                _tabPage = new TabPage(_initial.GetAllType()[i]);
                _tabPage.Controls.Add(this.AddLayout());
                _tabPage.UseVisualStyleBackColor = true;
                tabControl.Controls.Add(_tabPage);
                _allCurrentPage.Add(1); //新增首頁
                _allTotalPage.Add(_allProductManagement.GetTotalPage(_initial.GetAllType()[i])); //新增總頁數
            }
        }

        // 新增TableLayoutPanel
        public TableLayoutPanel AddLayout()
        {
            _tableLayoutPanel = new TableLayoutPanel
            {
                ColumnCount = 3,
                RowCount = 2,
                Size = new System.Drawing.Size(380, 270)
            };
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50.00F));
            _tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50.00F));
            this.AddItemButton(_tableLayoutPanel);
            _tableLayoutPanels.Add(_tableLayoutPanel);
            return _tableLayoutPanel;
        }

        //新增每個Item的button
        public void AddItemButton(TableLayoutPanel tableLayoutPanel)
        {
            int tag = 0;
            for (int i = 0; i < 3; i++)
                for(int j = 0; j < 2; j++)
                {
                    Button button = new Button
                    {
                        Dock = DockStyle.Fill,
                        Tag = tag
                    };
                    tableLayoutPanel.Controls.Add(button, i, j);
                    tag += 1;
                }
        }

        // 取得TableLayoutPanel以取得Button
        public TableLayoutPanel GetTableLayoutPanel(int tabIndex)
        {
            return _tableLayoutPanels[tabIndex];
        }

        // 顯示目前頁數
        public String GetCurrentPage()
        {
            return _allCurrentPage[_currentTabIndex].ToString();
        }

        // 顯示目前總頁數
        public String GetTotalPage()
        {
            return _allTotalPage[_currentTabIndex].ToString();
        }

        // 翻頁
        public String ChangePage(int offset)
        {
            _allCurrentPage[_currentTabIndex] += offset;
            return _allCurrentPage[_currentTabIndex].ToString();
        }
    }
}
