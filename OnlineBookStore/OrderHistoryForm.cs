using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class OrderHistoryForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        // For testing separately, we use customer ID 3.
        // In real login system, customer ID will come from LoginForm.
        int customerId = 3;

        public OrderHistoryForm()
        {
            InitializeComponent();
        }

        public OrderHistoryForm(int loggedInCustomerId)
        {
            InitializeComponent();
            customerId = loggedInCustomerId;
        }

        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    OrderID,
                                    OrderDate,
                                    TotalAmount,
                                    Status
                                FROM Orders
                                WHERE UserID = @UserID
                                ORDER BY OrderID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@UserID", customerId);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvOrders.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order history: " + ex.Message);
            }
        }

        private void LoadOrderDetails()
        {
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Please select an order first.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    od.OrderDetailID,
                                    od.OrderID,
                                    b.Title,
                                    b.Author,
                                    od.Quantity,
                                    od.Price,
                                    (od.Quantity * od.Price) AS SubTotal
                                FROM OrderDetails od
                                INNER JOIN Books b ON od.BookID = b.BookID
                                WHERE od.OrderID = @OrderID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@OrderID", txtOrderID.Text);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvOrderDetails.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message);
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];

                txtOrderID.Text = row.Cells["OrderID"].Value.ToString();
                txtOrderDate.Text = row.Cells["OrderDate"].Value.ToString();
                txtTotalAmount.Text = row.Cells["TotalAmount"].Value.ToString();
                txtStatus.Text = row.Cells["Status"].Value.ToString();

                LoadOrderDetails();
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            LoadOrderDetails();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Please select an order first.");
                return;
            }

            if (txtStatus.Text != "Pending")
            {
                MessageBox.Show("Only Pending orders can be cancelled.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this order?",
                "Cancel Order",
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

                con.Open();

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string detailsQuery = @"SELECT BookID, Quantity
                                            FROM OrderDetails
                                            WHERE OrderID = @OrderID";

                    SqlCommand detailsCmd = new SqlCommand(detailsQuery, con, transaction);
                    detailsCmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);

                    SqlDataReader reader = detailsCmd.ExecuteReader();

                    DataTable orderDetailsTable = new DataTable();
                    orderDetailsTable.Load(reader);

                    for (int i = 0; i < orderDetailsTable.Rows.Count; i++)
                    {
                        int bookId = Convert.ToInt32(orderDetailsTable.Rows[i]["BookID"]);
                        int quantity = Convert.ToInt32(orderDetailsTable.Rows[i]["Quantity"]);

                        string stockUpdateQuery = @"UPDATE Books
                                                    SET Stock = Stock + @Quantity,
                                                        Status = 'Available',
                                                        UpdatedAt = GETDATE()
                                                    WHERE BookID = @BookID";

                        SqlCommand stockCmd = new SqlCommand(stockUpdateQuery, con, transaction);
                        stockCmd.Parameters.AddWithValue("@Quantity", quantity);
                        stockCmd.Parameters.AddWithValue("@BookID", bookId);

                        stockCmd.ExecuteNonQuery();
                    }

                    string orderUpdateQuery = @"UPDATE Orders
                                                SET Status = 'Cancelled'
                                                WHERE OrderID = @OrderID
                                                AND UserID = @UserID
                                                AND Status = 'Pending'";

                    SqlCommand orderCmd = new SqlCommand(orderUpdateQuery, con, transaction);
                    orderCmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                    orderCmd.Parameters.AddWithValue("@UserID", customerId);

                    int rows = orderCmd.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        transaction.Rollback();
                        con.Close();

                        MessageBox.Show("Order could not be cancelled. It may not be Pending anymore.");
                        return;
                    }

                    transaction.Commit();
                    con.Close();

                    MessageBox.Show("Order cancelled successfully.");

                    LoadOrders();
                    ClearFields();
                    dgvOrderDetails.DataSource = null;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    con.Close();

                    MessageBox.Show("Cancel failed: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling order: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
            ClearFields();
            dgvOrderDetails.DataSource = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            dgvOrderDetails.DataSource = null;
        }

        private void ClearFields()
        {
            txtOrderID.Clear();
            txtOrderDate.Clear();
            txtTotalAmount.Clear();
            txtStatus.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // This part is commented because CustomerDashboard may not be ready/connected yet.
            // When CustomerDashboard is ready, remove the comments and use this code.

            
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
            

            
        }

        private void lblOrderDetailsList_Click(object sender, EventArgs e)
        {

        }
    }
}