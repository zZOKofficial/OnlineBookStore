namespace OnlineBookStore
{
    partial class OrderPlacedForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;

        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblOrderIDValue;

        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountValue;

        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethodValue;

        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.Label lblOrderStatusValue;

        private System.Windows.Forms.Button btnOrderHistory;
        private System.Windows.Forms.Button btnContinueShopping;
        private System.Windows.Forms.Button btnDashboard;

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
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblOrderIDValue = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountValue = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblPaymentMethodValue = new System.Windows.Forms.Label();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.lblOrderStatusValue = new System.Windows.Forms.Label();
            this.btnOrderHistory = new System.Windows.Forms.Button();
            this.btnContinueShopping = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(210, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(503, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Order Placed Successfully";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMessage.Location = new System.Drawing.Point(180, 90);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(590, 30);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Thank you. Your order has been placed and is now pending.";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOrderID.Location = new System.Drawing.Point(190, 155);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(98, 30);
            this.lblOrderID.TabIndex = 2;
            this.lblOrderID.Text = "Order ID";
            // 
            // lblOrderIDValue
            // 
            this.lblOrderIDValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderIDValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrderIDValue.Location = new System.Drawing.Point(360, 150);
            this.lblOrderIDValue.Name = "lblOrderIDValue";
            this.lblOrderIDValue.Size = new System.Drawing.Size(190, 30);
            this.lblOrderIDValue.TabIndex = 3;
            this.lblOrderIDValue.Text = "0";
            this.lblOrderIDValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalAmount.Location = new System.Drawing.Point(190, 205);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(142, 30);
            this.lblTotalAmount.TabIndex = 4;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // lblTotalAmountValue
            // 
            this.lblTotalAmountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmountValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmountValue.Location = new System.Drawing.Point(360, 200);
            this.lblTotalAmountValue.Name = "lblTotalAmountValue";
            this.lblTotalAmountValue.Size = new System.Drawing.Size(190, 30);
            this.lblTotalAmountValue.TabIndex = 5;
            this.lblTotalAmountValue.Text = "0.00";
            this.lblTotalAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(190, 255);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(179, 30);
            this.lblPaymentMethod.TabIndex = 6;
            this.lblPaymentMethod.Text = "Payment Method";
            // 
            // lblPaymentMethodValue
            // 
            this.lblPaymentMethodValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPaymentMethodValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPaymentMethodValue.Location = new System.Drawing.Point(360, 250);
            this.lblPaymentMethodValue.Name = "lblPaymentMethodValue";
            this.lblPaymentMethodValue.Size = new System.Drawing.Size(190, 30);
            this.lblPaymentMethodValue.TabIndex = 7;
            this.lblPaymentMethodValue.Text = "Cash on Delivery";
            this.lblPaymentMethodValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblOrderStatus.Location = new System.Drawing.Point(190, 305);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(134, 30);
            this.lblOrderStatus.TabIndex = 8;
            this.lblOrderStatus.Text = "Order Status";
            // 
            // lblOrderStatusValue
            // 
            this.lblOrderStatusValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderStatusValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrderStatusValue.Location = new System.Drawing.Point(360, 300);
            this.lblOrderStatusValue.Name = "lblOrderStatusValue";
            this.lblOrderStatusValue.Size = new System.Drawing.Size(190, 30);
            this.lblOrderStatusValue.TabIndex = 9;
            this.lblOrderStatusValue.Text = "Pending";
            this.lblOrderStatusValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOrderHistory
            // 
            this.btnOrderHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnOrderHistory.Location = new System.Drawing.Point(130, 390);
            this.btnOrderHistory.Name = "btnOrderHistory";
            this.btnOrderHistory.Size = new System.Drawing.Size(160, 45);
            this.btnOrderHistory.TabIndex = 10;
            this.btnOrderHistory.Text = "View Order History";
            this.btnOrderHistory.UseVisualStyleBackColor = true;
            this.btnOrderHistory.Click += new System.EventHandler(this.btnOrderHistory_Click);
            // 
            // btnContinueShopping
            // 
            this.btnContinueShopping.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnContinueShopping.Location = new System.Drawing.Point(320, 390);
            this.btnContinueShopping.Name = "btnContinueShopping";
            this.btnContinueShopping.Size = new System.Drawing.Size(160, 45);
            this.btnContinueShopping.TabIndex = 11;
            this.btnContinueShopping.Text = "Continue Shopping";
            this.btnContinueShopping.UseVisualStyleBackColor = true;
            this.btnContinueShopping.Click += new System.EventHandler(this.btnContinueShopping_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDashboard.Location = new System.Drawing.Point(510, 390);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(160, 45);
            this.btnDashboard.TabIndex = 12;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // OrderPlacedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.lblOrderIDValue);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalAmountValue);
            this.Controls.Add(this.lblPaymentMethod);
            this.Controls.Add(this.lblPaymentMethodValue);
            this.Controls.Add(this.lblOrderStatus);
            this.Controls.Add(this.lblOrderStatusValue);
            this.Controls.Add(this.btnOrderHistory);
            this.Controls.Add(this.btnContinueShopping);
            this.Controls.Add(this.btnDashboard);
            this.Name = "OrderPlacedForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Placed";
            this.Load += new System.EventHandler(this.OrderPlacedForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}