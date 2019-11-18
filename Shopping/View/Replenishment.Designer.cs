namespace ShopList.View
{
    partial class Replenishment
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
            this._buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._confirmButton = new System.Windows.Forms.Button();
            this._replenishmentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._itemReplenishmentNumberLabel = new System.Windows.Forms.Label();
            this._replenishmentTextBox = new System.Windows.Forms.TextBox();
            this._stockTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._itemStockLabel = new System.Windows.Forms.Label();
            this._itemNumberTextLabel = new System.Windows.Forms.Label();
            this._itemPriceTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._itemPriceLabel = new System.Windows.Forms.Label();
            this._itemPriceTextLabel = new System.Windows.Forms.Label();
            this._itemTypeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._itemTypeLabel = new System.Windows.Forms.Label();
            this._itemTypeTextLabel = new System.Windows.Forms.Label();
            this._titleLabel = new System.Windows.Forms.Label();
            this._itemNameTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._itemNameTextLabel = new System.Windows.Forms.Label();
            this._itemNameLabel = new System.Windows.Forms.Label();
            this._tableLayoutPanel.SuspendLayout();
            this._buttonTableLayoutPanel.SuspendLayout();
            this._replenishmentTableLayoutPanel.SuspendLayout();
            this._stockTableLayoutPanel.SuspendLayout();
            this._itemPriceTableLayoutPanel.SuspendLayout();
            this._itemTypeTableLayoutPanel.SuspendLayout();
            this._itemNameTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Controls.Add(this._buttonTableLayoutPanel, 0, 6);
            this._tableLayoutPanel.Controls.Add(this._replenishmentTableLayoutPanel, 0, 5);
            this._tableLayoutPanel.Controls.Add(this._stockTableLayoutPanel, 0, 4);
            this._tableLayoutPanel.Controls.Add(this._itemPriceTableLayoutPanel, 0, 3);
            this._tableLayoutPanel.Controls.Add(this._itemTypeTableLayoutPanel, 0, 2);
            this._tableLayoutPanel.Controls.Add(this._titleLabel, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._itemNameTableLayoutPanel, 0, 1);
            this._tableLayoutPanel.Location = new System.Drawing.Point(2, 1);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 7;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.91892F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.51351F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(509, 494);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // _buttonTableLayoutPanel
            // 
            this._buttonTableLayoutPanel.ColumnCount = 2;
            this._buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonTableLayoutPanel.Controls.Add(this._cancelButton, 1, 0);
            this._buttonTableLayoutPanel.Controls.Add(this._confirmButton, 0, 0);
            this._buttonTableLayoutPanel.Location = new System.Drawing.Point(3, 426);
            this._buttonTableLayoutPanel.Name = "_buttonTableLayoutPanel";
            this._buttonTableLayoutPanel.RowCount = 1;
            this._buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonTableLayoutPanel.Size = new System.Drawing.Size(503, 60);
            this._buttonTableLayoutPanel.TabIndex = 6;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._cancelButton.BackColor = System.Drawing.Color.Salmon;
            this._cancelButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._cancelButton.ForeColor = System.Drawing.Color.DarkRed;
            this._cancelButton.Location = new System.Drawing.Point(263, 10);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(227, 40);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "取消";
            this._cancelButton.UseVisualStyleBackColor = false;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _confirmButton
            // 
            this._confirmButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._confirmButton.BackColor = System.Drawing.Color.PaleGreen;
            this._confirmButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._confirmButton.ForeColor = System.Drawing.Color.Green;
            this._confirmButton.Location = new System.Drawing.Point(12, 10);
            this._confirmButton.Name = "_confirmButton";
            this._confirmButton.Size = new System.Drawing.Size(227, 40);
            this._confirmButton.TabIndex = 0;
            this._confirmButton.Text = "確認";
            this._confirmButton.UseVisualStyleBackColor = false;
            this._confirmButton.Click += new System.EventHandler(this.ClickConfirmButton);
            // 
            // _replenishmentTableLayoutPanel
            // 
            this._replenishmentTableLayoutPanel.ColumnCount = 2;
            this._replenishmentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._replenishmentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._replenishmentTableLayoutPanel.Controls.Add(this._itemReplenishmentNumberLabel, 0, 0);
            this._replenishmentTableLayoutPanel.Controls.Add(this._replenishmentTextBox, 1, 0);
            this._replenishmentTableLayoutPanel.Location = new System.Drawing.Point(3, 360);
            this._replenishmentTableLayoutPanel.Name = "_replenishmentTableLayoutPanel";
            this._replenishmentTableLayoutPanel.RowCount = 1;
            this._replenishmentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._replenishmentTableLayoutPanel.Size = new System.Drawing.Size(503, 60);
            this._replenishmentTableLayoutPanel.TabIndex = 5;
            // 
            // _itemReplenishmentNumberLabel
            // 
            this._itemReplenishmentNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemReplenishmentNumberLabel.AutoSize = true;
            this._itemReplenishmentNumberLabel.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemReplenishmentNumberLabel.Location = new System.Drawing.Point(3, 14);
            this._itemReplenishmentNumberLabel.Name = "_itemReplenishmentNumberLabel";
            this._itemReplenishmentNumberLabel.Size = new System.Drawing.Size(126, 31);
            this._itemReplenishmentNumberLabel.TabIndex = 1;
            this._itemReplenishmentNumberLabel.Text = "補貨數量 :";
            // 
            // _replenishmentTextBox
            // 
            this._replenishmentTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._replenishmentTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._replenishmentTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this._replenishmentTextBox.Location = new System.Drawing.Point(153, 13);
            this._replenishmentTextBox.Name = "_replenishmentTextBox";
            this._replenishmentTextBox.Size = new System.Drawing.Size(100, 34);
            this._replenishmentTextBox.TabIndex = 2;
            this._replenishmentTextBox.Click += new System.EventHandler(this.ConfirmConfirmButton);
            this._replenishmentTextBox.TextChanged += new System.EventHandler(this.ConfirmConfirmButton);
            this._replenishmentTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputOnlyNumber);
            // 
            // _stockTableLayoutPanel
            // 
            this._stockTableLayoutPanel.ColumnCount = 2;
            this._stockTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._stockTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._stockTableLayoutPanel.Controls.Add(this._itemStockLabel, 0, 0);
            this._stockTableLayoutPanel.Controls.Add(this._itemNumberTextLabel, 0, 0);
            this._stockTableLayoutPanel.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._stockTableLayoutPanel.Location = new System.Drawing.Point(3, 294);
            this._stockTableLayoutPanel.Name = "_stockTableLayoutPanel";
            this._stockTableLayoutPanel.RowCount = 1;
            this._stockTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._stockTableLayoutPanel.Size = new System.Drawing.Size(503, 60);
            this._stockTableLayoutPanel.TabIndex = 4;
            // 
            // _itemStockLabel
            // 
            this._itemStockLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemStockLabel.AutoSize = true;
            this._itemStockLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemStockLabel.Location = new System.Drawing.Point(153, 17);
            this._itemStockLabel.Name = "_itemStockLabel";
            this._itemStockLabel.Size = new System.Drawing.Size(0, 25);
            this._itemStockLabel.TabIndex = 2;
            // 
            // _itemNumberTextLabel
            // 
            this._itemNumberTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemNumberTextLabel.AutoSize = true;
            this._itemNumberTextLabel.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemNumberTextLabel.Location = new System.Drawing.Point(3, 14);
            this._itemNumberTextLabel.Name = "_itemNumberTextLabel";
            this._itemNumberTextLabel.Size = new System.Drawing.Size(126, 31);
            this._itemNumberTextLabel.TabIndex = 1;
            this._itemNumberTextLabel.Text = "庫存數量 :";
            // 
            // _itemPriceTableLayoutPanel
            // 
            this._itemPriceTableLayoutPanel.ColumnCount = 2;
            this._itemPriceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._itemPriceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._itemPriceTableLayoutPanel.Controls.Add(this._itemPriceLabel, 0, 0);
            this._itemPriceTableLayoutPanel.Controls.Add(this._itemPriceTextLabel, 0, 0);
            this._itemPriceTableLayoutPanel.Location = new System.Drawing.Point(3, 228);
            this._itemPriceTableLayoutPanel.Name = "_itemPriceTableLayoutPanel";
            this._itemPriceTableLayoutPanel.RowCount = 1;
            this._itemPriceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._itemPriceTableLayoutPanel.Size = new System.Drawing.Size(503, 60);
            this._itemPriceTableLayoutPanel.TabIndex = 3;
            // 
            // _itemPriceLabel
            // 
            this._itemPriceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemPriceLabel.AutoSize = true;
            this._itemPriceLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemPriceLabel.Location = new System.Drawing.Point(153, 17);
            this._itemPriceLabel.Name = "_itemPriceLabel";
            this._itemPriceLabel.Size = new System.Drawing.Size(0, 25);
            this._itemPriceLabel.TabIndex = 2;
            // 
            // _itemPriceTextLabel
            // 
            this._itemPriceTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemPriceTextLabel.AutoSize = true;
            this._itemPriceTextLabel.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemPriceTextLabel.Location = new System.Drawing.Point(3, 14);
            this._itemPriceTextLabel.Name = "_itemPriceTextLabel";
            this._itemPriceTextLabel.Size = new System.Drawing.Size(126, 31);
            this._itemPriceTextLabel.TabIndex = 1;
            this._itemPriceTextLabel.Text = "商品單價 :";
            // 
            // _itemTypeTableLayoutPanel
            // 
            this._itemTypeTableLayoutPanel.ColumnCount = 2;
            this._itemTypeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._itemTypeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._itemTypeTableLayoutPanel.Controls.Add(this._itemTypeLabel, 0, 0);
            this._itemTypeTableLayoutPanel.Controls.Add(this._itemTypeTextLabel, 0, 0);
            this._itemTypeTableLayoutPanel.Location = new System.Drawing.Point(3, 162);
            this._itemTypeTableLayoutPanel.Name = "_itemTypeTableLayoutPanel";
            this._itemTypeTableLayoutPanel.RowCount = 1;
            this._itemTypeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._itemTypeTableLayoutPanel.Size = new System.Drawing.Size(503, 60);
            this._itemTypeTableLayoutPanel.TabIndex = 2;
            // 
            // _itemTypeLabel
            // 
            this._itemTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemTypeLabel.AutoSize = true;
            this._itemTypeLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemTypeLabel.Location = new System.Drawing.Point(153, 17);
            this._itemTypeLabel.Name = "_itemTypeLabel";
            this._itemTypeLabel.Size = new System.Drawing.Size(0, 25);
            this._itemTypeLabel.TabIndex = 2;
            // 
            // _itemTypeTextLabel
            // 
            this._itemTypeTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemTypeTextLabel.AutoSize = true;
            this._itemTypeTextLabel.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemTypeTextLabel.Location = new System.Drawing.Point(3, 14);
            this._itemTypeTextLabel.Name = "_itemTypeTextLabel";
            this._itemTypeTextLabel.Size = new System.Drawing.Size(126, 31);
            this._itemTypeTextLabel.TabIndex = 1;
            this._itemTypeTextLabel.Text = "商品類別 :";
            // 
            // _titleLabel
            // 
            this._titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._titleLabel.AutoSize = true;
            this._titleLabel.Font = new System.Drawing.Font("微軟正黑體", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._titleLabel.Location = new System.Drawing.Point(178, 19);
            this._titleLabel.Name = "_titleLabel";
            this._titleLabel.Size = new System.Drawing.Size(153, 55);
            this._titleLabel.TabIndex = 0;
            this._titleLabel.Text = "補貨單";
            // 
            // _itemNameTableLayoutPanel
            // 
            this._itemNameTableLayoutPanel.ColumnCount = 2;
            this._itemNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this._itemNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this._itemNameTableLayoutPanel.Controls.Add(this._itemNameTextLabel, 0, 0);
            this._itemNameTableLayoutPanel.Controls.Add(this._itemNameLabel, 1, 0);
            this._itemNameTableLayoutPanel.Location = new System.Drawing.Point(3, 96);
            this._itemNameTableLayoutPanel.Name = "_itemNameTableLayoutPanel";
            this._itemNameTableLayoutPanel.RowCount = 1;
            this._itemNameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._itemNameTableLayoutPanel.Size = new System.Drawing.Size(503, 60);
            this._itemNameTableLayoutPanel.TabIndex = 1;
            // 
            // _itemNameTextLabel
            // 
            this._itemNameTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemNameTextLabel.AutoSize = true;
            this._itemNameTextLabel.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemNameTextLabel.Location = new System.Drawing.Point(3, 14);
            this._itemNameTextLabel.Name = "_itemNameTextLabel";
            this._itemNameTextLabel.Size = new System.Drawing.Size(126, 31);
            this._itemNameTextLabel.TabIndex = 0;
            this._itemNameTextLabel.Text = "商品名稱 :";
            // 
            // _itemNameLabel
            // 
            this._itemNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._itemNameLabel.AutoSize = true;
            this._itemNameLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._itemNameLabel.Location = new System.Drawing.Point(153, 17);
            this._itemNameLabel.Name = "_itemNameLabel";
            this._itemNameLabel.Size = new System.Drawing.Size(0, 25);
            this._itemNameLabel.TabIndex = 1;
            // 
            // Replenishment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 497);
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "Replenishment";
            this.Text = "Replenishment";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this._buttonTableLayoutPanel.ResumeLayout(false);
            this._replenishmentTableLayoutPanel.ResumeLayout(false);
            this._replenishmentTableLayoutPanel.PerformLayout();
            this._stockTableLayoutPanel.ResumeLayout(false);
            this._stockTableLayoutPanel.PerformLayout();
            this._itemPriceTableLayoutPanel.ResumeLayout(false);
            this._itemPriceTableLayoutPanel.PerformLayout();
            this._itemTypeTableLayoutPanel.ResumeLayout(false);
            this._itemTypeTableLayoutPanel.PerformLayout();
            this._itemNameTableLayoutPanel.ResumeLayout(false);
            this._itemNameTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel _buttonTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel _replenishmentTableLayoutPanel;
        private System.Windows.Forms.Label _itemReplenishmentNumberLabel;
        private System.Windows.Forms.TableLayoutPanel _stockTableLayoutPanel;
        private System.Windows.Forms.Label _itemNumberTextLabel;
        private System.Windows.Forms.TableLayoutPanel _itemPriceTableLayoutPanel;
        private System.Windows.Forms.Label _itemPriceTextLabel;
        private System.Windows.Forms.TableLayoutPanel _itemTypeTableLayoutPanel;
        private System.Windows.Forms.Label _itemTypeTextLabel;
        private System.Windows.Forms.Label _titleLabel;
        private System.Windows.Forms.TableLayoutPanel _itemNameTableLayoutPanel;
        private System.Windows.Forms.Label _itemNameTextLabel;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _confirmButton;
        private System.Windows.Forms.TextBox _replenishmentTextBox;
        private System.Windows.Forms.Label _itemStockLabel;
        private System.Windows.Forms.Label _itemPriceLabel;
        private System.Windows.Forms.Label _itemTypeLabel;
        private System.Windows.Forms.Label _itemNameLabel;
    }
}