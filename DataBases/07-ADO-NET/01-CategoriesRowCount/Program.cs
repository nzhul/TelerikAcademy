namespace CategoriesRowCount
{
    using System; 
    using CategoriesRowCount.Properties;
    using System.Data.SqlClient;
    using System.Configuration;

    public class Program
    {
        static void Main()
        {
            string connectionString = Properties.Settings.Default.Connection;
            SqlConnection dbCon = new SqlConnection(connectionString);
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories ", dbCon);
                int employeesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Employees count: {0} ", employeesCount);
                Console.WriteLine();
            }
        }
    }
}
