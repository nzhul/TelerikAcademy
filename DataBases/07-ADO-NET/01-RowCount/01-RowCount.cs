// 01. Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  rows in the Categories table.
namespace RowCount
{
    using System;
    using System.Data.SqlClient;
    class Program
    {
        static void Main()
        {
            // Please change the connection string with Your Own 
            // Check the database Name too!!!
            string connectionString = "Server=LENOVO\\SQLEXPRESS; Database=NORTHWND; Integrated Security=true";
            SqlConnection dbCon = new SqlConnection(connectionString);
            dbCon.Open();
            using (dbCon)
            {
                Console.WriteLine("FETCHING CATEGORIES COUNT:");
                Console.WriteLine("------------------------------------");
                SqlCommand rowCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories ", dbCon);
                int categoriesCount = (int)rowCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
                Console.WriteLine();
            }
        }
    }
}
