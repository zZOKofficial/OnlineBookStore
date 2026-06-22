using System.Data.SqlClient;

namespace OnlineBookStore.DataAccessLayer
{
    public class DatabaseConnection
    {
        private string connectionString = @"Data Source=LAPTOP-PIRA03V1\SQLEXPRESS;Initial Catalog=OnlineBookStoreDB;Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}