namespace OnlineBookStore
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblCartItemID;
        private System.Windows.Forms.Label lblBookID;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblAvailableStock;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountValue;
        private System.Windows.Forms.Label lblCartList;

        private System.Windows.Forms.TextBox txtCartItemID;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtAvailableStock;
        private System.Windows.Forms.TextBox txtSubTotal;

        private System.Windows.Forms.Button btnUpdateQuantity;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;

        private System.Windows.Forms.DataGridView dgvCartItems;

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
            this.lblCartItemID = new System.Windows.Forms.Label();
            this.lblBookID = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblAvailableStock = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountValue = new System.Windows.Forms.Label();
            this.lblCartList = new System.Windows.Forms.Label();
            this.txtCartItemID = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtAvailableStock = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.btnUpdateQuantity = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvCartItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(380, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(188, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cart Form";
            // 
            // lblCartItemID
            // 
            this.lblCartItemID.AutoSize = true;
            this.lblCartItemID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCartItemID.Location = new System.Drawing.Point(30, 85);
            this.lblCartItemID.Name = "lblCartItemID";
            this.lblCartItemID.Size = new System.Drawing.Size(116, 28);
            this.lblCartItemID.TabIndex = 1;
            this.lblCartItemID.Text = "Cart Item ID";
            // 
            // lblBookID
            // 
            this.lblBookID.AutoSize = true;
            this.lblBookID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookID.Location = new System.Drawing.Point(30, 125);
            this.lblBookID.Name = "lblBookID";
            this.lblBookID.Size = new System.Drawing.Size(81, 28);
            this.lblBookID.TabIndex = 3;
            this.lblBookID.Text = "Book ID";
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBookTitle.Location = new System.Drawing.Point(30, 165);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(49, 28);
            this.lblBookTitle.TabIndex = 5;
            this.lblBookTitle.Text = "Title";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAuthor.Location = new System.Drawing.Point(30, 205);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(73, 28);
            this.lblAuthor.TabIndex = 7;
            this.lblAuthor.Text = "Author";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(30, 245);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(54, 28);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "Price";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuantity.Location = new System.Drawing.Point(430, 85);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(88, 28);
            this.lblQuantity.TabIndex = 11;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblAvailableStock
            // 
            this.lblAvailableStock.AutoSize = true;
            this.lblAvailableStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAvailableStock.Location = new System.Drawing.Point(430, 125);
            this.lblAvailableStock.Name = "lblAvailableStock";
            this.lblAvailableStock.Size = new System.Drawing.Size(145, 28);
            this.lblAvailableStock.TabIndex = 13;
            this.lblAvailableStock.Text = "Available Stock";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTotal.Location = new System.Drawing.Point(430, 165);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(93, 28);
            this.lblSubTotal.TabIndex = 15;
            this.lblSubTotal.Text = "Sub Total";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Location = new System.Drawing.Point(430, 220);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(153, 30);
            this.lblTotalAmount.TabIndex = 17;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // lblTotalAmountValue
            // 
            this.lblTotalAmountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmountValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmountValue.Location = new System.Drawing.Point(560, 215);
            this.lblTotalAmountValue.Name = "lblTotalAmountValue";
            this.lblTotalAmountValue.Size = new System.Drawing.Size(220, 30);
            this.lblTotalAmountValue.TabIndex = 18;
            this.lblTotalAmountValue.Text = "0.00";
            this.lblTotalAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCartList
            // 
            this.lblCartList.AutoSize = true;
            this.lblCartList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCartList.Location = new System.Drawing.Point(30, 380);
            this.lblCartList.Name = "lblCartList";
            this.lblCartList.Size = new System.Drawing.Size(154, 30);
            this.lblCartList.TabIndex = 25;
            this.lblCartList.Text = "Cart Item List";
            // 
            // txtCartItemID
            // 
            this.txtCartItemID.Location = new System.Drawing.Point(150, 85);
            this.txtCartItemID.Name = "txtCartItemID";
            this.txtCartItemID.ReadOnly = true;
            this.txtCartItemID.Size = new System.Drawing.Size(220, 26);
            this.txtCartItemID.TabIndex = 2;
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(150, 125);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.ReadOnly = true;
            this.txtBookID.Size = new System.Drawing.Size(220, 26);
            this.txtBookID.TabIndex = 4;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(150, 165);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(220, 26);
            this.txtTitle.TabIndex = 6;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(150, 205);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(220, 26);
            this.txtAuthor.TabIndex = 8;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(150, 245);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(220, 26);
            this.txtPrice.TabIndex = 10;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(560, 85);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(220, 26);
            this.txtQuantity.TabIndex = 12;
            // 
            // txtAvailableStock
            // 
            this.txtAvailableStock.Location = new System.Drawing.Point(560, 125);
            this.txtAvailableStock.Name = "txtAvailableStock";
            this.txtAvailableStock.ReadOnly = true;
            this.txtAvailableStock.Size = new System.Drawing.Size(220, 26);
            this.txtAvailableStock.TabIndex = 14;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(560, 165);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(220, 26);
            this.txtSubTotal.TabIndex = 16;
            // 
            // btnUpdateQuantity
            // 
            this.btnUpdateQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdateQuantity.Location = new System.Drawing.Point(30, 305);
            this.btnUpdateQuantity.Name = "btnUpdateQuantity";
            this.btnUpdateQuantity.Size = new System.Drawing.Size(140, 38);
            this.btnUpdateQuantity.TabIndex = 19;
            this.btnUpdateQuantity.Text = "Update Quantity";
            this.btnUpdateQuantity.UseVisualStyleBackColor = true;
            this.btnUpdateQuantity.Click += new System.EventHandler(this.btnUpdateQuantity_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveItem.Location = new System.Drawing.Point(190, 305);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(130, 38);
            this.btnRemoveItem.TabIndex = 20;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPlaceOrder.Location = new System.Drawing.Point(340, 305);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(130, 38);
            this.btnPlaceOrder.TabIndex = 21;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(490, 305);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 38);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.Location = new System.Drawing.Point(620, 305);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 38);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Clear Fields";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.Location = new System.Drawing.Point(750, 305);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 38);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dgvCartItems
            // 
            this.dgvCartItems.AllowUserToAddRows = false;
            this.dgvCartItems.AllowUserToDeleteRows = false;
            this.dgvCartItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartItems.Location = new System.Drawing.Point(30, 410);
            this.dgvCartItems.Name = "dgvCartItems";
            this.dgvCartItems.ReadOnly = true;
            this.dgvCartItems.RowHeadersWidth = 62;
            this.dgvCartItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCartItems.Size = new System.Drawing.Size(850, 270);
            this.dgvCartItems.TabIndex = 26;
            this.dgvCartItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCartItems_CellClick);
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(920, 710);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCartItemID);
            this.Controls.Add(this.txtCartItemID);
            this.Controls.Add(this.lblBookID);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.lblBookTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblAvailableStock);
            this.Controls.Add(this.txtAvailableStock);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblTotalAmountValue);
            this.Controls.Add(this.btnUpdateQuantity);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblCartList);
            this.Controls.Add(this.dgvCartItems);
            this.Name = "CartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.CartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}