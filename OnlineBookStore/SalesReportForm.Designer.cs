namespace OnlineBookStore
{
    partial class SalesReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblTotalSalesValue;

        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalOrdersValue;

        private System.Windows.Forms.Label lblPendingOrders;
        private System.Windows.Forms.Label lblPendingOrdersValue;

        private System.Windows.Forms.Label lblConfirmedOrders;
        private System.Windows.Forms.Label lblConfirmedOrdersValue;

        private System.Windows.Forms.Label lblDeliveredOrders;
        private System.Windows.Forms.Label lblDeliveredOrdersValue;

        private System.Windows.Forms.Label lblCancelledOrders;
        private System.Windows.Forms.Label lblCancelledOrdersValue;

        private System.Windows.Forms.Label lblSoldBooks;
        private System.Windows.Forms.Label lblSoldBooksValue;

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblReportList;

        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;

        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.DataGridView dgvSalesReport;

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
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblTotalSalesValue = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblTotalOrdersValue = new System.Windows.Forms.Label();
            this.lblPendingOrders = new System.Windows.Forms.Label();
            this.lblPendingOrdersValue = new System.Windows.Forms.Label();
            this.lblConfirmedOrders = new System.Windows.Forms.Label();
            this.lblConfirmedOrdersValue = new System.Windows.Forms.Label();
            this.lblDeliveredOrders = new System.Windows.Forms.Label();
            this.lblDeliveredOrdersValue = new System.Windows.Forms.Label();
            this.lblCancelledOrders = new System.Windows.Forms.Label();
            this.lblCancelledOrdersValue = new System.Windows.Forms.Label();
            this.lblSoldBooks = new System.Windows.Forms.Label();
            this.lblSoldBooksValue = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblReportList = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvSalesReport = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(350, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(327, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sales Report Form";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalSales.Location = new System.Drawing.Point(30, 90);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(179, 28);
            this.lblTotalSales.TabIndex = 1;
            this.lblTotalSales.Text = "Total Sales Amount";
            // 
            // lblTotalSalesValue
            // 
            this.lblTotalSalesValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSalesValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalSalesValue.Location = new System.Drawing.Point(180, 85);
            this.lblTotalSalesValue.Name = "lblTotalSalesValue";
            this.lblTotalSalesValue.Size = new System.Drawing.Size(160, 30);
            this.lblTotalSalesValue.TabIndex = 2;
            this.lblTotalSalesValue.Text = "0.00";
            this.lblTotalSalesValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalOrders.Location = new System.Drawing.Point(30, 135);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(118, 28);
            this.lblTotalOrders.TabIndex = 3;
            this.lblTotalOrders.Text = "Total Orders";
            // 
            // lblTotalOrdersValue
            // 
            this.lblTotalOrdersValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalOrdersValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrdersValue.Location = new System.Drawing.Point(180, 130);
            this.lblTotalOrdersValue.Name = "lblTotalOrdersValue";
            this.lblTotalOrdersValue.Size = new System.Drawing.Size(160, 30);
            this.lblTotalOrdersValue.TabIndex = 4;
            this.lblTotalOrdersValue.Text = "0";
            this.lblTotalOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPendingOrders
            // 
            this.lblPendingOrders.AutoSize = true;
            this.lblPendingOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPendingOrders.Location = new System.Drawing.Point(30, 180);
            this.lblPendingOrders.Name = "lblPendingOrders";
            this.lblPendingOrders.Size = new System.Drawing.Size(147, 28);
            this.lblPendingOrders.TabIndex = 5;
            this.lblPendingOrders.Text = "Pending Orders";
            // 
            // lblPendingOrdersValue
            // 
            this.lblPendingOrdersValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPendingOrdersValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPendingOrdersValue.Location = new System.Drawing.Point(180, 175);
            this.lblPendingOrdersValue.Name = "lblPendingOrdersValue";
            this.lblPendingOrdersValue.Size = new System.Drawing.Size(160, 30);
            this.lblPendingOrdersValue.TabIndex = 6;
            this.lblPendingOrdersValue.Text = "0";
            this.lblPendingOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConfirmedOrders
            // 
            this.lblConfirmedOrders.AutoSize = true;
            this.lblConfirmedOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConfirmedOrders.Location = new System.Drawing.Point(380, 90);
            this.lblConfirmedOrders.Name = "lblConfirmedOrders";
            this.lblConfirmedOrders.Size = new System.Drawing.Size(168, 28);
            this.lblConfirmedOrders.TabIndex = 7;
            this.lblConfirmedOrders.Text = "Confirmed Orders";
            // 
            // lblConfirmedOrdersValue
            // 
            this.lblConfirmedOrdersValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConfirmedOrdersValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfirmedOrdersValue.Location = new System.Drawing.Point(530, 85);
            this.lblConfirmedOrdersValue.Name = "lblConfirmedOrdersValue";
            this.lblConfirmedOrdersValue.Size = new System.Drawing.Size(160, 30);
            this.lblConfirmedOrdersValue.TabIndex = 8;
            this.lblConfirmedOrdersValue.Text = "0";
            this.lblConfirmedOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeliveredOrders
            // 
            this.lblDeliveredOrders.AutoSize = true;
            this.lblDeliveredOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDeliveredOrders.Location = new System.Drawing.Point(380, 135);
            this.lblDeliveredOrders.Name = "lblDeliveredOrders";
            this.lblDeliveredOrders.Size = new System.Drawing.Size(159, 28);
            this.lblDeliveredOrders.TabIndex = 9;
            this.lblDeliveredOrders.Text = "Delivered Orders";
            // 
            // lblDeliveredOrdersValue
            // 
            this.lblDeliveredOrdersValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDeliveredOrdersValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDeliveredOrdersValue.Location = new System.Drawing.Point(530, 130);
            this.lblDeliveredOrdersValue.Name = "lblDeliveredOrdersValue";
            this.lblDeliveredOrdersValue.Size = new System.Drawing.Size(160, 30);
            this.lblDeliveredOrdersValue.TabIndex = 10;
            this.lblDeliveredOrdersValue.Text = "0";
            this.lblDeliveredOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCancelledOrders
            // 
            this.lblCancelledOrders.AutoSize = true;
            this.lblCancelledOrders.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCancelledOrders.Location = new System.Drawing.Point(380, 180);
            this.lblCancelledOrders.Name = "lblCancelledOrders";
            this.lblCancelledOrders.Size = new System.Drawing.Size(160, 28);
            this.lblCancelledOrders.TabIndex = 11;
            this.lblCancelledOrders.Text = "Cancelled Orders";
            // 
            // lblCancelledOrdersValue
            // 
            this.lblCancelledOrdersValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCancelledOrdersValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCancelledOrdersValue.Location = new System.Drawing.Point(530, 175);
            this.lblCancelledOrdersValue.Name = "lblCancelledOrdersValue";
            this.lblCancelledOrdersValue.Size = new System.Drawing.Size(160, 30);
            this.lblCancelledOrdersValue.TabIndex = 12;
            this.lblCancelledOrdersValue.Text = "0";
            this.lblCancelledOrdersValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSoldBooks
            // 
            this.lblSoldBooks.AutoSize = true;
            this.lblSoldBooks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoldBooks.Location = new System.Drawing.Point(720, 90);
            this.lblSoldBooks.Name = "lblSoldBooks";
            this.lblSoldBooks.Size = new System.Drawing.Size(110, 28);
            this.lblSoldBooks.TabIndex = 13;
            this.lblSoldBooks.Text = "Sold Books";
            // 
            // lblSoldBooksValue
            // 
            this.lblSoldBooksValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoldBooksValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoldBooksValue.Location = new System.Drawing.Point(830, 85);
            this.lblSoldBooksValue.Name = "lblSoldBooksValue";
            this.lblSoldBooksValue.Size = new System.Drawing.Size(130, 30);
            this.lblSoldBooksValue.TabIndex = 14;
            this.lblSoldBooksValue.Text = "0";
            this.lblSoldBooksValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStartDate.Location = new System.Drawing.Point(30, 255);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(99, 28);
            this.lblStartDate.TabIndex = 15;
            this.lblStartDate.Text = "Start Date";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEndDate.Location = new System.Drawing.Point(300, 255);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(91, 28);
            this.lblEndDate.TabIndex = 17;
            this.lblEndDate.Text = "End Date";
            // 
            // lblReportList
            // 
            this.lblReportList.AutoSize = true;
            this.lblReportList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblReportList.Location = new System.Drawing.Point(30, 315);
            this.lblReportList.Name = "lblReportList";
            this.lblReportList.Size = new System.Drawing.Size(184, 30);
            this.lblReportList.TabIndex = 23;
            this.lblReportList.Text = "Sales Report List";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(120, 255);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 26);
            this.dtpStartDate.TabIndex = 16;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(380, 255);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 26);
            this.dtpEndDate.TabIndex = 18;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilter.Location = new System.Drawing.Point(560, 245);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 35);
            this.btnFilter.TabIndex = 19;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(680, 245);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.Location = new System.Drawing.Point(800, 245);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.Location = new System.Drawing.Point(920, 245);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 35);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvSalesReport
            // 
            this.dgvSalesReport.AllowUserToAddRows = false;
            this.dgvSalesReport.AllowUserToDeleteRows = false;
            this.dgvSalesReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesReport.Location = new System.Drawing.Point(30, 350);
            this.dgvSalesReport.Name = "dgvSalesReport";
            this.dgvSalesReport.ReadOnly = true;
            this.dgvSalesReport.RowHeadersWidth = 62;
            this.dgvSalesReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesReport.Size = new System.Drawing.Size(970, 350);
            this.dgvSalesReport.TabIndex = 24;
            // 
            // SalesReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1030, 730);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.lblTotalSalesValue);
            this.Controls.Add(this.lblTotalOrders);
            this.Controls.Add(this.lblTotalOrdersValue);
            this.Controls.Add(this.lblPendingOrders);
            this.Controls.Add(this.lblPendingOrdersValue);
            this.Controls.Add(this.lblConfirmedOrders);
            this.Controls.Add(this.lblConfirmedOrdersValue);
            this.Controls.Add(this.lblDeliveredOrders);
            this.Controls.Add(this.lblDeliveredOrdersValue);
            this.Controls.Add(this.lblCancelledOrders);
            this.Controls.Add(this.lblCancelledOrdersValue);
            this.Controls.Add(this.lblSoldBooks);
            this.Controls.Add(this.lblSoldBooksValue);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblReportList);
            this.Controls.Add(this.dgvSalesReport);
            this.Name = "SalesReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.SalesReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}