using System;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
           

            // Uncomment when ManageBooksForm is ready.
             ManageBooksForm manageBooksForm = new ManageBooksForm();
             manageBooksForm.Show();
             this.Hide();
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            

            // Uncomment when ManageOrdersForm is ready.
             ManageOrdersForm manageOrdersForm = new ManageOrdersForm();
             manageOrdersForm.Show();
             this.Hide();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
           

            // Uncomment when SalesReportForm is ready.
             SalesReportForm salesReportForm = new SalesReportForm();
             salesReportForm.Show();
             this.Hide();
        }

        private void btnViewCustomers_Click(object sender, EventArgs e)
        {
            

            // Uncomment when ViewCustomersForm is ready.
             ViewCustomersForm viewCustomersForm = new ViewCustomersForm();
             viewCustomersForm.Show();
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

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void ManagerDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
