using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class ManageBooksForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public ManageBooksForm()
        {
            InitializeComponent();
        }

        private void ManageBooksForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadBooks()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = "SELECT BookID, Title, Author, Category, Price, Stock, Status FROM Books";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                dgvBooks.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtAuthor.Text == "" || txtCategory.Text == "" ||
                txtPrice.Text == "" || txtStock.Text == "")
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            decimal price;
            int stock;

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Please enter a valid stock quantity.");
                return;
            }

            if (price < 0)
            {
                MessageBox.Show("Price cannot be negative.");
                return;
            }

            if (stock < 0)
            {
                MessageBox.Show("Stock cannot be negative.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"INSERT INTO Books
                                (Title, Author, Category, Price, Stock, Status)
                                VALUES
                                (@Title, @Author, @Category, @Price, @Stock, @Status)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Book added successfully.");

                LoadBooks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding book: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtBookID.Text == "")
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            if (txtTitle.Text == "" || txtAuthor.Text == "" || txtCategory.Text == "" ||
                txtPrice.Text == "" || txtStock.Text == "")
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            decimal price;
            int stock;

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Please enter a valid stock quantity.");
                return;
            }

            if (price < 0)
            {
                MessageBox.Show("Price cannot be negative.");
                return;
            }

            if (stock < 0)
            {
                MessageBox.Show("Stock cannot be negative.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"UPDATE Books
                                SET Title = @Title,
                                    Author = @Author,
                                    Category = @Category,
                                    Price = @Price,
                                    Stock = @Stock,
                                    Status = @Status,
                                    UpdatedAt = GETDATE()
                                WHERE BookID = @BookID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@BookID", txtBookID.Text);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Book updated successfully.");

                LoadBooks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating book: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtBookID.Text == "")
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                // We are not permanently deleting the book.
                // We are only making the book unavailable.
                string query = @"UPDATE Books
                                SET Status = 'Unavailable',
                                    UpdatedAt = GETDATE()
                                WHERE BookID = @BookID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookID", txtBookID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Book marked as unavailable.");

                LoadBooks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting book: " + ex.Message);
            }
        }

        private void btnMakeAvailable_Click(object sender, EventArgs e)
        {
            if (txtBookID.Text == "")
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"UPDATE Books
                                SET Status = 'Available',
                                    UpdatedAt = GETDATE()
                                WHERE BookID = @BookID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookID", txtBookID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Book is now available.");

                LoadBooks();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error making book available: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT BookID, Title, Author, Category, Price, Stock, Status
                                FROM Books
                                WHERE Title LIKE @Search
                                   OR Author LIKE @Search
                                   OR Category LIKE @Search";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvBooks.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching book: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtBookID.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            txtSearch.Clear();

            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                txtBookID.Text = row.Cells["BookID"].Value.ToString();
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                txtCategory.Text = row.Cells["Category"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();
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