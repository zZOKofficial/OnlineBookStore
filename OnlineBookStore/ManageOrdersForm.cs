using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class ManageOrdersForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public ManageOrdersForm()
        {
            InitializeComponent();
        }

        private void ManageOrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();

            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void LoadOrders()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    o.OrderID,
                                    u.FullName AS CustomerName,
                                    u.Email,
                                    o.OrderDate,
                                    o.TotalAmount,
                                    o.Status
                                FROM Orders o
                                INNER JOIN Users u ON o.UserID = u.UserID
                                ORDER BY o.OrderID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                dgvOrders.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
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
                                    b.Title AS BookTitle,
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

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            LoadOrderDetails();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (txtOrderID.Text == "")
            {
                MessageBox.Show("Please select an order first.");
                return;
            }

            if (cmbStatus.Text == "")
            {
                MessageBox.Show("Please select order status.");
                return;
            }

            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"UPDATE Orders
                                SET Status = @Status
                                WHERE OrderID = @OrderID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Order status updated successfully.");

                LoadOrders();
                LoadOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order status: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = db.GetConnection();

                string query = @"SELECT 
                                    o.OrderID,
                                    u.FullName AS CustomerName,
                                    u.Email,
                                    o.OrderDate,
                                    o.TotalAmount,
                                    o.Status
                                FROM Orders o
                                INNER JOIN Users u ON o.UserID = u.UserID
                                WHERE 
                                    u.FullName LIKE @Search
                                    OR u.Email LIKE @Search
                                    OR o.Status LIKE @Search
                                    OR CAST(o.OrderID AS NVARCHAR) LIKE @Search
                                ORDER BY o.OrderID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvOrders.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching orders: " + ex.Message);
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
            txtCustomerName.Clear();
            txtEmail.Clear();
            txtOrderDate.Clear();
            txtTotalAmount.Clear();
            txtSearch.Clear();

            if (cmbStatus.Items.Count > 0)
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];

                txtOrderID.Text = row.Cells["OrderID"].Value.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtOrderDate.Text = row.Cells["OrderDate"].Value.ToString();
                txtTotalAmount.Text = row.Cells["TotalAmount"].Value.ToString();
                cmbStatus.Text = row.Cells["Status"].Value.ToString();

                LoadOrderDetails();
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