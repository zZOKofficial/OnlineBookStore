using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public partial class LoginForm : Form
    {
        // Change this connection string according to your SQL Server name
        string connectionString = @"Data Source=LAPTOP-PIRA03V1\SQLEXPRESS;Initial Catalog=OnlineBookStoreDB;Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show("Please enter email and password.");
                return;
            }

            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                string query = "SELECT UserID, FullName, Role, Status FROM Users WHERE Email = @Email AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["UserID"]);
                    string fullName = reader["FullName"].ToString();
                    string role = reader["Role"].ToString();
                    string status = reader["Status"].ToString();

                    if (status != "Active")
                    {
                        if (status == "Pending")
                        {
                            MessageBox.Show("Your account is pending. Please wait for admin approval.");
                        }
                        else if (status == "Rejected")
                        {
                            MessageBox.Show("Your account request has been rejected.");
                        }
                        else if (status == "Inactive")
                        {
                            MessageBox.Show("Your account is inactive. Please contact admin.");
                        }
                        else
                        {
                            MessageBox.Show("Your account is not active.");
                        }

                        return;
                    }

                    MessageBox.Show("Login successful. Welcome " + fullName);

                    // ================================
                    // TEMPORARY TESTING MODE
                    // Form opening codes are commented.
                    // When you complete forms, remove comments.
                    // ================================

                    if (role == "Admin")
                    {
                       

                         AdminDashboard adminDashboard = new AdminDashboard();
                         adminDashboard.Show();
                         this.Hide();
                    }
                    else if (role == "Manager")
                    {
                        

                         ManagerDashboard managerDashboard = new ManagerDashboard();
                         managerDashboard.Show();
                         this.Hide();
                    }
                    else if (role == "Customer")
                    {
                       

                         CustomerDashboard customerDashboard = new CustomerDashboard();
                         customerDashboard.Show();
                         this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Unknown user role.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           

             RegisterForm registerForm = new RegisterForm();
             registerForm.Show();
             this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}