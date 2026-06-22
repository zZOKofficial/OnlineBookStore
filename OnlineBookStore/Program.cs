using System;
using System.Windows.Forms;

namespace OnlineBookStore
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
           // Application.Run(new RegisterForm());
            // Application.Run(new AdminDashboard());
            // Application.Run(new ManageManagersForm());
            // Application.Run(new ManageCustomersForm());

            // Application.Run(new ManagerDashboard());
            // Application.Run(new ManageBooksForm());
            // Application.Run(new ManageOrdersForm());
            // Application.Run(new ViewCustomersForm());
             //Application.Run(new SalesReportForm());

            // Application.Run(new CustomerDashboard());
            // Application.Run(new BrowseBooksForm());
            // Application.Run(new CartForm());
            // Application.Run(new PaymentForm());
            // Application.Run(new OrderPlacedForm());
            // Application.Run(new OrderHistoryForm());
            //Application.Run(new ProfileForm());

        }
    }
}