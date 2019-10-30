namespace ShopList
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._orderSystemButton = new System.Windows.Forms.Button();
            this._inventorySystemButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this._productManagementSystemButton = new System.Windows.Forms.Button();
            this._buttonTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonTableLayoutPanel
            // 
            this._buttonTableLayoutPanel.ColumnCount = 1;
            this._buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._buttonTableLayoutPanel.Controls.Add(this._orderSystemButton, 0, 0);
            this._buttonTableLayoutPanel.Controls.Add(this._inventorySystemButton, 0, 1);
            this._buttonTableLayoutPanel.Controls.Add(this._exitButton, 0, 3);
            this._buttonTableLayoutPanel.Controls.Add(this._productManagementSystemButton, 0, 2);
            this._buttonTableLayoutPanel.Location = new System.Drawing.Point(1, 2);
            this._buttonTableLayoutPanel.Name = "_buttonTableLayoutPanel";
            this._buttonTableLayoutPanel.RowCount = 4;
            this._buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this._buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this._buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this._buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
            this._buttonTableLayoutPanel.Size = new System.Drawing.Size(795, 447);
            this._buttonTableLayoutPanel.TabIndex = 0;
            // 
            // _orderSystemButton
            // 
            this._orderSystemButton.BackColor = System.Drawing.SystemColors.Control;
            this._orderSystemButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._orderSystemButton.Font = new System.Drawing.Font("微軟正黑體", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._orderSystemButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._orderSystemButton.Location = new System.Drawing.Point(3, 3);
            this._orderSystemButton.Name = "_orderSystemButton";
            this._orderSystemButton.Size = new System.Drawing.Size(789, 105);
            this._orderSystemButton.TabIndex = 0;
            this._orderSystemButton.Text = "Order System";
            this._orderSystemButton.UseVisualStyleBackColor = false;
            this._orderSystemButton.Click += new System.EventHandler(this.ClickOrderSystemButton);
            // 
            // _inventorySystemButton
            // 
            this._inventorySystemButton.BackColor = System.Drawing.SystemColors.Control;
            this._inventorySystemButton.Font = new System.Drawing.Font("微軟正黑體", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._inventorySystemButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._inventorySystemButton.Location = new System.Drawing.Point(3, 114);
            this._inventorySystemButton.Name = "_inventorySystemButton";
            this._inventorySystemButton.Size = new System.Drawing.Size(789, 105);
            this._inventorySystemButton.TabIndex = 1;
            this._inventorySystemButton.Text = "Inventory System";
            this._inventorySystemButton.UseVisualStyleBackColor = false;
            this._inventorySystemButton.Click += new System.EventHandler(this.ClickInventorySystemButton);
            // 
            // _exitButton
            // 
            this._exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._exitButton.Font = new System.Drawing.Font("新細明體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(5)));
            this._exitButton.Location = new System.Drawing.Point(640, 392);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(152, 52);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ClickExitButton);
            // 
            // _productManagementSystemButton
            // 
            this._productManagementSystemButton.BackColor = System.Drawing.SystemColors.Control;
            this._productManagementSystemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._productManagementSystemButton.Font = new System.Drawing.Font("微軟正黑體", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._productManagementSystemButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._productManagementSystemButton.Location = new System.Drawing.Point(3, 225);
            this._productManagementSystemButton.Name = "_productManagementSystemButton";
            this._productManagementSystemButton.Size = new System.Drawing.Size(789, 105);
            this._productManagementSystemButton.TabIndex = 3;
            this._productManagementSystemButton.Text = "Product Management System";
            this._productManagementSystemButton.UseVisualStyleBackColor = false;
            this._productManagementSystemButton.Click += new System.EventHandler(this.ClickProductManagementSystemButton);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._buttonTableLayoutPanel);
            this.Name = "MenuForm";
            this.Text = "Menu";
            this._buttonTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _buttonTableLayoutPanel;
        private System.Windows.Forms.Button _orderSystemButton;
        private System.Windows.Forms.Button _inventorySystemButton;
        private System.Windows.Forms.Button _exitButton;
        private System.Windows.Forms.Button _productManagementSystemButton;
    }
}