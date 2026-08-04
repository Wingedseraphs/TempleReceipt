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
        private readonly ChineseMoneyService _moneyService = new ChineseMoneyService();
        private readonly DonationItemService _donationService = new DonationItemService();
        public MainForm()
        {
            InitializeComponent();

            InitializeReceipt();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();

            LoadDonationItems();
        }
        private void InitializeDataGridView()
        {
            dgvItems.AllowUserToAddRows = true;
            dgvItems.AllowUserToDeleteRows = true;
            dgvItems.AllowUserToResizeRows = false;

            dgvItems.RowHeadersVisible = false;
            dgvItems.AutoGenerateColumns = false;

            dgvItems.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvItems.Columns["colItem"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvItems.Columns["colAmount"].Width = 120;

            dgvItems.Columns["colAmount"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;

            dgvItems.Columns["colAmount"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvItems.Columns["colAmount"].DefaultCellStyle.Format = "N0";
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
            RefreshAll();
        }
        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvItems.Columns[e.ColumnIndex].Name == "colDelete")
            {
                dgvItems.Rows.RemoveAt(e.RowIndex);

                RefreshAll();
            }
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cboDonationItem.SelectedIndex < 0)
                return;

            DonationItem item = (DonationItem)cboDonationItem.SelectedItem;

            dgvItems.Rows.Add(
                item.Name,
                item.DefaultAmount);
        }
        private void LoadDonationItems()
        {
            cboDonationItem.DataSource =
                _donationService.GetDefaultItems();

            cboDonationItem.DisplayMember = "Name";
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

            lblChineseMoney.Text =
                _moneyService.Convert(_receipt.TotalAmount);
        }

        private void RefreshAll()
        {
            dgvItems.EndEdit();
            UpdateReceipt();
            RefreshSummary();
            RefreshPreview();
        }
        private void RefreshPreview()
        {

        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RefreshAll();
        }

        private void dgvItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RefreshAll();
        }

        private void dgvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RefreshAll();
        }
        private void dgvItems_EditingControlShowing(object sender,DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvItems.CurrentCell.ColumnIndex == colAmount.Index)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress -= Amount_KeyPress;
                    tb.KeyPress += Amount_KeyPress;
                }
            }
        }
        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
