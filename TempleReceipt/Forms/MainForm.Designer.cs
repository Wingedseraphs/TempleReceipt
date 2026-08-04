namespace TempleReceipt.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpReceipt = new System.Windows.Forms.GroupBox();
            this.lblDaoDate = new System.Windows.Forms.Label();
            this.lalTimeNow = new System.Windows.Forms.Label();
            this.lblOperatorTitle = new System.Windows.Forms.Label();
            this.lblReceiptNoTitle = new System.Windows.Forms.Label();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.grpDonor = new System.Windows.Forms.GroupBox();
            this.lblAddressTitle = new System.Windows.Forms.Label();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cboDonationItem = new System.Windows.Forms.ComboBox();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpAmount = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblChineseMoney = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpReceipt.SuspendLayout();
            this.grpDonor.SuspendLayout();
            this.grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.grpAmount.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReceipt
            // 
            this.grpReceipt.Controls.Add(this.lblDaoDate);
            this.grpReceipt.Controls.Add(this.lalTimeNow);
            this.grpReceipt.Controls.Add(this.lblOperatorTitle);
            this.grpReceipt.Controls.Add(this.lblReceiptNoTitle);
            this.grpReceipt.Controls.Add(this.txtOperator);
            this.grpReceipt.Controls.Add(this.txtReceiptNo);
            this.grpReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReceipt.Location = new System.Drawing.Point(5, 5);
            this.grpReceipt.Margin = new System.Windows.Forms.Padding(5);
            this.grpReceipt.Name = "grpReceipt";
            this.grpReceipt.Size = new System.Drawing.Size(391, 112);
            this.grpReceipt.TabIndex = 0;
            this.grpReceipt.TabStop = false;
            this.grpReceipt.Text = "收據資訊";
            // 
            // lblDaoDate
            // 
            this.lblDaoDate.AutoSize = true;
            this.lblDaoDate.Location = new System.Drawing.Point(212, 59);
            this.lblDaoDate.Name = "lblDaoDate";
            this.lblDaoDate.Size = new System.Drawing.Size(44, 22);
            this.lblDaoDate.TabIndex = 9;
            this.lblDaoDate.Text = "道曆";
            // 
            // lalTimeNow
            // 
            this.lalTimeNow.AutoSize = true;
            this.lalTimeNow.Location = new System.Drawing.Point(212, 26);
            this.lalTimeNow.Name = "lalTimeNow";
            this.lalTimeNow.Size = new System.Drawing.Size(44, 22);
            this.lalTimeNow.TabIndex = 8;
            this.lalTimeNow.Text = "時間";
            // 
            // lblOperatorTitle
            // 
            this.lblOperatorTitle.AutoSize = true;
            this.lblOperatorTitle.Location = new System.Drawing.Point(3, 59);
            this.lblOperatorTitle.Name = "lblOperatorTitle";
            this.lblOperatorTitle.Size = new System.Drawing.Size(61, 22);
            this.lblOperatorTitle.TabIndex = 7;
            this.lblOperatorTitle.Text = "經手人";
            // 
            // lblReceiptNoTitle
            // 
            this.lblReceiptNoTitle.AutoSize = true;
            this.lblReceiptNoTitle.Location = new System.Drawing.Point(3, 28);
            this.lblReceiptNoTitle.Name = "lblReceiptNoTitle";
            this.lblReceiptNoTitle.Size = new System.Drawing.Size(78, 22);
            this.lblReceiptNoTitle.TabIndex = 6;
            this.lblReceiptNoTitle.Text = "收據編號";
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(87, 56);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(119, 30);
            this.txtOperator.TabIndex = 5;
            this.txtOperator.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(87, 20);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(119, 30);
            this.txtReceiptNo.TabIndex = 4;
            this.txtReceiptNo.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // grpDonor
            // 
            this.grpDonor.Controls.Add(this.lblAddressTitle);
            this.grpDonor.Controls.Add(this.lblNameTitle);
            this.grpDonor.Controls.Add(this.txtAddress);
            this.grpDonor.Controls.Add(this.txtName);
            this.grpDonor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDonor.Location = new System.Drawing.Point(3, 125);
            this.grpDonor.Name = "grpDonor";
            this.grpDonor.Padding = new System.Windows.Forms.Padding(5);
            this.grpDonor.Size = new System.Drawing.Size(395, 133);
            this.grpDonor.TabIndex = 1;
            this.grpDonor.TabStop = false;
            this.grpDonor.Text = "信徒資料";
            // 
            // lblAddressTitle
            // 
            this.lblAddressTitle.AutoSize = true;
            this.lblAddressTitle.Location = new System.Drawing.Point(9, 68);
            this.lblAddressTitle.Name = "lblAddressTitle";
            this.lblAddressTitle.Size = new System.Drawing.Size(44, 22);
            this.lblAddressTitle.TabIndex = 8;
            this.lblAddressTitle.Text = "地址";
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Location = new System.Drawing.Point(9, 28);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(44, 22);
            this.lblNameTitle.TabIndex = 7;
            this.lblNameTitle.Text = "姓名";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(59, 65);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(294, 60);
            this.txtAddress.TabIndex = 6;
            this.txtAddress.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(59, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(119, 30);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.btnAddItem);
            this.grpItems.Controls.Add(this.cboDonationItem);
            this.grpItems.Controls.Add(this.dgvItems);
            this.grpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItems.Location = new System.Drawing.Point(3, 264);
            this.grpItems.Name = "grpItems";
            this.grpItems.Padding = new System.Windows.Forms.Padding(5);
            this.grpItems.Size = new System.Drawing.Size(395, 387);
            this.grpItems.TabIndex = 2;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "功德項目";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(269, 31);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(84, 30);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "新增";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // cboDonationItem
            // 
            this.cboDonationItem.FormattingEnabled = true;
            this.cboDonationItem.Items.AddRange(new object[] {
            "香油錢",
            "祭改補運",
            "普渡法會",
            "捐米(1斤60元)"});
            this.cboDonationItem.Location = new System.Drawing.Point(59, 31);
            this.cboDonationItem.Name = "cboDonationItem";
            this.cboDonationItem.Size = new System.Drawing.Size(191, 30);
            this.cboDonationItem.TabIndex = 1;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItem,
            this.colAmount,
            this.colDelete});
            this.dgvItems.Location = new System.Drawing.Point(-3, 80);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.RowTemplate.Height = 27;
            this.dgvItems.Size = new System.Drawing.Size(390, 281);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);
            this.dgvItems.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvItems_UserDeletedRow);
            // 
            // colItem
            // 
            this.colItem.HeaderText = "功德項目";
            this.colItem.MinimumWidth = 6;
            this.colItem.Name = "colItem";
            this.colItem.Width = 125;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "金額";
            this.colAmount.MinimumWidth = 6;
            this.colAmount.Name = "colAmount";
            this.colAmount.Width = 125;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "刪除";
            this.colDelete.MinimumWidth = 6;
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "刪除";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 125;
            // 
            // grpAmount
            // 
            this.grpAmount.Controls.Add(this.lblTotal);
            this.grpAmount.Controls.Add(this.lblChineseMoney);
            this.grpAmount.Controls.Add(this.lblTotalTitle);
            this.grpAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAmount.Location = new System.Drawing.Point(5, 659);
            this.grpAmount.Margin = new System.Windows.Forms.Padding(5);
            this.grpAmount.Name = "grpAmount";
            this.grpAmount.Size = new System.Drawing.Size(391, 77);
            this.grpAmount.TabIndex = 3;
            this.grpAmount.TabStop = false;
            this.grpAmount.Text = "金額資訊";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(87, 26);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 22);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "0元";
            // 
            // lblChineseMoney
            // 
            this.lblChineseMoney.AutoSize = true;
            this.lblChineseMoney.Location = new System.Drawing.Point(198, 26);
            this.lblChineseMoney.Name = "lblChineseMoney";
            this.lblChineseMoney.Size = new System.Drawing.Size(61, 22);
            this.lblChineseMoney.TabIndex = 1;
            this.lblChineseMoney.Text = "零元整";
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Location = new System.Drawing.Point(8, 26);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(73, 22);
            this.lblTotalTitle.TabIndex = 0;
            this.lblTotalTitle.Text = "總金額 : ";
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnPrint);
            this.grpAction.Controls.Add(this.btnPreview);
            this.grpAction.Controls.Add(this.btnClear);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAction.Location = new System.Drawing.Point(5, 746);
            this.grpAction.Margin = new System.Windows.Forms.Padding(5);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(391, 123);
            this.grpAction.TabIndex = 3;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "功能";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(246, 43);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 44);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "列印";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(132, 43);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(84, 44);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "預覽";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(28, 43);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 44);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // pnlPreview
            // 
            this.pnlPreview.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlPreview.Controls.Add(this.label1);
            this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(685, 874);
            this.pnlPreview.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "收據預覽";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlPreview);
            this.splitContainer1.Size = new System.Drawing.Size(1090, 874);
            this.splitContainer1.SplitterDistance = 401;
            this.splitContainer1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.grpItems, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpAction, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.grpReceipt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpDonor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpAmount, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 874);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1090, 874);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TempleReceipt 宮廟收據列印系統 V1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpReceipt.ResumeLayout(false);
            this.grpReceipt.PerformLayout();
            this.grpDonor.ResumeLayout(false);
            this.grpDonor.PerformLayout();
            this.grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.grpAmount.ResumeLayout(false);
            this.grpAmount.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpReceipt;
        private System.Windows.Forms.GroupBox grpDonor;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.GroupBox grpAmount;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblChineseMoney;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblOperatorTitle;
        private System.Windows.Forms.Label lblReceiptNoTitle;
        private System.Windows.Forms.Label lblDaoDate;
        private System.Windows.Forms.Label lalTimeNow;
        private System.Windows.Forms.Label lblAddressTitle;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cboDonationItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}

