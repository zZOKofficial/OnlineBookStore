using System;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnManageManagers_Click(object sender, EventArgs e)
        {
          

            // Uncomment when ManageManagersForm is ready.
             ManageManagersForm manageManagersForm = new ManageManagersForm();
             manageManagersForm.Show();
             this.Hide();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
           

            // Uncomment when ManageCustomersForm is ready.
             ManageCustomersForm manageCustomersForm = new ManageCustomersForm();
             manageCustomersForm.Show();
             this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            

            // Uncomment when LoginForm navigation is needed.
             LoginForm loginForm = new LoginForm();
             loginForm.Show();
             this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
