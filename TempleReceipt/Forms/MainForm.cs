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
        //private ReceiptService _receiptService = new ReceiptService();
        public MainForm()
        {
            InitializeComponent();

            InitializeReceipt();
        }
        private void InitializeReceipt()
        {
            _receipt = new Receipt();
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
            RefreshAll();
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
            RefreshPreview();
        }

        private void RefreshReceiptItems()
        {
            _receipt.Items.Clear();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string itemName = Convert.ToString(row.Cells["colItem"].Value)?.Trim();
                if (string.IsNullOrWhiteSpace(itemName))
                    continue;

                decimal amount = 0;
                decimal.TryParse(Convert.ToString(row.Cells["colAmount"].Value), out amount);

                _receipt.Items.Add(new ReceiptItem
                {
                    ItemName = itemName,
                    Amount = amount
                });
            }
        }
        private void RefreshSummary()
        {
            lblTotal.Text = $"{_receipt.TotalAmount:N0} 元";
        }

        private void RefreshAll()
        {
            dgvItems.EndEdit();
            UpdateReceipt();
            RefreshSummary();
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RefreshAll();
        }

        private void dgvItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RefreshAll();
        }

        private void RefreshPreview()
        {

        }

        private void dgvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RefreshReceipt();
        }

    }
}
