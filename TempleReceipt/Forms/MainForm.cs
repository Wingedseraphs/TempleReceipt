using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TempleReceipt.Models;
using TempleReceipt.Services;

namespace TempleReceipt.Forms
{
    public partial class MainForm : Form
    {        
        /// <summary>
        /// 目前正在編輯的收據
        /// </summary>
        private Receipt _receipt;
        private ReceiptService _receiptService = new ReceiptService();
        public MainForm()
        {
            InitializeComponent();

            InitializeReceipt();
        }
        private void InitializeReceipt()
        {
            _receipt = new Receipt();
        }
        private void RefreshUI()
        {
            ReceiptSummary summary =
                _receiptService.GetSummary(_receipt);

            lbl.Text =
                $"{summary.TotalAmount:N0} 元";

            lblChineseMoney.Text =
                summary.ChineseMoney;

            lblDaoDate.Text =
                summary.DaoCalendar;
        }
        private void UpdateReceipt()
        {
            _receipt.ReceiptNo = txtReceiptNo.Text.Trim();
            _receipt.Operator = txtOperator.Text.Trim();
            _receipt.Name = txtName.Text.Trim();
            _receipt.Address = txtAddress.Text.Trim();

            RefreshReceiptItems();
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            UpdateReceipt();
            Text = _receipt.Name;
        }
        private void dgvItems_Update(object sender, EventArgs e)
        {
            UpdateReceipt();

            RefreshSummary();
        }
        private void RefreshReceipt()
        {
            UpdateReceipt();
            RefreshSummary();
        }
        private void RefreshSummary()
        {
            lbl.Text = $"{_receipt.TotalAmount:N0} 元";
        }
        
        private void RefreshReceiptItems()
        {
            _receipt.Items.Clear();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                // 最後一列新增列，不處理
                if (row.IsNewRow)
                    continue;

                string itemName = Convert.ToString(row.Cells["colItem"].Value)?.Trim();

                if (string.IsNullOrWhiteSpace(itemName))
                    continue;

                decimal amount = 0;

                decimal.TryParse(
                    Convert.ToString(row.Cells["colAmount"].Value),
                    out amount);

                _receipt.Items.Add(new ReceiptItem
                {
                    ItemName = itemName,
                    Amount = amount
                });
            }
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RefreshReceipt();
        }

        private void dgvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RefreshReceipt();
        }

        private void dgvItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RefreshReceipt();
        }
    }
}
