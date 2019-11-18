namespace ShopList.View
{
    partial class InventorySystem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this._titleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._titleLabel = new System.Windows.Forms.Label();
            this._contentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._itemDataGridView = new System.Windows.Forms.DataGridView();
            this._detailTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._itemPictureTitleLabel = new System.Windows.Forms.Label();
            this._itemDetailTitleLabel = new System.Windows.Forms.Label();
            this._itemPictureBox = new System.Windows.Forms.PictureBox();
            this._itemDetailTextBox = new System.Windows.Forms.RichTextBox();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._replenishment = new System.Windows.Forms.DataGridViewButtonColumn();
            this._titleTableLayoutPanel.SuspendLayout();
            this._contentTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._itemDataGridView)).BeginInit();
            this._detailTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._itemPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _titleTableLayoutPanel
            // 
            this._titleTableLayoutPanel.ColumnCount = 1;
            this._titleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._titleTableLayoutPanel.Controls.Add(this._titleLabel, 0, 0);
            this._titleTableLayoutPanel.Location = new System.Drawing.Point(1, 0);
            this._titleTableLayoutPanel.Name = "_titleTableLayoutPanel";
            this._titleTableLayoutPanel.RowCount = 1;
            this._titleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._titleTableLayoutPanel.Size = new System.Drawing.Size(1005, 54);
            this._titleTableLayoutPanel.TabIndex = 0;
            // 
            // _titleLabel
            // 
            this._titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._titleLabel.AutoSize = true;
            this._titleLabel.Font = new System.Drawing.Font("微軟正黑體", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._titleLabel.Location = new System.Drawing.Point(362, 0);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(281, 54);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "庫存管理系統";
            // 
            // _contentTableLayoutPanel
            // 
            this._contentTableLayoutPanel.ColumnCount = 2;
            this._contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._contentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._contentTableLayoutPanel.Controls.Add(this._itemDataGridView, 0, 0);
            this._contentTableLayoutPanel.Controls.Add(this._detailTableLayoutPanel, 1, 0);
            this._contentTableLayoutPanel.Location = new System.Drawing.Point(1, 61);
            this._contentTableLayoutPanel.Name = "_contentTableLayoutPanel";
            this._contentTableLayoutPanel.RowCount = 1;
            this._contentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._contentTableLayoutPanel.Size = new System.Drawing.Size(1005, 658);
            this._contentTableLayoutPanel.TabIndex = 1;
            // 
            // _itemDataGridView
            // 
            this._itemDataGridView.AllowUserToAddRows = false;
            this._itemDataGridView.AllowUserToResizeRows = false;
            this._itemDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._itemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._name,
            this._type,
            this._price,
            this._number,
            this._replenishment});
            this._itemDataGridView.Location = new System.Drawing.Point(3, 3);
            this._itemDataGridView.MultiSelect = false;
            this._itemDataGridView.Name = "_itemDataGridView";
            this._itemDataGridView.ReadOnly = true;
            this._itemDataGridView.RowHeadersVisible = false;
            this._itemDataGridView.RowTemplate.Height = 27;
            this._itemDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._itemDataGridView.Size = new System.Drawing.Size(697, 652);
            this._itemDataGridView.TabIndex = 0;
            this._itemDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickItem);
            this._itemDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.PaintDataGridViewCell);
            // 
            // _detailTableLayoutPanel
            // 
            this._detailTableLayoutPanel.ColumnCount = 1;
            this._detailTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._detailTableLayoutPanel.Controls.Add(this._itemPictureTitleLabel, 0, 0);
            this._detailTableLayoutPanel.Controls.Add(this._itemDetailTitleLabel, 0, 2);
            this._detailTableLayoutPanel.Controls.Add(this._itemPictureBox, 0, 1);
            this._detailTableLayoutPanel.Controls.Add(this._itemDetailTextBox, 0, 3);
            this._detailTableLayoutPanel.Location = new System.Drawing.Point(706, 3);
            this._detailTableLayoutPanel.Name = "_detailTableLayoutPanel";
            this._detailTableLayoutPanel.RowCount = 4;
            this._detailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this._detailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this._detailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this._detailTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this._detailTableLayoutPanel.Size = new System.Drawing.Size(296, 652);
            this._detailTableLayoutPanel.TabIndex = 1;
            // 
            // _itemPictureTitleLabel
            // 
            this._itemPictureTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemPictureTitleLabel.AutoSize = true;
            this._itemPictureTitleLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemPictureTitleLabel.Location = new System.Drawing.Point(3, 3);
            this._itemPictureTitleLabel.Name = "_itemPictureTitleLabel";
            this._itemPictureTitleLabel.Size = new System.Drawing.Size(102, 25);
            this._itemPictureTitleLabel.TabIndex = 0;
            this._itemPictureTitleLabel.Text = "商品圖片 :";
            // 
            // _itemDetailTitleLabel
            // 
            this._itemDetailTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemDetailTitleLabel.AutoSize = true;
            this._itemDetailTitleLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemDetailTitleLabel.Location = new System.Drawing.Point(3, 328);
            this._itemDetailTitleLabel.Name = "_itemDetailTitleLabel";
            this._itemDetailTitleLabel.Size = new System.Drawing.Size(102, 25);
            this._itemDetailTitleLabel.TabIndex = 1;
            this._itemDetailTitleLabel.Text = "商品介紹 :";
            // 
            // _itemPictureBox
            // 
            this._itemPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._itemPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._itemPictureBox.Location = new System.Drawing.Point(3, 35);
            this._itemPictureBox.Name = "_itemPictureBox";
            this._itemPictureBox.Size = new System.Drawing.Size(290, 287);
            this._itemPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._itemPictureBox.TabIndex = 2;
            this._itemPictureBox.TabStop = false;
            // 
            // _itemDetailTextBox
            // 
            this._itemDetailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._itemDetailTextBox.Enabled = false;
            this._itemDetailTextBox.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this._itemDetailTextBox.Location = new System.Drawing.Point(3, 360);
            this._itemDetailTextBox.Name = "_itemDetailTextBox";
            this._itemDetailTextBox.Size = new System.Drawing.Size(290, 285);
            this._itemDetailTextBox.TabIndex = 3;
            this._itemDetailTextBox.Text = "";
            // 
            // _name
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._name.DefaultCellStyle = dataGridViewCellStyle1;
            this._name.FillWeight = 150F;
            this._name.HeaderText = "商品名稱";
            this._name.Name = "_name";
            this._name.ReadOnly = true;
            this._name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _type
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._type.DefaultCellStyle = dataGridViewCellStyle2;
            this._type.HeaderText = "商品類別";
            this._type.Name = "_type";
            this._type.ReadOnly = true;
            this._type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _price
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._price.DefaultCellStyle = dataGridViewCellStyle3;
            this._price.HeaderText = "單價";
            this._price.Name = "_price";
            this._price.ReadOnly = true;
            this._price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _number
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._number.DefaultCellStyle = dataGridViewCellStyle4;
            this._number.HeaderText = "數量";
            this._number.Name = "_number";
            this._number.ReadOnly = true;
            this._number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // _replenishment
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._replenishment.DefaultCellStyle = dataGridViewCellStyle5;
            this._replenishment.FillWeight = 50F;
            this._replenishment.HeaderText = "補貨";
            this._replenishment.Name = "_replenishment";
            this._replenishment.ReadOnly = true;
            this._replenishment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // InventorySystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this._contentTableLayoutPanel);
            this.Controls.Add(this._titleTableLayoutPanel);
            this.Name = "InventorySystem";
            this.Text = "InventorySystem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CancelEvent);
            this._titleTableLayoutPanel.ResumeLayout(false);
            this._titleTableLayoutPanel.PerformLayout();
            this._contentTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._itemDataGridView)).EndInit();
            this._detailTableLayoutPanel.ResumeLayout(false);
            this._detailTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._itemPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _titleTableLayoutPanel;
        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.TableLayoutPanel _contentTableLayoutPanel;
        private System.Windows.Forms.DataGridView _itemDataGridView;
        private System.Windows.Forms.TableLayoutPanel _detailTableLayoutPanel;
        private System.Windows.Forms.Label _itemPictureTitleLabel;
        private System.Windows.Forms.Label _itemDetailTitleLabel;
        private System.Windows.Forms.PictureBox _itemPictureBox;
        private System.Windows.Forms.RichTextBox _itemDetailTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _type;
        private System.Windows.Forms.DataGridViewTextBoxColumn _price;
        private System.Windows.Forms.DataGridViewTextBoxColumn _number;
        private System.Windows.Forms.DataGridViewButtonColumn _replenishment;
    }
}