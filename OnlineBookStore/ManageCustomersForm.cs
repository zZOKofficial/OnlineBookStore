using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class ManageCustomersForm : Form
    {
        public ManageCustomersForm()
        {
            InitializeComponent();
        }

        private void ManageCustomersForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"SELECT UserID, FullName, Email, Phone, Address, Status
                                     FROM Users
                                     WHERE Role = 'Customer'";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvCustomers.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ChangeCustomerStatus("Active");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            ChangeCustomerStatus("Rejected");
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            ChangeCustomerStatus("Active");
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            ChangeCustomerStatus("Inactive");
        }

        private void ChangeCustomerStatus(string status)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"UPDATE Users
                                     SET Status = @Status,
                                         UpdatedAt = GETDATE()
                                     WHERE UserID = @UserID AND Role = 'Customer'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Customer status changed to " + status);

                    LoadCustomers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing customer status: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"SELECT UserID, FullName, Email, Phone, Address, Status
                                     FROM Users
                                     WHERE Role = 'Customer'
                                     AND (FullName LIKE @Search OR Email LIKE @Search OR Status LIKE @Search)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvCustomers.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching customer: " + ex.Message);
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
            txtUserID.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtStatus.Text = "";
            txtSearch.Text = "";
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                txtUserID.Text = row.Cells["UserID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();

                if (row.Cells["Phone"].Value != DBNull.Value)
                {
                    txtPhone.Text = row.Cells["Phone"].Value.ToString();
                }
                else
                {
                    txtPhone.Text = "";
                }

                if (row.Cells["Address"].Value != DBNull.Value)
                {
                    txtAddress.Text = row.Cells["Address"].Value.ToString();
                }
                else
                {
                    txtAddress.Text = "";
                }

                txtStatus.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // This part is commented because AdminDashboard may not be ready yet.
            // When AdminDashboard is ready, remove the comments and use this code.

            
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
            

        }
    }
}