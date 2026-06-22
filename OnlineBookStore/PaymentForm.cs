using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class PaymentForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        // For testing separately
        int customerId = 3;
        int cartId = 0;

        public PaymentForm()
        {
            InitializeComponent();
        }

        public PaymentForm(int loggedInCustomerId, int activeCartId)
        {
            InitializeComponent();

            customerId = loggedInCustomerId;
            cartId = activeCartId;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            cmbPaymentMethod.SelectedIndex = 0;

            if (cartId == 0)
            {
                cartId = GetActiveCartId();
            }

            LoadCartSummary();
        }

        private int GetActiveCartId()
        {
            int activeCartId = 0;

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
                    activeCartId = Convert.ToInt32(result);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error finding active cart: " + ex.Message);
            }

            return activeCartId;
        }

        private void LoadCartSummary()
        {
            try
            {
                if (cartId == 0)
                {
                    MessageBox.Show("No active cart found.");
                    lblTotalAmountValue.Text = "0.00";
                    return;
                }

                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    ci.CartItemID,
                                    b.Title,
                                    b.Author,
                                    ci.Quantity,
                                    ci.Price,
                                    (ci.Quantity * ci.Price) AS SubTotal
                                FROM CartItems ci
                                INNER JOIN Books b ON ci.BookID = b.BookID
                                WHERE ci.CartID = @CartID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@CartID", cartId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvPaymentItems.DataSource = dt;

                decimal totalAmount = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    totalAmount = totalAmount + Convert.ToDecimal(dt.Rows[i]["SubTotal"]);
                }

                lblTotalAmountValue.Text = totalAmount.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payment summary: " + ex.Message);
            }
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentMethod.Text == "Cash on Delivery")
            {
                txtTransactionID.Enabled = false;
                txtTransactionID.Clear();
                lblTransactionID.Text = "Transaction ID";
            }
            else
            {
                txtTransactionID.Enabled = true;
                lblTransactionID.Text = "Transaction ID";
            }
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (cartId == 0)
            {
                MessageBox.Show("No active cart found.");
                return;
            }

            if (cmbPaymentMethod.Text == "")
            {
                MessageBox.Show("Please select payment method.");
                return;
            }

            if (cmbPaymentMethod.Text != "Cash on Delivery" && txtTransactionID.Text == "")
            {
                MessageBox.Show("Please enter transaction ID.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to confirm this order?",
                "Confirm Order",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }

            PlaceOrderWithPayment();
        }

        private void PlaceOrderWithPayment()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string loadCartQuery = @"SELECT 
                                            ci.BookID,
                                            ci.Quantity,
                                            ci.Price,
                                            b.Stock
                                        FROM CartItems ci
                                        INNER JOIN Books b ON ci.BookID = b.BookID
                                        WHERE ci.CartID = @CartID";

                SqlDataAdapter adapter = new SqlDataAdapter(loadCartQuery, con);
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

                        string orderDetailsQuery = @"INSERT INTO OrderDetails
                                                     (OrderID, BookID, Quantity, Price)
                                                     VALUES
                                                     (@OrderID, @BookID, @Quantity, @Price)";

                        SqlCommand detailsCmd = new SqlCommand(orderDetailsQuery, con, transaction);
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

                    string paymentStatus = "Pending";

                    if (cmbPaymentMethod.Text == "Cash on Delivery")
                    {
                        paymentStatus = "Pending";
                    }
                    else
                    {
                        paymentStatus = "Paid";
                    }

                    string paymentQuery = @"INSERT INTO Payments
                                            (OrderID, PaymentMethod, TransactionID, Amount, PaymentStatus)
                                            VALUES
                                            (@OrderID, @PaymentMethod, @TransactionID, @Amount, @PaymentStatus)";

                    SqlCommand paymentCmd = new SqlCommand(paymentQuery, con, transaction);
                    paymentCmd.Parameters.AddWithValue("@OrderID", orderId);
                    paymentCmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);

                    if (txtTransactionID.Text == "")
                    {
                        paymentCmd.Parameters.AddWithValue("@TransactionID", DBNull.Value);
                    }
                    else
                    {
                        paymentCmd.Parameters.AddWithValue("@TransactionID", txtTransactionID.Text);
                    }

                    paymentCmd.Parameters.AddWithValue("@Amount", totalAmount);
                    paymentCmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);

                    paymentCmd.ExecuteNonQuery();

                    string cartUpdateQuery = @"UPDATE Carts
                                               SET Status = 'Ordered'
                                               WHERE CartID = @CartID";

                    SqlCommand cartUpdateCmd = new SqlCommand(cartUpdateQuery, con, transaction);
                    cartUpdateCmd.Parameters.AddWithValue("@CartID", cartId);

                    cartUpdateCmd.ExecuteNonQuery();

                    transaction.Commit();

                    con.Close();

                    MessageBox.Show("Order confirmed successfully.\nPayment Method: " + cmbPaymentMethod.Text);

                    ClearFields();
                    dgvPaymentItems.DataSource = null;
                    lblTotalAmountValue.Text = "0.00";
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
                MessageBox.Show("Error confirming payment: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCartSummary();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbPaymentMethod.SelectedIndex = 0;
            txtTransactionID.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // This part is commented because CartForm may not be ready/connected yet.
            // When CartForm is ready, remove the comments and use this code.

            
            CartForm cartForm = new CartForm(customerId);
            cartForm.Show();
            this.Hide();
            

           
        }
    }
}