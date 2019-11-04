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
    public partial class InventorySystem : Form
    {
        InventorySystemPresentationModel _inventorySystemPresentationModel;
        ProductManagement _productManagement;
        const String REPLENISHMENT_COLUMN = "_replenishment";
        const int NAME_COLUMN_INDEX = 0;
        const int TYPE_COLUMN_INDEX = 1;
        const int PRICE_COLUMN_INDEX = 2;
        const int STOCK_COLUMN_INDEX = 3;
        const int REPLENISHMENT_COLUMN_INDEX = 4;
        int _currentRow;

        public InventorySystem(ReadFile initial, ProductManagement productManagement)
        {
            InitializeComponent();
            _productManagement = productManagement;
            _inventorySystemPresentationModel = new InventorySystemPresentationModel(_productManagement);
            _productManagement._writeNewData += UpdateProductData;
            this.LoadAndShowDataGridView();
            _itemPictureBox.Image = _inventorySystemPresentationModel.GetImageFilePath(0);
            _itemDetailTextBox.Text = _inventorySystemPresentationModel.GetItemDetail(0);
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
                _itemPictureBox.Image = _inventorySystemPresentationModel.GetImageFilePath(((DataGridView)sender).Rows[e.RowIndex].Index);
                _itemDetailTextBox.Text = _inventorySystemPresentationModel.GetItemDetail(((DataGridView)sender).Rows[e.RowIndex].Index);
                if (e.ColumnIndex == REPLENISHMENT_COLUMN_INDEX) // 如果按補貨按鈕
                    _inventorySystemPresentationModel.OpenReplenishmentPage(((DataGridView)sender).Rows[e.RowIndex].Index);
            }
        }

        // 讀取DaraGridView資料 並顯示
        private void LoadAndShowDataGridView()
        {
            foreach (String[] item in _inventorySystemPresentationModel.GetAllItemDetail()) // 把所有商品資訊放入DataGridView
                _itemDataGridView.Rows.Add(item);
        }

        // 更新庫存數量
        public void UpdateProductData()
        {
            int rowIndex = _productManagement.GetEditProductIndexOfAllProducts();
            try
            {
                _itemDataGridView.Rows[rowIndex].Cells[NAME_COLUMN_INDEX].Value = _inventorySystemPresentationModel.GetName();
                _itemDataGridView.Rows[rowIndex].Cells[TYPE_COLUMN_INDEX].Value = _inventorySystemPresentationModel.GetCategory();
                _itemDataGridView.Rows[rowIndex].Cells[PRICE_COLUMN_INDEX].Value = _inventorySystemPresentationModel.GetPrice();
                _itemDataGridView.Rows[rowIndex].Cells[STOCK_COLUMN_INDEX].Value = _inventorySystemPresentationModel.GetStock();
                _itemPictureBox.Image = _inventorySystemPresentationModel.GetImageFilePath(_itemDataGridView.CurrentCell.RowIndex);
                _itemDetailTextBox.Text = _inventorySystemPresentationModel.GetItemDetail(_itemDataGridView.CurrentCell.RowIndex);
            }
            catch
            {
                _itemDataGridView.Rows.Add(_inventorySystemPresentationModel.GetLastestItemDetail());
            }
        }

        // 解除event
        private void CancelEvent(object sender, FormClosedEventArgs e)
        {
            _productManagement._writeNewData -= UpdateProductData;
            this.Dispose();
        }
    }
}
