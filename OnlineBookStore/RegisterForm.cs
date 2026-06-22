using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;

            if (fullName == "" || email == "" || password == "")
            {
                MessageBox.Show("Full name, email and password are required.");
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("This email is already registered.");
                        return;
                    }

                    string query = "INSERT INTO Users (FullName, Email, Password, Phone, Address, Role, Status) " +
                                   "VALUES (@FullName, @Email, @Password, @Phone, @Address, @Role, @Status)";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Role", "Customer");
                    cmd.Parameters.AddWithValue("@Status", "Pending");

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Registration successful. Please wait for admin approval.");

                     

                        // Uncomment when LoginForm navigation is needed.
                         LoginForm loginForm = new LoginForm();
                         loginForm.Show();
                         this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           

            // Uncomment when LoginForm navigation is needed.
             LoginForm loginForm = new LoginForm();
             loginForm.Show();
             this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
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

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}