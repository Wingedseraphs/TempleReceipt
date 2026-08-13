using System;
using System.Windows.Forms;
using TempleReceipt.Models;
using TempleReceipt.Services;

namespace TempleReceipt.Forms
{
    public partial class MainForm : Form
    {
        private Receipt _receipt;
        private ReceiptPerson _boundPerson;
        private bool _isBindingPerson;

        private readonly ChineseMoneyService _moneyService =
            new ChineseMoneyService();

        private readonly DonationItemService _donationService =
            new DonationItemService();

        private readonly PrinterService _printerService =
            new PrinterService();

        private readonly DaoCalendarService _daoCalendarService =
            new DaoCalendarService();

        public MainForm()
        {
            InitializeComponent();
            InitializeReceipt();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            LoadDonationItems();
            RefreshPersonList();
            BindPerson(_receipt.Persons[0]);
            dtpReceiptDate.Value = _receipt.CreateTime;
            lblDaoDate.Text = _daoCalendarService.GetDaoCalendar(_receipt.CreateTime);
            RefreshSummary();
            RefreshPreview();
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
            _receipt.Persons.Add(new ReceiptPerson());
        }

        private void LoadDonationItems()
        {
            cboDonationItem.DataSource = _donationService.GetDefaultItems();
            cboDonationItem.DisplayMember = "Name";
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (!_isBindingPerson)
                RefreshAll();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            SaveBoundPerson();

            ReceiptPerson person = new ReceiptPerson();
            _receipt.Persons.Add(person);
            RefreshPersonList();
            BindPerson(person);
            txtName.Focus();
        }

        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            if (_receipt.Persons.Count == 1)
            {
                MessageBox.Show("收據至少需要保留一位捐款人。", "無法刪除",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int index = _receipt.Persons.IndexOf(_boundPerson);
            _receipt.Persons.Remove(_boundPerson);
            RefreshPersonList();
            BindPerson(_receipt.Persons[Math.Min(index, _receipt.Persons.Count - 1)]);
        }

        private void lstPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isBindingPerson)
                return;

            ReceiptPerson selectedPerson = lstPersons.SelectedItem as ReceiptPerson;
            if (selectedPerson != null && selectedPerson != _boundPerson)
            {
                SaveBoundPerson();
                BindPerson(selectedPerson);
            }
        }

        private void BindPerson(ReceiptPerson person)
        {
            _isBindingPerson = true;

            _boundPerson = person;
            txtName.Text = person.Name ?? string.Empty;
            dgvItems.Rows.Clear();

            foreach (ReceiptItem item in person.Items)
                dgvItems.Rows.Add(item.ItemName, item.Amount);

            lstPersons.SelectedItem = person;
            _isBindingPerson = false;
            //RefreshSummary();
        }

        private void SaveBoundPerson()
        {
            if (_boundPerson == null)
                return;

            dgvItems.EndEdit();
            _boundPerson.Name = txtName.Text.Trim();
            _boundPerson.Items.Clear();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string itemName = Convert.ToString(row.Cells["colItem"].Value)?.Trim();
                if (string.IsNullOrWhiteSpace(itemName))
                    continue;

                decimal amount;
                decimal.TryParse(Convert.ToString(row.Cells["colAmount"].Value), out amount);

                _boundPerson.Items.Add(new ReceiptItem
                {
                    ItemName = itemName,
                    Amount = amount
                });
            }
        }

        private void UpdateReceiptHeader()
        {
            _receipt.ReceiptNo = txtReceiptNo.Text.Trim();
            _receipt.Operator = txtOperator.Text.Trim();
            _receipt.Address = txtAddress.Text.Trim();
            _receipt.CreateTime = dtpReceiptDate.Value.Date;
            lblDaoDate.Text = _daoCalendarService.GetDaoCalendar(_receipt.CreateTime);
        }

        private void dtpReceiptDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_isBindingPerson)
                RefreshAll();
        }

        private void RefreshPersonList()
        {
            ReceiptPerson selectedPerson = _boundPerson;

            _isBindingPerson = true;
            lstPersons.BeginUpdate();
            lstPersons.Items.Clear();

            foreach (ReceiptPerson person in _receipt.Persons)
                lstPersons.Items.Add(person);

            if (selectedPerson != null)
                lstPersons.SelectedItem = selectedPerson;

            lstPersons.EndUpdate();
            _isBindingPerson = false;
        }

        private void RefreshSummary()
        {
            lblTotal.Text = $"{_receipt.TotalAmount:N0} 元";
            lblChineseMoney.Text = _moneyService.Convert(_receipt.TotalAmount);

            decimal personTotal = _boundPerson?.TotalAmount ?? 0;
            lblPersonTotal.Text = $"{personTotal:N0} 元";
            lblPersonChineseMoney.Text = _moneyService.Convert(personTotal);
        }

        private void RefreshAll()
        {
            SaveBoundPerson();
            UpdateReceiptHeader();
            RefreshPersonList();
            RefreshSummary();
            RefreshPreview();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cboDonationItem.SelectedItem is DonationItem item)
            {
                dgvItems.Rows.Add(item.Name, item.DefaultAmount);
                RefreshAll();
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvItems.Columns[e.ColumnIndex].Name == "colDelete")
            {
                dgvItems.Rows.RemoveAt(e.RowIndex);
                RefreshAll();
            }
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RefreshAll();
        }

        private void dgvItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RefreshAll();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            RefreshAll();
            receiptPreview.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RefreshAll();

            try
            {
                _printerService.Print(this, _receipt);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"列印失敗：{exception.Message}", "列印錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要清空目前收據嗎？",
                "清空收據", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            _boundPerson = null;
            InitializeReceipt();
            RefreshPersonList();
            BindPerson(_receipt.Persons[0]);
            dtpReceiptDate.Value = _receipt.CreateTime;
            lblDaoDate.Text = _daoCalendarService.GetDaoCalendar(_receipt.CreateTime);
            RefreshPreview();
        }

        private void RefreshPreview()
        {
            receiptPreview.Receipt = _receipt;
        }
    }
}
