using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class ViewCustomersForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public ViewCustomersForm()
        {
            InitializeComponent();
        }

        private void ViewCustomersForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    UserID, 
                                    FullName, 
                                    Email, 
                                    Phone, 
                                    Address, 
                                    Status, 
                                    CreatedAt
                                FROM Users
                                WHERE Role = 'Customer'
                                ORDER BY UserID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                dgvCustomers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    UserID, 
                                    FullName, 
                                    Email, 
                                    Phone, 
                                    Address, 
                                    Status, 
                                    CreatedAt
                                FROM Users
                                WHERE Role = 'Customer'
                                AND
                                (
                                    FullName LIKE @Search
                                    OR Email LIKE @Search
                                    OR Phone LIKE @Search
                                    OR Address LIKE @Search
                                    OR Status LIKE @Search
                                )
                                ORDER BY UserID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvCustomers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching customers: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtUserID.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtStatus.Clear();
            txtCreatedAt.Clear();
            txtSearch.Clear();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                txtUserID.Text = row.Cells["UserID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();

                if (row.Cells["Phone"].Value == DBNull.Value)
                {
                    txtPhone.Text = "";
                }
                else
                {
                    txtPhone.Text = row.Cells["Phone"].Value.ToString();
                }

                if (row.Cells["Address"].Value == DBNull.Value)
                {
                    txtAddress.Text = "";
                }
                else
                {
                    txtAddress.Text = row.Cells["Address"].Value.ToString();
                }

                txtStatus.Text = row.Cells["Status"].Value.ToString();
                txtCreatedAt.Text = row.Cells["CreatedAt"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // This part is commented because ManagerDashboard may not be ready yet.
            // When ManagerDashboard is ready, remove the comments and use this code.

            
            ManagerDashboard managerDashboard = new ManagerDashboard();
            managerDashboard.Show();
            this.Hide();
            

           
        }
    }
}