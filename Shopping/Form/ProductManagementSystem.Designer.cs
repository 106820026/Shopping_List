namespace ShopList
{
    partial class ProductManagementSystem
    {
        
        /// Required designer variable.
        
        private System.ComponentModel.IContainer components = null;

        
        /// Clean up any resources being used.
        
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        
        private void InitializeComponent()
        {
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._titleLabel = new System.Windows.Forms.Label();
            this._managementTabControl = new System.Windows.Forms.TabControl();
            this._itemManagementTabPage = new System.Windows.Forms.TabPage();
            this._tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._addNewItemButton = new System.Windows.Forms.Button();
            this._titleGroupBox = new System.Windows.Forms.GroupBox();
            this._tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this._itemNameLabel = new System.Windows.Forms.Label();
            this._itemNameTextBox = new System.Windows.Forms.TextBox();
            this._tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this._itemPriceLabel = new System.Windows.Forms.Label();
            this._itemPriceTextBox = new System.Windows.Forms.TextBox();
            this._unitLabel = new System.Windows.Forms.Label();
            this._itemCategoryLabel = new System.Windows.Forms.Label();
            this._itemCategoryComboBox = new System.Windows.Forms.ComboBox();
            this._tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this._itemPicturePathLabel = new System.Windows.Forms.Label();
            this._itemPicturePathTextBox = new System.Windows.Forms.TextBox();
            this._searchButton = new System.Windows.Forms.Button();
            this._itemDescriptionLabel = new System.Windows.Forms.Label();
            this._itemDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this._saveItemButton = new System.Windows.Forms.Button();
            this._itemsListBox = new System.Windows.Forms.ListBox();
            this._categoryManagementTabPage = new System.Windows.Forms.TabPage();
            this._tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this._saveCategoryButton = new System.Windows.Forms.Button();
            this._addNewCategoryButton = new System.Windows.Forms.Button();
            this._categoryListBox = new System.Windows.Forms.ListBox();
            this._categoryGroupBox = new System.Windows.Forms.GroupBox();
            this._productOfCategoryListBox = new System.Windows.Forms.ListBox();
            this._productOfCategoryTextLabel = new System.Windows.Forms.Label();
            this._categoryNameTextBox = new System.Windows.Forms.TextBox();
            this._categoryNameTextLabel = new System.Windows.Forms.Label();
            this._tableLayoutPanel.SuspendLayout();
            this._managementTabControl.SuspendLayout();
            this._itemManagementTabPage.SuspendLayout();
            this._tableLayoutPanel1.SuspendLayout();
            this._titleGroupBox.SuspendLayout();
            this._tableLayoutPanel2.SuspendLayout();
            this._tableLayoutPanel3.SuspendLayout();
            this._tableLayoutPanel4.SuspendLayout();
            this._tableLayoutPanel5.SuspendLayout();
            this._categoryManagementTabPage.SuspendLayout();
            this._tableLayoutPanel6.SuspendLayout();
            this._categoryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Controls.Add(this._titleLabel, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._managementTabControl, 0, 1);
            this._tableLayoutPanel.Location = new System.Drawing.Point(1, 1);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(862, 630);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // _titleLabel
            // 
            this._titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._titleLabel.AutoSize = true;
            this._titleLabel.Font = new System.Drawing.Font("微軟正黑體", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._titleLabel.Location = new System.Drawing.Point(267, 0);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(327, 63);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "商品管理系統";
            // 
            // _managementTabControl
            // 
            this._managementTabControl.Controls.Add(this._itemManagementTabPage);
            this._managementTabControl.Controls.Add(this._categoryManagementTabPage);
            this._managementTabControl.Location = new System.Drawing.Point(3, 66);
            this._managementTabControl.Name = "_managementTabControl";
            this._managementTabControl.SelectedIndex = 0;
            this._managementTabControl.Size = new System.Drawing.Size(856, 561);
            this._managementTabControl.TabIndex = 1;
            // 
            // _itemManagementTabPage
            // 
            this._itemManagementTabPage.Controls.Add(this._tableLayoutPanel1);
            this._itemManagementTabPage.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemManagementTabPage.Location = new System.Drawing.Point(4, 25);
            this._itemManagementTabPage.Name = "_itemManagementTabPage";
            this._itemManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._itemManagementTabPage.Size = new System.Drawing.Size(848, 532);
            this._itemManagementTabPage.TabIndex = 0;
            this._itemManagementTabPage.Text = "商品管理";
            this._itemManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel1
            // 
            this._tableLayoutPanel1.ColumnCount = 2;
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tableLayoutPanel1.Controls.Add(this._addNewItemButton, 0, 1);
            this._tableLayoutPanel1.Controls.Add(this._titleGroupBox, 1, 0);
            this._tableLayoutPanel1.Controls.Add(this._saveItemButton, 1, 1);
            this._tableLayoutPanel1.Controls.Add(this._itemsListBox, 0, 0);
            this._tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this._tableLayoutPanel1.Name = "_tableLayoutPanel1";
            this._tableLayoutPanel1.RowCount = 2;
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tableLayoutPanel1.Size = new System.Drawing.Size(845, 527);
            this._tableLayoutPanel1.TabIndex = 0;
            // 
            // _addNewItemButton
            // 
            this._addNewItemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addNewItemButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addNewItemButton.Location = new System.Drawing.Point(3, 477);
            this._addNewItemButton.Name = "_addNewItemButton";
            this._addNewItemButton.Size = new System.Drawing.Size(247, 47);
            this._addNewItemButton.TabIndex = 1;
            this._addNewItemButton.Text = "新增商品";
            this._addNewItemButton.UseVisualStyleBackColor = true;
            this._addNewItemButton.Click += new System.EventHandler(this.ClickAddNewItemButton);
            // 
            // _titleGroupBox
            // 
            this._titleGroupBox.Controls.Add(this._tableLayoutPanel2);
            this._titleGroupBox.Location = new System.Drawing.Point(256, 3);
            this._titleGroupBox.Name = "_titleGroupBox";
            this._titleGroupBox.Size = new System.Drawing.Size(586, 468);
            this._titleGroupBox.TabIndex = 2;
            this._titleGroupBox.TabStop = false;
            this._titleGroupBox.Text = "編輯商品";
            // 
            // _tableLayoutPanel2
            // 
            this._tableLayoutPanel2.ColumnCount = 1;
            this._tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel2.Controls.Add(this._tableLayoutPanel3, 0, 0);
            this._tableLayoutPanel2.Controls.Add(this._tableLayoutPanel4, 0, 1);
            this._tableLayoutPanel2.Controls.Add(this._tableLayoutPanel5, 0, 2);
            this._tableLayoutPanel2.Controls.Add(this._itemDescriptionLabel, 0, 3);
            this._tableLayoutPanel2.Controls.Add(this._itemDescriptionTextBox, 0, 4);
            this._tableLayoutPanel2.Location = new System.Drawing.Point(6, 20);
            this._tableLayoutPanel2.Name = "_tableLayoutPanel2";
            this._tableLayoutPanel2.RowCount = 5;
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this._tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this._tableLayoutPanel2.Size = new System.Drawing.Size(574, 448);
            this._tableLayoutPanel2.TabIndex = 0;
            // 
            // _tableLayoutPanel3
            // 
            this._tableLayoutPanel3.ColumnCount = 2;
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this._tableLayoutPanel3.Controls.Add(this._itemNameLabel, 0, 0);
            this._tableLayoutPanel3.Controls.Add(this._itemNameTextBox, 1, 0);
            this._tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel3.Name = "_tableLayoutPanel3";
            this._tableLayoutPanel3.RowCount = 1;
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this._tableLayoutPanel3.Size = new System.Drawing.Size(568, 43);
            this._tableLayoutPanel3.TabIndex = 0;
            // 
            // _itemNameLabel
            // 
            this._itemNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._itemNameLabel.AutoSize = true;
            this._itemNameLabel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemNameLabel.Location = new System.Drawing.Point(11, 12);
            this._itemNameLabel.Name = "_itemNameLabel";
            this._itemNameLabel.Size = new System.Drawing.Size(90, 19);
            this._itemNameLabel.TabIndex = 0;
            this._itemNameLabel.Text = "商品名稱 (*)";
            // 
            // _itemNameTextBox
            // 
            this._itemNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._itemNameTextBox.Enabled = false;
            this._itemNameTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this._itemNameTextBox.Location = new System.Drawing.Point(116, 8);
            this._itemNameTextBox.Name = "_itemNameTextBox";
            this._itemNameTextBox.Size = new System.Drawing.Size(449, 27);
            this._itemNameTextBox.TabIndex = 1;
            this._itemNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditName);
            // 
            // _tableLayoutPanel4
            // 
            this._tableLayoutPanel4.ColumnCount = 5;
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tableLayoutPanel4.Controls.Add(this._itemPriceLabel, 0, 0);
            this._tableLayoutPanel4.Controls.Add(this._itemPriceTextBox, 1, 0);
            this._tableLayoutPanel4.Controls.Add(this._unitLabel, 2, 0);
            this._tableLayoutPanel4.Controls.Add(this._itemCategoryLabel, 3, 0);
            this._tableLayoutPanel4.Controls.Add(this._itemCategoryComboBox, 4, 0);
            this._tableLayoutPanel4.Location = new System.Drawing.Point(3, 52);
            this._tableLayoutPanel4.Name = "_tableLayoutPanel4";
            this._tableLayoutPanel4.RowCount = 1;
            this._tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel4.Size = new System.Drawing.Size(568, 43);
            this._tableLayoutPanel4.TabIndex = 1;
            // 
            // _itemPriceLabel
            // 
            this._itemPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._itemPriceLabel.AutoSize = true;
            this._itemPriceLabel.Location = new System.Drawing.Point(13, 12);
            this._itemPriceLabel.Name = "_itemPriceLabel";
            this._itemPriceLabel.Size = new System.Drawing.Size(86, 19);
            this._itemPriceLabel.TabIndex = 0;
            this._itemPriceLabel.Text = "商品價格(*)";
            // 
            // _itemPriceTextBox
            // 
            this._itemPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._itemPriceTextBox.Enabled = false;
            this._itemPriceTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this._itemPriceTextBox.Location = new System.Drawing.Point(116, 8);
            this._itemPriceTextBox.Name = "_itemPriceTextBox";
            this._itemPriceTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._itemPriceTextBox.Size = new System.Drawing.Size(107, 27);
            this._itemPriceTextBox.TabIndex = 1;
            this._itemPriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputOnlyNumber);
            this._itemPriceTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditPrice);
            // 
            // _unitLabel
            // 
            this._unitLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._unitLabel.AutoSize = true;
            this._unitLabel.Location = new System.Drawing.Point(234, 12);
            this._unitLabel.Name = "_unitLabel";
            this._unitLabel.Size = new System.Drawing.Size(40, 19);
            this._unitLabel.TabIndex = 2;
            this._unitLabel.Text = "NTD";
            // 
            // _itemCategoryLabel
            // 
            this._itemCategoryLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._itemCategoryLabel.AutoSize = true;
            this._itemCategoryLabel.Location = new System.Drawing.Point(295, 12);
            this._itemCategoryLabel.Name = "_itemCategoryLabel";
            this._itemCategoryLabel.Size = new System.Drawing.Size(86, 19);
            this._itemCategoryLabel.TabIndex = 3;
            this._itemCategoryLabel.Text = "商品類別(*)";
            // 
            // _itemCategoryComboBox
            // 
            this._itemCategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._itemCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._itemCategoryComboBox.Enabled = false;
            this._itemCategoryComboBox.FormattingEnabled = true;
            this._itemCategoryComboBox.Items.AddRange(new object[] {
            "主機板",
            "CPU",
            "記憶體",
            "硬碟",
            "顯卡",
            "套裝電腦"});
            this._itemCategoryComboBox.Location = new System.Drawing.Point(398, 10);
            this._itemCategoryComboBox.Name = "_itemCategoryComboBox";
            this._itemCategoryComboBox.Size = new System.Drawing.Size(167, 27);
            this._itemCategoryComboBox.TabIndex = 4;
            this._itemCategoryComboBox.SelectionChangeCommitted += new System.EventHandler(this.EditType);
            // 
            // _tableLayoutPanel5
            // 
            this._tableLayoutPanel5.ColumnCount = 3;
            this._tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tableLayoutPanel5.Controls.Add(this._itemPicturePathLabel, 0, 0);
            this._tableLayoutPanel5.Controls.Add(this._itemPicturePathTextBox, 1, 0);
            this._tableLayoutPanel5.Controls.Add(this._searchButton, 2, 0);
            this._tableLayoutPanel5.Location = new System.Drawing.Point(3, 101);
            this._tableLayoutPanel5.Name = "_tableLayoutPanel5";
            this._tableLayoutPanel5.RowCount = 1;
            this._tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel5.Size = new System.Drawing.Size(568, 43);
            this._tableLayoutPanel5.TabIndex = 2;
            // 
            // _itemPicturePathLabel
            // 
            this._itemPicturePathLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._itemPicturePathLabel.AutoSize = true;
            this._itemPicturePathLabel.Location = new System.Drawing.Point(13, 12);
            this._itemPicturePathLabel.Name = "_itemPicturePathLabel";
            this._itemPicturePathLabel.Size = new System.Drawing.Size(116, 19);
            this._itemPicturePathLabel.TabIndex = 0;
            this._itemPicturePathLabel.Text = "商品圖片路徑(*)";
            // 
            // _itemPicturePathTextBox
            // 
            this._itemPicturePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._itemPicturePathTextBox.Enabled = false;
            this._itemPicturePathTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this._itemPicturePathTextBox.Location = new System.Drawing.Point(145, 8);
            this._itemPicturePathTextBox.Name = "_itemPicturePathTextBox";
            this._itemPicturePathTextBox.Size = new System.Drawing.Size(334, 27);
            this._itemPicturePathTextBox.TabIndex = 1;
            this._itemPicturePathTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditPath);
            // 
            // _searchButton
            // 
            this._searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this._searchButton.Enabled = false;
            this._searchButton.Location = new System.Drawing.Point(485, 5);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(80, 33);
            this._searchButton.TabIndex = 2;
            this._searchButton.Text = "瀏覽...";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this.ClickSearchButton);
            // 
            // _itemDescriptionLabel
            // 
            this._itemDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._itemDescriptionLabel.AutoSize = true;
            this._itemDescriptionLabel.Location = new System.Drawing.Point(3, 177);
            this._itemDescriptionLabel.Name = "_itemDescriptionLabel";
            this._itemDescriptionLabel.Size = new System.Drawing.Size(69, 19);
            this._itemDescriptionLabel.TabIndex = 3;
            this._itemDescriptionLabel.Text = "商品介紹";
            // 
            // _itemDescriptionTextBox
            // 
            this._itemDescriptionTextBox.Enabled = false;
            this._itemDescriptionTextBox.Location = new System.Drawing.Point(3, 199);
            this._itemDescriptionTextBox.Name = "_itemDescriptionTextBox";
            this._itemDescriptionTextBox.Size = new System.Drawing.Size(568, 246);
            this._itemDescriptionTextBox.TabIndex = 4;
            this._itemDescriptionTextBox.Text = "";
            this._itemDescriptionTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditDetail);
            // 
            // _saveItemButton
            // 
            this._saveItemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveItemButton.Location = new System.Drawing.Point(731, 477);
            this._saveItemButton.Name = "_saveItemButton";
            this._saveItemButton.Size = new System.Drawing.Size(111, 47);
            this._saveItemButton.TabIndex = 3;
            this._saveItemButton.Text = "儲存";
            this._saveItemButton.UseVisualStyleBackColor = true;
            this._saveItemButton.Click += new System.EventHandler(this.ClickSaveButton);
            // 
            // _itemsListBox
            // 
            this._itemsListBox.FormattingEnabled = true;
            this._itemsListBox.ItemHeight = 19;
            this._itemsListBox.Location = new System.Drawing.Point(3, 3);
            this._itemsListBox.Name = "_itemsListBox";
            this._itemsListBox.Size = new System.Drawing.Size(247, 460);
            this._itemsListBox.TabIndex = 4;
            this._itemsListBox.Click += new System.EventHandler(this.GetItemDetail);
            // 
            // _categoryManagementTabPage
            // 
            this._categoryManagementTabPage.Controls.Add(this._tableLayoutPanel6);
            this._categoryManagementTabPage.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._categoryManagementTabPage.Location = new System.Drawing.Point(4, 25);
            this._categoryManagementTabPage.Name = "_categoryManagementTabPage";
            this._categoryManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._categoryManagementTabPage.Size = new System.Drawing.Size(848, 532);
            this._categoryManagementTabPage.TabIndex = 1;
            this._categoryManagementTabPage.Text = "類別管理";
            this._categoryManagementTabPage.UseVisualStyleBackColor = true;
            // 
            // _tableLayoutPanel6
            // 
            this._tableLayoutPanel6.ColumnCount = 2;
            this._tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._tableLayoutPanel6.Controls.Add(this._saveCategoryButton, 1, 1);
            this._tableLayoutPanel6.Controls.Add(this._addNewCategoryButton, 0, 1);
            this._tableLayoutPanel6.Controls.Add(this._categoryListBox, 0, 0);
            this._tableLayoutPanel6.Controls.Add(this._categoryGroupBox, 1, 0);
            this._tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this._tableLayoutPanel6.Name = "_tableLayoutPanel6";
            this._tableLayoutPanel6.RowCount = 2;
            this._tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this._tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tableLayoutPanel6.Size = new System.Drawing.Size(842, 526);
            this._tableLayoutPanel6.TabIndex = 0;
            // 
            // _saveCategoryButton
            // 
            this._saveCategoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveCategoryButton.Enabled = false;
            this._saveCategoryButton.Location = new System.Drawing.Point(728, 476);
            this._saveCategoryButton.Name = "_saveCategoryButton";
            this._saveCategoryButton.Size = new System.Drawing.Size(111, 47);
            this._saveCategoryButton.TabIndex = 8;
            this._saveCategoryButton.Text = "新增";
            this._saveCategoryButton.UseVisualStyleBackColor = true;
            this._saveCategoryButton.Click += new System.EventHandler(this.ClickSaveCategoryButton);
            // 
            // _addNewCategoryButton
            // 
            this._addNewCategoryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addNewCategoryButton.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addNewCategoryButton.Location = new System.Drawing.Point(3, 476);
            this._addNewCategoryButton.Name = "_addNewCategoryButton";
            this._addNewCategoryButton.Size = new System.Drawing.Size(246, 47);
            this._addNewCategoryButton.TabIndex = 6;
            this._addNewCategoryButton.Text = "新增類別";
            this._addNewCategoryButton.UseVisualStyleBackColor = true;
            this._addNewCategoryButton.Click += new System.EventHandler(this.ClickAddNewCategoryButton);
            // 
            // _categoryListBox
            // 
            this._categoryListBox.FormattingEnabled = true;
            this._categoryListBox.ItemHeight = 19;
            this._categoryListBox.Location = new System.Drawing.Point(3, 3);
            this._categoryListBox.Name = "_categoryListBox";
            this._categoryListBox.Size = new System.Drawing.Size(246, 460);
            this._categoryListBox.TabIndex = 5;
            this._categoryListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowCategoryDetail);
            // 
            // _categoryGroupBox
            // 
            this._categoryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._categoryGroupBox.Controls.Add(this._productOfCategoryListBox);
            this._categoryGroupBox.Controls.Add(this._productOfCategoryTextLabel);
            this._categoryGroupBox.Controls.Add(this._categoryNameTextBox);
            this._categoryGroupBox.Controls.Add(this._categoryNameTextLabel);
            this._categoryGroupBox.Location = new System.Drawing.Point(255, 3);
            this._categoryGroupBox.Name = "_categoryGroupBox";
            this._categoryGroupBox.Size = new System.Drawing.Size(584, 467);
            this._categoryGroupBox.TabIndex = 7;
            this._categoryGroupBox.TabStop = false;
            this._categoryGroupBox.Text = "類別";
            // 
            // _productOfCategoryListBox
            // 
            this._productOfCategoryListBox.FormattingEnabled = true;
            this._productOfCategoryListBox.ItemHeight = 19;
            this._productOfCategoryListBox.Location = new System.Drawing.Point(0, 147);
            this._productOfCategoryListBox.Name = "_productOfCategoryListBox";
            this._productOfCategoryListBox.Size = new System.Drawing.Size(578, 308);
            this._productOfCategoryListBox.TabIndex = 3;
            // 
            // _productOfCategoryTextLabel
            // 
            this._productOfCategoryTextLabel.AutoSize = true;
            this._productOfCategoryTextLabel.Location = new System.Drawing.Point(0, 127);
            this._productOfCategoryTextLabel.Name = "_productOfCategoryTextLabel";
            this._productOfCategoryTextLabel.Size = new System.Drawing.Size(84, 19);
            this._productOfCategoryTextLabel.TabIndex = 2;
            this._productOfCategoryTextLabel.Text = "類別內產品";
            // 
            // _categoryNameTextBox
            // 
            this._categoryNameTextBox.Enabled = false;
            this._categoryNameTextBox.Location = new System.Drawing.Point(112, 56);
            this._categoryNameTextBox.Name = "_categoryNameTextBox";
            this._categoryNameTextBox.Size = new System.Drawing.Size(459, 27);
            this._categoryNameTextBox.TabIndex = 1;
            this._categoryNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputNoNumber);
            this._categoryNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditCategoryName);
            // 
            // _categoryNameTextLabel
            // 
            this._categoryNameTextLabel.AutoSize = true;
            this._categoryNameTextLabel.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._categoryNameTextLabel.Location = new System.Drawing.Point(0, 56);
            this._categoryNameTextLabel.Name = "_categoryNameTextLabel";
            this._categoryNameTextLabel.Size = new System.Drawing.Size(96, 22);
            this._categoryNameTextLabel.TabIndex = 0;
            this._categoryNameTextLabel.Text = "類別名稱(*)";
            // 
            // ProductManagementSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 634);
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "ProductManagementSystem";
            this.Text = "ProductManagementSystem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CancelEvent);
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this._managementTabControl.ResumeLayout(false);
            this._itemManagementTabPage.ResumeLayout(false);
            this._tableLayoutPanel1.ResumeLayout(false);
            this._titleGroupBox.ResumeLayout(false);
            this._tableLayoutPanel2.ResumeLayout(false);
            this._tableLayoutPanel2.PerformLayout();
            this._tableLayoutPanel3.ResumeLayout(false);
            this._tableLayoutPanel3.PerformLayout();
            this._tableLayoutPanel4.ResumeLayout(false);
            this._tableLayoutPanel4.PerformLayout();
            this._tableLayoutPanel5.ResumeLayout(false);
            this._tableLayoutPanel5.PerformLayout();
            this._categoryManagementTabPage.ResumeLayout(false);
            this._tableLayoutPanel6.ResumeLayout(false);
            this._categoryGroupBox.ResumeLayout(false);
            this._categoryGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.TabControl _managementTabControl;
        private System.Windows.Forms.TabPage _itemManagementTabPage;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel1;
        private System.Windows.Forms.Button _addNewItemButton;
        private System.Windows.Forms.GroupBox _titleGroupBox;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel3;
        private System.Windows.Forms.Label _itemNameLabel;
        private System.Windows.Forms.TextBox _itemNameTextBox;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel4;
        private System.Windows.Forms.Label _itemPriceLabel;
        private System.Windows.Forms.TextBox _itemPriceTextBox;
        private System.Windows.Forms.Label _unitLabel;
        private System.Windows.Forms.Label _itemCategoryLabel;
        private System.Windows.Forms.ComboBox _itemCategoryComboBox;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel5;
        private System.Windows.Forms.Label _itemPicturePathLabel;
        private System.Windows.Forms.TextBox _itemPicturePathTextBox;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.Label _itemDescriptionLabel;
        private System.Windows.Forms.RichTextBox _itemDescriptionTextBox;
        private System.Windows.Forms.Button _saveItemButton;
        private System.Windows.Forms.TabPage _categoryManagementTabPage;
        private System.Windows.Forms.ListBox _itemsListBox;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel6;
        private System.Windows.Forms.Button _addNewCategoryButton;
        private System.Windows.Forms.ListBox _categoryListBox;
        private System.Windows.Forms.GroupBox _categoryGroupBox;
        private System.Windows.Forms.Label _categoryNameTextLabel;
        private System.Windows.Forms.Label _productOfCategoryTextLabel;
        private System.Windows.Forms.TextBox _categoryNameTextBox;
        private System.Windows.Forms.Button _saveCategoryButton;
        private System.Windows.Forms.ListBox _productOfCategoryListBox;
    }
}