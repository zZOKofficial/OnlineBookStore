using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class ProfileForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        // For testing separately, we use customer ID 3.
        // In real login system, customer ID will come from LoginForm.
        int customerId = 3;

        public ProfileForm()
        {
            InitializeComponent();
        }

        public ProfileForm(int loggedInCustomerId)
        {
            InitializeComponent();
            customerId = loggedInCustomerId;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    UserID,
                                    FullName,
                                    Email,
                                    Password,
                                    Phone,
                                    Address,
                                    Role,
                                    Status,
                                    CreatedAt
                                FROM Users
                                WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", customerId);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtUserID.Text = reader["UserID"].ToString();
                    txtFullName.Text = reader["FullName"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtPassword.Text = reader["Password"].ToString();

                    if (reader["Phone"] == DBNull.Value)
                    {
                        txtPhone.Text = "";
                    }
                    else
                    {
                        txtPhone.Text = reader["Phone"].ToString();
                    }

                    if (reader["Address"] == DBNull.Value)
                    {
                        txtAddress.Text = "";
                    }
                    else
                    {
                        txtAddress.Text = reader["Address"].ToString();
                    }

                    txtRole.Text = reader["Role"].ToString();
                    txtStatus.Text = reader["Status"].ToString();
                    txtCreatedAt.Text = reader["CreatedAt"].ToString();
                }
                else
                {
                    MessageBox.Show("Profile not found.");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "")
            {
                MessageBox.Show("Full name cannot be empty.");
                return;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Password cannot be empty.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"UPDATE Users
                                 SET FullName = @FullName,
                                     Password = @Password,
                                     Phone = @Phone,
                                     Address = @Address,
                                     UpdatedAt = GETDATE()
                                 WHERE UserID = @UserID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserID", customerId);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                if (txtPhone.Text == "")
                {
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                }

                if (txtAddress.Text == "")
                {
                    cmd.Parameters.AddWithValue("@Address", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Profile updated successfully.");

                LoadProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // This part is commented because CustomerDashboard may not be connected yet.
            // When CustomerDashboard is ready, remove the comments and use this code.

            
            CustomerDashboard customerDashboard = new CustomerDashboard(customerId);
            customerDashboard.Show();
            this.Hide();
            

            
        }
    }
}