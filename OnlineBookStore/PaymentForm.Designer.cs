namespace OnlineBookStore
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblTransactionID;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountValue;
        private System.Windows.Forms.Label lblPaymentItems;

        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.TextBox txtTransactionID;

        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.DataGridView dgvPaymentItems;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblTransactionID = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountValue = new System.Windows.Forms.Label();
            this.lblPaymentItems = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvPaymentItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(335, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(265, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Payment Form";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(40, 95);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(162, 28);
            this.lblPaymentMethod.TabIndex = 1;
            this.lblPaymentMethod.Text = "Payment Method";
            // 
            // lblTransactionID
            // 
            this.lblTransactionID.AutoSize = true;
            this.lblTransactionID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTransactionID.Location = new System.Drawing.Point(40, 140);
            this.lblTransactionID.Name = "lblTransactionID";
            this.lblTransactionID.Size = new System.Drawing.Size(134, 28);
            this.lblTransactionID.TabIndex = 3;
            this.lblTransactionID.Text = "Transaction ID";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(500, 95);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(153, 30);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // lblTotalAmountValue
            // 
            this.lblTotalAmountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmountValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmountValue.Location = new System.Drawing.Point(630, 90);
            this.lblTotalAmountValue.Name = "lblTotalAmountValue";
            this.lblTotalAmountValue.Size = new System.Drawing.Size(180, 30);
            this.lblTotalAmountValue.TabIndex = 6;
            this.lblTotalAmountValue.Text = "0.00";
            this.lblTotalAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentItems
            // 
            this.lblPaymentItems.AutoSize = true;
            this.lblPaymentItems.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPaymentItems.Location = new System.Drawing.Point(40, 280);
            this.lblPaymentItems.Name = "lblPaymentItems";
            this.lblPaymentItems.Size = new System.Drawing.Size(235, 30);
            this.lblPaymentItems.TabIndex = 11;
            this.lblPaymentItems.Text = "Payment Item Details";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash on Delivery",
            "bKash",
            "Nagad",
            "Card"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(190, 95);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(250, 28);
            this.cmbPaymentMethod.TabIndex = 2;
            this.cmbPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentMethod_SelectedIndexChanged);
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.Location = new System.Drawing.Point(190, 140);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.Size = new System.Drawing.Size(250, 26);
            this.txtTransactionID.TabIndex = 4;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnConfirmPayment.Location = new System.Drawing.Point(500, 140);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(150, 40);
            this.btnConfirmPayment.TabIndex = 7;
            this.btnConfirmPayment.Text = "Confirm Payment";
            this.btnConfirmPayment.UseVisualStyleBackColor = true;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.Location = new System.Drawing.Point(670, 140);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClear.Location = new System.Drawing.Point(500, 200);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 38);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.Location = new System.Drawing.Point(620, 200);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 38);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvPaymentItems
            // 
            this.dgvPaymentItems.AllowUserToAddRows = false;
            this.dgvPaymentItems.AllowUserToDeleteRows = false;
            this.dgvPaymentItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentItems.Location = new System.Drawing.Point(40, 320);
            this.dgvPaymentItems.Name = "dgvPaymentItems";
            this.dgvPaymentItems.ReadOnly = true;
            this.dgvPaymentItems.RowHeadersWidth = 62;
            this.dgvPaymentItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentItems.Size = new System.Drawing.Size(810, 260);
            this.dgvPaymentItems.TabIndex = 12;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.lblTransactionID);
            this.Controls.Add(this.txtTransactionID);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalAmountValue);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblPaymentItems);
            this.Controls.Add(this.dgvPaymentItems);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}