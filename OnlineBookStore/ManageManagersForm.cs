using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class ManageManagersForm : Form
    {
        public ManageManagersForm()
        {
            InitializeComponent();
        }

        private void ManageManagersForm_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;
            LoadManagers();
        }

        private void LoadManagers()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = "SELECT UserID, FullName, Email, Password, Phone, Address, Status FROM Users WHERE Role = 'Manager'";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvManagers.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading managers: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter name, email and password.");
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"INSERT INTO Users
                                     (FullName, Email, Password, Phone, Address, Role, Status)
                                     VALUES
                                     (@FullName, @Email, @Password, @Phone, @Address, 'Manager', @Status)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Manager added successfully.");

                    LoadManagers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding manager: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Please select a manager first.");
                return;
            }

            if (txtFullName.Text == "" || txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter name, email and password.");
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string query = @"UPDATE Users
                                     SET FullName = @FullName,
                                         Email = @Email,
                                         Password = @Password,
                                         Phone = @Phone,
                                         Address = @Address,
                                         Status = @Status,
                                         UpdatedAt = GETDATE()
                                     WHERE UserID = @UserID AND Role = 'Manager'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Manager updated successfully.");

                    LoadManagers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating manager: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Please select a manager first.");
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to remove this manager?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    // Beginner-safe delete:
                    // We are not deleting the manager permanently.
                    // We are only changing the status to Inactive.
                    string query = @"UPDATE Users
                                     SET Status = 'Inactive',
                                         UpdatedAt = GETDATE()
                                     WHERE UserID = @UserID AND Role = 'Manager'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Manager removed successfully.");

                    LoadManagers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting manager: " + ex.Message);
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            ChangeManagerStatus("Active");
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            ChangeManagerStatus("Inactive");
        }

        private void ChangeManagerStatus(string status)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Please select a manager first.");
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
                                     WHERE UserID = @UserID AND Role = 'Manager'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@UserID", txtUserID.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Manager status changed to " + status);

                    LoadManagers();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing status: " + ex.Message);
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

                    string query = @"SELECT UserID, FullName, Email, Password, Phone, Address, Status
                                     FROM Users
                                     WHERE Role = 'Manager'
                                     AND (FullName LIKE @Search OR Email LIKE @Search)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvManagers.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching manager: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadManagers();
        }

        private void ClearFields()
        {
            txtUserID.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtSearch.Text = "";
            cmbStatus.SelectedIndex = 0;
        }

        private void dgvManagers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvManagers.Rows[e.RowIndex];

                txtUserID.Text = row.Cells["UserID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();

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

                cmbStatus.Text = row.Cells["Status"].Value.ToString();
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