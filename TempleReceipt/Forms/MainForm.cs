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

namespace TempleReceipt.Forms
{
    public partial class MainForm : Form
    {        
        /// <summary>
        /// 目前正在編輯的收據
        /// </summary>
        private Receipt _receipt;

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
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            UpdateReceipt();
            Text = _receipt.Name;
        }

    }
}
