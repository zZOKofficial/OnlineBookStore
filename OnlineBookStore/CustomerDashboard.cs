using System;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public partial class CustomerDashboard : Form
    {
        int customerId = 3;

        public CustomerDashboard()
        {
            InitializeComponent();
        }

        public CustomerDashboard(int loggedInCustomerId)
        {
            InitializeComponent();
            customerId = loggedInCustomerId;
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "WELCOME";
        }

        private void btnBrowseBooks_Click(object sender, EventArgs e)
        {
            BrowseBooksForm browseBooksForm = new BrowseBooksForm(customerId);
            browseBooksForm.Show();
            this.Hide();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm(customerId);
            cartForm.Show();
            this.Hide();
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            OrderHistoryForm orderHistoryForm = new OrderHistoryForm(customerId);
            orderHistoryForm.Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(customerId);
            profileForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}