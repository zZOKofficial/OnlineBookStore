using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OnlineBookStore.DataAccessLayer;

namespace OnlineBookStore
{
    public partial class SalesReportForm : Form
    {
        DatabaseConnection db = new DatabaseConnection();

        public SalesReportForm()
        {
            InitializeComponent();
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
            dtpEndDate.Value = DateTime.Today;

            LoadSummary();
            LoadSalesReport();
        }

        private void LoadSummary()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                con.Open();

                string totalSalesQuery = "SELECT ISNULL(SUM(TotalAmount), 0) FROM Orders WHERE Status = 'Delivered'";
                SqlCommand totalSalesCmd = new SqlCommand(totalSalesQuery, con);
                decimal totalSales = Convert.ToDecimal(totalSalesCmd.ExecuteScalar());
                lblTotalSalesValue.Text = totalSales.ToString("0.00");

                string totalOrdersQuery = "SELECT COUNT(*) FROM Orders";
                SqlCommand totalOrdersCmd = new SqlCommand(totalOrdersQuery, con);
                int totalOrders = Convert.ToInt32(totalOrdersCmd.ExecuteScalar());
                lblTotalOrdersValue.Text = totalOrders.ToString();

                string pendingOrdersQuery = "SELECT COUNT(*) FROM Orders WHERE Status = 'Pending'";
                SqlCommand pendingOrdersCmd = new SqlCommand(pendingOrdersQuery, con);
                int pendingOrders = Convert.ToInt32(pendingOrdersCmd.ExecuteScalar());
                lblPendingOrdersValue.Text = pendingOrders.ToString();

                string confirmedOrdersQuery = "SELECT COUNT(*) FROM Orders WHERE Status = 'Confirmed'";
                SqlCommand confirmedOrdersCmd = new SqlCommand(confirmedOrdersQuery, con);
                int confirmedOrders = Convert.ToInt32(confirmedOrdersCmd.ExecuteScalar());
                lblConfirmedOrdersValue.Text = confirmedOrders.ToString();

                string deliveredOrdersQuery = "SELECT COUNT(*) FROM Orders WHERE Status = 'Delivered'";
                SqlCommand deliveredOrdersCmd = new SqlCommand(deliveredOrdersQuery, con);
                int deliveredOrders = Convert.ToInt32(deliveredOrdersCmd.ExecuteScalar());
                lblDeliveredOrdersValue.Text = deliveredOrders.ToString();

                string cancelledOrdersQuery = "SELECT COUNT(*) FROM Orders WHERE Status = 'Cancelled'";
                SqlCommand cancelledOrdersCmd = new SqlCommand(cancelledOrdersQuery, con);
                int cancelledOrders = Convert.ToInt32(cancelledOrdersCmd.ExecuteScalar());
                lblCancelledOrdersValue.Text = cancelledOrders.ToString();

                string soldBooksQuery = @"SELECT ISNULL(SUM(od.Quantity), 0)
                                          FROM OrderDetails od
                                          INNER JOIN Orders o ON od.OrderID = o.OrderID
                                          WHERE o.Status = 'Delivered'";

                SqlCommand soldBooksCmd = new SqlCommand(soldBooksQuery, con);
                int soldBooks = Convert.ToInt32(soldBooksCmd.ExecuteScalar());
                lblSoldBooksValue.Text = soldBooks.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading summary: " + ex.Message);
            }
        }

        private void LoadSalesReport()
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
                                ORDER BY o.OrderDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                dgvSalesReport.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales report: " + ex.Message);
            }
        }

        private void LoadFilteredSalesReport()
        {
            try
            {
                SqlConnection con = db.GetConnection();

                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date.AddDays(1);

                string query = @"SELECT 
                                    o.OrderID,
                                    u.FullName AS CustomerName,
                                    u.Email,
                                    o.OrderDate,
                                    o.TotalAmount,
                                    o.Status
                                FROM Orders o
                                INNER JOIN Users u ON o.UserID = u.UserID
                                WHERE o.OrderDate >= @StartDate
                                AND o.OrderDate < @EndDate
                                ORDER BY o.OrderDate DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvSalesReport.DataSource = dt;

                LoadFilteredSummary(startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering sales report: " + ex.Message);
            }
        }

        private void LoadFilteredSummary(DateTime startDate, DateTime endDate)
        {
            try
            {
                SqlConnection con = db.GetConnection();

                con.Open();

                string totalSalesQuery = @"SELECT ISNULL(SUM(TotalAmount), 0)
                                           FROM Orders
                                           WHERE Status = 'Delivered'
                                           AND OrderDate >= @StartDate
                                           AND OrderDate < @EndDate";

                SqlCommand totalSalesCmd = new SqlCommand(totalSalesQuery, con);
                totalSalesCmd.Parameters.AddWithValue("@StartDate", startDate);
                totalSalesCmd.Parameters.AddWithValue("@EndDate", endDate);

                decimal totalSales = Convert.ToDecimal(totalSalesCmd.ExecuteScalar());
                lblTotalSalesValue.Text = totalSales.ToString("0.00");

                string totalOrdersQuery = @"SELECT COUNT(*)
                                            FROM Orders
                                            WHERE OrderDate >= @StartDate
                                            AND OrderDate < @EndDate";

                SqlCommand totalOrdersCmd = new SqlCommand(totalOrdersQuery, con);
                totalOrdersCmd.Parameters.AddWithValue("@StartDate", startDate);
                totalOrdersCmd.Parameters.AddWithValue("@EndDate", endDate);

                int totalOrders = Convert.ToInt32(totalOrdersCmd.ExecuteScalar());
                lblTotalOrdersValue.Text = totalOrders.ToString();

                string pendingOrdersQuery = @"SELECT COUNT(*)
                                              FROM Orders
                                              WHERE Status = 'Pending'
                                              AND OrderDate >= @StartDate
                                              AND OrderDate < @EndDate";

                SqlCommand pendingOrdersCmd = new SqlCommand(pendingOrdersQuery, con);
                pendingOrdersCmd.Parameters.AddWithValue("@StartDate", startDate);
                pendingOrdersCmd.Parameters.AddWithValue("@EndDate", endDate);

                int pendingOrders = Convert.ToInt32(pendingOrdersCmd.ExecuteScalar());
                lblPendingOrdersValue.Text = pendingOrders.ToString();

                string confirmedOrdersQuery = @"SELECT COUNT(*)
                                                FROM Orders
                                                WHERE Status = 'Confirmed'
                                                AND OrderDate >= @StartDate
                                                AND OrderDate < @EndDate";

                SqlCommand confirmedOrdersCmd = new SqlCommand(confirmedOrdersQuery, con);
                confirmedOrdersCmd.Parameters.AddWithValue("@StartDate", startDate);
                confirmedOrdersCmd.Parameters.AddWithValue("@EndDate", endDate);

                int confirmedOrders = Convert.ToInt32(confirmedOrdersCmd.ExecuteScalar());
                lblConfirmedOrdersValue.Text = confirmedOrders.ToString();

                string deliveredOrdersQuery = @"SELECT COUNT(*)
                                                FROM Orders
                                                WHERE Status = 'Delivered'
                                                AND OrderDate >= @StartDate
                                                AND OrderDate < @EndDate";

                SqlCommand deliveredOrdersCmd = new SqlCommand(deliveredOrdersQuery, con);
                deliveredOrdersCmd.Parameters.AddWithValue("@StartDate", startDate);
                deliveredOrdersCmd.Parameters.AddWithValue("@EndDate", endDate);

                int deliveredOrders = Convert.ToInt32(deliveredOrdersCmd.ExecuteScalar());
                lblDeliveredOrdersValue.Text = deliveredOrders.ToString();

                string cancelledOrdersQuery = @"SELECT COUNT(*)
                                                FROM Orders
                                                WHERE Status = 'Cancelled'
                                                AND OrderDate >= @StartDate
                                                AND OrderDate < @EndDate";

                SqlCommand cancelledOrdersCmd = new SqlCommand(cancelledOrdersQuery, con);
                cancelledOrdersCmd.Parameters.AddWithValue("@StartDate", startDate);
                cancelledOrdersCmd.Parameters.AddWithValue("@EndDate", endDate);

                int cancelledOrders = Convert.ToInt32(cancelledOrdersCmd.ExecuteScalar());
                lblCancelledOrdersValue.Text = cancelledOrders.ToString();

                string soldBooksQuery = @"SELECT ISNULL(SUM(od.Quantity), 0)
                                          FROM OrderDetails od
                                          INNER JOIN Orders o ON od.OrderID = o.OrderID
                                          WHERE o.Status = 'Delivered'
                                          AND o.OrderDate >= @StartDate
                                          AND o.OrderDate < @EndDate";

                SqlCommand soldBooksCmd = new SqlCommand(soldBooksQuery, con);
                soldBooksCmd.Parameters.AddWithValue("@StartDate", startDate);
                soldBooksCmd.Parameters.AddWithValue("@EndDate", endDate);

                int soldBooks = Convert.ToInt32(soldBooksCmd.ExecuteScalar());
                lblSoldBooksValue.Text = soldBooks.ToString();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading filtered summary: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("Start date cannot be greater than end date.");
                return;
            }

            LoadFilteredSalesReport();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSummary();
            LoadSalesReport();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
            dtpEndDate.Value = DateTime.Today;

            LoadSummary();
            LoadSalesReport();
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