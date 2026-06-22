namespace OnlineBookStore { 
    partial class CustomerDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;

        private System.Windows.Forms.Button btnBrowseBooks;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnOrderHistory;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;

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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnBrowseBooks = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.btnOrderHistory = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(128, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(422, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Customer Dashboard";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWelcome.Location = new System.Drawing.Point(289, 100);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(113, 32);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // btnBrowseBooks
            // 
            this.btnBrowseBooks.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBrowseBooks.Location = new System.Drawing.Point(230, 145);
            this.btnBrowseBooks.Name = "btnBrowseBooks";
            this.btnBrowseBooks.Size = new System.Drawing.Size(220, 45);
            this.btnBrowseBooks.TabIndex = 2;
            this.btnBrowseBooks.Text = "Browse Books";
            this.btnBrowseBooks.UseVisualStyleBackColor = true;
            this.btnBrowseBooks.Click += new System.EventHandler(this.btnBrowseBooks_Click);
            // 
            // btnCart
            // 
            this.btnCart.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCart.Location = new System.Drawing.Point(230, 210);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(220, 45);
            this.btnCart.TabIndex = 3;
            this.btnCart.Text = "View Cart";
            this.btnCart.UseVisualStyleBackColor = true;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // btnOrderHistory
            // 
            this.btnOrderHistory.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOrderHistory.Location = new System.Drawing.Point(230, 275);
            this.btnOrderHistory.Name = "btnOrderHistory";
            this.btnOrderHistory.Size = new System.Drawing.Size(220, 45);
            this.btnOrderHistory.TabIndex = 4;
            this.btnOrderHistory.Text = "Order History";
            this.btnOrderHistory.UseVisualStyleBackColor = true;
            this.btnOrderHistory.Click += new System.EventHandler(this.btnOrderHistory_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnProfile.Location = new System.Drawing.Point(230, 340);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(220, 45);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLogout.Location = new System.Drawing.Point(230, 405);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 45);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(680, 520);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnBrowseBooks);
            this.Controls.Add(this.btnCart);
            this.Controls.Add(this.btnOrderHistory);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnLogout);
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Dashboard";
            this.Load += new System.EventHandler(this.CustomerDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}