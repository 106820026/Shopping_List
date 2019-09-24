namespace ShopList
{
    partial class InventorySystem
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
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._label = new System.Windows.Forms.Label();
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.Controls.Add(this._label, 0, 0);
            this._tableLayoutPanel.Location = new System.Drawing.Point(1, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 1;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(797, 451);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // _label
            // 
            this._label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._label.AutoSize = true;
            this._label.Font = new System.Drawing.Font("新細明體", 50F);
            this._label.Location = new System.Drawing.Point(163, 183);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(471, 84);
            this._label.TabIndex = 0;
            this._label.Text = "Coming Soon";
            // 
            // _inventorySystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "_inventorySystem";
            this.Text = "InventorySystem";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Label _label;
    }
}