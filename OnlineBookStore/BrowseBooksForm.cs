using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class BrowseBooksForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        // For testing separately, we use customer ID 3.
        // In real login system, customer ID will come from LoginForm.
        int customerId = 3;

        public BrowseBooksForm()
        {
            InitializeComponent();
        }

        public BrowseBooksForm(int loggedInCustomerId)
        {
            InitializeComponent();
            customerId = loggedInCustomerId;
        }

        private void BrowseBooksForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    BookID,
                                    Title,
                                    Author,
                                    Category,
                                    Price,
                                    Stock,
                                    Status
                                FROM Books
                                WHERE Status = 'Available'
                                AND Stock > 0
                                ORDER BY BookID DESC";

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    BookID,
                                    Title,
                                    Author,
                                    Category,
                                    Price,
                                    Stock,
                                    Status
                                FROM Books
                                WHERE Status = 'Available'
                                AND Stock > 0
                                AND
                                (
                                    Title LIKE @Search
                                    OR Author LIKE @Search
                                    OR Category LIKE @Search
                                )
                                ORDER BY BookID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvBooks.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching books: " + ex.Message);
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

                txtQuantity.Text = "1";
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtBookID.Text == "")
            {
                MessageBox.Show("Please select a book first.");
                return;
            }

            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please enter quantity.");
                return;
            }

            int quantity;
            int stock;

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Invalid stock value.");
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.");
                return;
            }

            if (quantity > stock)
            {
                MessageBox.Show("Quantity cannot be greater than available stock.");
                return;
            }

            try
            {
                int cartId = GetOrCreateActiveCart();

                if (cartId == 0)
                {
                    MessageBox.Show("Could not create or find cart.");
                    return;
                }

                int bookId = Convert.ToInt32(txtBookID.Text);
                decimal price = Convert.ToDecimal(txtPrice.Text);

                SqlConnection con = db.GetConnection();

                con.Open();

                string checkQuery = @"SELECT CartItemID, Quantity
                                      FROM CartItems
                                      WHERE CartID = @CartID
                                      AND BookID = @BookID";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@CartID", cartId);
                checkCmd.Parameters.AddWithValue("@BookID", bookId);

                SqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    int cartItemId = Convert.ToInt32(reader["CartItemID"]);
                    int oldQuantity = Convert.ToInt32(reader["Quantity"]);
                    int newQuantity = oldQuantity + quantity;

                    reader.Close();

                    if (newQuantity > stock)
                    {
                        MessageBox.Show("This book already exists in cart. Total quantity cannot be greater than stock.");
                        con.Close();
                        return;
                    }

                    string updateQuery = @"UPDATE CartItems
                                           SET Quantity = @Quantity,
                                               Price = @Price
                                           WHERE CartItemID = @CartItemID";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@Quantity", newQuantity);
                    updateCmd.Parameters.AddWithValue("@Price", price);
                    updateCmd.Parameters.AddWithValue("@CartItemID", cartItemId);

                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    reader.Close();

                    string insertQuery = @"INSERT INTO CartItems
                                           (CartID, BookID, Quantity, Price)
                                           VALUES
                                           (@CartID, @BookID, @Quantity, @Price)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                    insertCmd.Parameters.AddWithValue("@CartID", cartId);
                    insertCmd.Parameters.AddWithValue("@BookID", bookId);
                    insertCmd.Parameters.AddWithValue("@Quantity", quantity);
                    insertCmd.Parameters.AddWithValue("@Price", price);

                    insertCmd.ExecuteNonQuery();
                }

                con.Close();

                MessageBox.Show("Book added to cart successfully.");

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding to cart: " + ex.Message);
            }
        }

        private int GetOrCreateActiveCart()
        {
            int cartId = 0;

            try
            {
                SqlConnection con = db.GetConnection();

                con.Open();

                string findCartQuery = @"SELECT CartID
                                         FROM Carts
                                         WHERE UserID = @UserID
                                         AND Status = 'Active'";

                SqlCommand findCartCmd = new SqlCommand(findCartQuery, con);
                findCartCmd.Parameters.AddWithValue("@UserID", customerId);

                object result = findCartCmd.ExecuteScalar();

                if (result != null)
                {
                    cartId = Convert.ToInt32(result);
                }
                else
                {
                    string createCartQuery = @"INSERT INTO Carts
                                               (UserID, Status)
                                               VALUES
                                               (@UserID, 'Active');
                                               SELECT SCOPE_IDENTITY();";

                    SqlCommand createCartCmd = new SqlCommand(createCartQuery, con);
                    createCartCmd.Parameters.AddWithValue("@UserID", customerId);

                    cartId = Convert.ToInt32(createCartCmd.ExecuteScalar());
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating cart: " + ex.Message);
            }

            return cartId;
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
            txtQuantity.Clear();
            txtSearch.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // This part is commented because CustomerDashboard may not be ready yet.
            // When CustomerDashboard is ready, remove the comments and use this code.

            
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
            

            
        }
    }
}