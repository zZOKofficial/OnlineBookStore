using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class CartForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        // For testing separately, we use customer ID 3.
        // In real login system, customer ID will come from LoginForm.
        int customerId = 3;

        public CartForm()
        {
            InitializeComponent();
        }

        public CartForm(int loggedInCustomerId)
        {
            InitializeComponent();
            customerId = loggedInCustomerId;
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private int GetActiveCartId()
        {
            int cartId = 0;

            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT CartID
                                 FROM Carts
                                 WHERE UserID = @UserID
                                 AND Status = 'Active'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", customerId);

                con.Open();

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    cartId = Convert.ToInt32(result);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error finding active cart: " + ex.Message);
            }

            return cartId;
        }

        private void LoadCartItems()
        {
            try
            {
                int cartId = GetActiveCartId();

                if (cartId == 0)
                {
                    dgvCartItems.DataSource = null;
                    lblTotalAmountValue.Text = "0.00";
                    return;
                }

                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    ci.CartItemID,
                                    ci.BookID,
                                    b.Title,
                                    b.Author,
                                    ci.Quantity,
                                    ci.Price,
                                    (ci.Quantity * ci.Price) AS SubTotal,
                                    b.Stock AS AvailableStock
                                FROM CartItems ci
                                INNER JOIN Books b ON ci.BookID = b.BookID
                                WHERE ci.CartID = @CartID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@CartID", cartId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvCartItems.DataSource = dt;

                CalculateTotal(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cart items: " + ex.Message);
            }
        }

        private void CalculateTotal(DataTable dt)
        {
            decimal total = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total = total + Convert.ToDecimal(dt.Rows[i]["SubTotal"]);
            }

            lblTotalAmountValue.Text = total.ToString("0.00");
        }

        private void dgvCartItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCartItems.Rows[e.RowIndex];

                txtCartItemID.Text = row.Cells["CartItemID"].Value.ToString();
                txtBookID.Text = row.Cells["BookID"].Value.ToString();
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtAuthor.Text = row.Cells["Author"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                txtAvailableStock.Text = row.Cells["AvailableStock"].Value.ToString();
                txtSubTotal.Text = row.Cells["SubTotal"].Value.ToString();
            }
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (txtCartItemID.Text == "")
            {
                MessageBox.Show("Please select a cart item first.");
                return;
            }

            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please enter quantity.");
                return;
            }

            int quantity;
            int availableStock;

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter a valid quantity.");
                return;
            }

            if (!int.TryParse(txtAvailableStock.Text, out availableStock))
            {
                MessageBox.Show("Invalid stock value.");
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.");
                return;
            }

            if (quantity > availableStock)
            {
                MessageBox.Show("Quantity cannot be greater than available stock.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"UPDATE CartItems
                                 SET Quantity = @Quantity
                                 WHERE CartItemID = @CartItemID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@CartItemID", txtCartItemID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Cart quantity updated successfully.");

                LoadCartItems();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating quantity: " + ex.Message);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (txtCartItemID.Text == "")
            {
                MessageBox.Show("Please select a cart item first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to remove this item?",
                "Remove Item",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string query = "DELETE FROM CartItems WHERE CartItemID = @CartItemID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CartItemID", txtCartItemID.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Item removed from cart.");

                LoadCartItems();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing item: " + ex.Message);
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            int cartId = GetActiveCartId();

            if (cartId == 0)
            {
                MessageBox.Show("Your cart is empty.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string loadQuery = @"SELECT 
                                        ci.BookID,
                                        ci.Quantity,
                                        ci.Price,
                                        b.Stock
                                    FROM CartItems ci
                                    INNER JOIN Books b ON ci.BookID = b.BookID
                                    WHERE ci.CartID = @CartID";

                SqlDataAdapter adapter = new SqlDataAdapter(loadQuery, con);
                adapter.SelectCommand.Parameters.AddWithValue("@CartID", cartId);

                DataTable cartTable = new DataTable();
                adapter.Fill(cartTable);

                if (cartTable.Rows.Count == 0)
                {
                    MessageBox.Show("Your cart is empty.");
                    return;
                }

                decimal totalAmount = 0;

                for (int i = 0; i < cartTable.Rows.Count; i++)
                {
                    int quantity = Convert.ToInt32(cartTable.Rows[i]["Quantity"]);
                    int stock = Convert.ToInt32(cartTable.Rows[i]["Stock"]);
                    decimal price = Convert.ToDecimal(cartTable.Rows[i]["Price"]);

                    if (quantity > stock)
                    {
                        MessageBox.Show("One or more books do not have enough stock.");
                        return;
                    }

                    totalAmount = totalAmount + (quantity * price);
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to place this order?\n\nPayment Method: Cash on Delivery",
                    "Place Order",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    return;
                }

                con.Open();

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string orderQuery = @"INSERT INTO Orders
                                          (UserID, TotalAmount, Status)
                                          VALUES
                                          (@UserID, @TotalAmount, 'Pending');
                                          SELECT SCOPE_IDENTITY();";

                    SqlCommand orderCmd = new SqlCommand(orderQuery, con, transaction);
                    orderCmd.Parameters.AddWithValue("@UserID", customerId);
                    orderCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                    int orderId = Convert.ToInt32(orderCmd.ExecuteScalar());

                    for (int i = 0; i < cartTable.Rows.Count; i++)
                    {
                        int bookId = Convert.ToInt32(cartTable.Rows[i]["BookID"]);
                        int quantity = Convert.ToInt32(cartTable.Rows[i]["Quantity"]);
                        decimal price = Convert.ToDecimal(cartTable.Rows[i]["Price"]);

                        string detailsQuery = @"INSERT INTO OrderDetails
                                                (OrderID, BookID, Quantity, Price)
                                                VALUES
                                                (@OrderID, @BookID, @Quantity, @Price)";

                        SqlCommand detailsCmd = new SqlCommand(detailsQuery, con, transaction);
                        detailsCmd.Parameters.AddWithValue("@OrderID", orderId);
                        detailsCmd.Parameters.AddWithValue("@BookID", bookId);
                        detailsCmd.Parameters.AddWithValue("@Quantity", quantity);
                        detailsCmd.Parameters.AddWithValue("@Price", price);

                        detailsCmd.ExecuteNonQuery();

                        string stockQuery = @"UPDATE Books
                                              SET Stock = Stock - @Quantity,
                                                  Status = CASE 
                                                            WHEN Stock - @Quantity <= 0 THEN 'Unavailable'
                                                            ELSE Status
                                                           END,
                                                  UpdatedAt = GETDATE()
                                              WHERE BookID = @BookID";

                        SqlCommand stockCmd = new SqlCommand(stockQuery, con, transaction);
                        stockCmd.Parameters.AddWithValue("@Quantity", quantity);
                        stockCmd.Parameters.AddWithValue("@BookID", bookId);

                        stockCmd.ExecuteNonQuery();
                    }

                    string cartUpdateQuery = @"UPDATE Carts
                                               SET Status = 'Ordered'
                                               WHERE CartID = @CartID";

                    SqlCommand cartUpdateCmd = new SqlCommand(cartUpdateQuery, con, transaction);
                    cartUpdateCmd.Parameters.AddWithValue("@CartID", cartId);

                    cartUpdateCmd.ExecuteNonQuery();

                    transaction.Commit();

                    con.Close();

                    MessageBox.Show("Order placed successfully.\nPayment Method: Cash on Delivery\nOrder Status: Pending");

                    LoadCartItems();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    con.Close();

                    MessageBox.Show("Order failed: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCartItems();
            ClearFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtCartItemID.Clear();
            txtBookID.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtAvailableStock.Clear();
            txtSubTotal.Clear();
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