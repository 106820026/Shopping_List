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
        CategoryManagement _categoryManagement;
        TabControl _tabControl;
        TableLayoutPanel _tableLayoutPanel;
        List<TableLayoutPanel> _tableLayoutPanels;
        List<int> _allCurrentPage = new List<int>();
        List<int> _allTotalPage = new List<int>();
        const int COLUMN_COUNT = 3;
        const int ROW_COUNT = 2;
        const int WIDTH = 380;
        const int HEIGHT = 270;

        public ItemTabControlPages(TabControl tabControl, CategoryManagement productTypeManagement)
        {
            _categoryManagement = productTypeManagement;
            _tableLayoutPanels = new List<TableLayoutPanel>();
            this.InitialAllTabPages(tabControl);
        }

        public int CurrentTabIndex
        {
            get; set;
        }

        // 取得所有tab數量
        public int GetTabCount()
        {
            return _categoryManagement.GetCategories().Count;
        }

        // 初始化所有tabPage
        private void InitialAllTabPages(TabControl tabControl)
        {
            _tabControl = tabControl;
            for (int i = 0; i < this.GetTabCount(); i++)
            {
                TabPage tabPage = new TabPage(_categoryManagement.GetCategories()[i].CategoryName);
                tabPage.Controls.Add(this.AddLayout());
                tabPage.UseVisualStyleBackColor = true;
                tabControl.Controls.Add(tabPage);
                _allCurrentPage.Add(1); //新增首頁
                _allTotalPage.Add(_categoryManagement.GetTotalPage(i)); //新增總頁數
            }
        }

        // 更新總頁數
        public void UpdateTotalPage()
        {
            _allTotalPage.Clear();
            for (int i = 0; i < this.GetTabCount(); i++)
                _allTotalPage.Add(_categoryManagement.GetTotalPage(i)); //新增總頁數
        }

        // 新增TableLayoutPanel
        public TableLayoutPanel AddLayout()
        {
            _tableLayoutPanel = new TableLayoutPanel
            {
                ColumnCount = COLUMN_COUNT,
                RowCount = ROW_COUNT,
                Dock = DockStyle.Fill,
                Size = new System.Drawing.Size(WIDTH, HEIGHT)
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

        // 新增每個Item的button
        public void AddItemButton(TableLayoutPanel tableLayoutPanel)
        {
            int tag = 0;
            for (int i = 0; i < COLUMN_COUNT; i++)
                for (int j = 0; j < ROW_COUNT; j++)
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
            if (_allTotalPage[CurrentTabIndex] < _allCurrentPage[CurrentTabIndex])
                _allCurrentPage[CurrentTabIndex] = _allCurrentPage[CurrentTabIndex] - 1;
            return _allCurrentPage[CurrentTabIndex].ToString();
        }

        // 顯示目前總頁數
        public String GetTotalPage()
        {
            return _allTotalPage[CurrentTabIndex].ToString();
        }

        // 翻頁
        public String ChangePage(int offset)
        {
            _allCurrentPage[CurrentTabIndex] += offset;
            return _allCurrentPage[CurrentTabIndex].ToString();
        }

        // 新增一個tab page
        public void AddNewTabPage()
        {
            TabPage tabPage = new TabPage(_categoryManagement.GetLatestCategory().CategoryName);
            tabPage.Controls.Add(this.AddLayout());
            tabPage.UseVisualStyleBackColor = true;
            _tabControl.Controls.Add(tabPage);
            _allCurrentPage.Add(1); //新增首頁
            _allTotalPage.Add(1); //新增總頁數
        }
    }
}
