﻿using System;
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
    public partial class InventorySystem : Form
    {
        const String FILE_PATH = "../../Data Info.ini";
        Initial _initial;
        InventorySystemControl _inventorySystemControl;
        const String REPLENISHMENT_COLUMN = "_replenishment";
        const int NUMBER_COLUMN_INDEX = 3;
        const int REPLENISHMENT_COLUMN_INDEX = 4;
        int _currentRow;

        public InventorySystem(Initial initial)
        {
            InitializeComponent();
            this._initial = initial;
            _inventorySystemControl = new InventorySystemControl(_initial);
            _initial._writeNewData += UpdateStock;
            this.LoadAndShowDataGridView();
        }

        // 加入補貨icon
        private void PaintDataGridViewCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == REPLENISHMENT_COLUMN)
            {
                const int LEFT_OFFSET = 13;
                const int TOP_OFFSET = 3;
                const int PICTURE_SIZE = 20;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                // DrawImage(圖片, x軸, y軸, 長, 寬)
                e.Graphics.DrawImage(global::ShopList.Properties.Resources._replenishmentIcon, e.CellBounds.Left + LEFT_OFFSET, e.CellBounds.Top + TOP_OFFSET, PICTURE_SIZE, PICTURE_SIZE);
                e.Handled = true;//false的話 圖片不穩定
            }
        }

        // click表格
        private void ClickItem(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            else
            {
                _currentRow = e.RowIndex; // 取得目前row Index
                _itemPictureBox.Image = _inventorySystemControl.GetImageFilePath(((DataGridView)sender).Rows[e.RowIndex].Index);
                _itemDetailTextBox.Text = _inventorySystemControl.GetItemDetail(((DataGridView)sender).Rows[e.RowIndex].Index);
                if (e.ColumnIndex == REPLENISHMENT_COLUMN_INDEX) // 如果按補貨按鈕
                    _inventorySystemControl.OpenReplenishmentPage(((DataGridView)sender).Rows[e.RowIndex].Index);
            }
        }

        // 讀取DaraGridView資料 並顯示
        private void LoadAndShowDataGridView()
        {
            foreach (String[] item in _inventorySystemControl.GetAllItemDetail()) // 把所有商品資訊放入DataGridView
                _itemDataGridView.Rows.Add(item);
        }

        // 更新庫存數量
        private void UpdateStock()
        {
            for(int i=0; i<_initial.GetAllItemList().Count; i++)
            _itemDataGridView.Rows[i].Cells[NUMBER_COLUMN_INDEX].Value = _inventorySystemControl.GetStock(i);
        }

        // 解除event
        private void CancelEvent(object sender, FormClosedEventArgs e)
        {
            _initial._writeNewData -= UpdateStock;
            this.Dispose();
        }
    }
}
