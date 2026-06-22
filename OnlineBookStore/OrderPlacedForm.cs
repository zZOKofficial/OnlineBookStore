using System;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public partial class OrderPlacedForm : Form
    {
        int customerId = 3;
        int orderId = 0;
        decimal totalAmount = 0;
        string paymentMethod = "";

        public OrderPlacedForm()
        {
            InitializeComponent();
        }

        public OrderPlacedForm(int loggedInCustomerId, int placedOrderId, decimal orderTotalAmount, string selectedPaymentMethod)
        {
            InitializeComponent();

            customerId = loggedInCustomerId;
            orderId = placedOrderId;
            totalAmount = orderTotalAmount;
            paymentMethod = selectedPaymentMethod;
        }

        private void OrderPlacedForm_Load(object sender, EventArgs e)
        {
            lblOrderIDValue.Text = orderId.ToString();
            lblTotalAmountValue.Text = totalAmount.ToString("0.00");
            lblPaymentMethodValue.Text = paymentMethod;
            lblOrderStatusValue.Text = "Pending";
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            // This part is commented because OrderHistoryForm may not be ready yet.
            // When OrderHistoryForm is ready, remove the comments and use this code.

            
            OrderHistoryForm orderHistoryForm = new OrderHistoryForm(customerId);
            orderHistoryForm.Show();
            this.Hide();
            

        }

        private void btnContinueShopping_Click(object sender, EventArgs e)
        {
            // This part is commented because BrowseBooksForm may not be connected yet.
            // When BrowseBooksForm is ready, remove the comments and use this code.

            
            BrowseBooksForm browseBooksForm = new BrowseBooksForm(customerId);
            browseBooksForm.Show();
            this.Hide();
            

            
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // This part is commented because CustomerDashboard may not be connected yet.
            // When CustomerDashboard is ready, remove the comments and use this code.

            
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
            

            
        }
    }
}