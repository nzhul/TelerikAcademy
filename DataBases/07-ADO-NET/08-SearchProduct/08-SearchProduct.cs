namespace SearchProduct
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Program
    {
        static void Main()
        {
            // Please change the connection string with Your Own 
            // Check the database Name too!!!
            string connectionString = "Server=LENOVO\\SQLEXPRESS; Database=NORTHWND; Integrated Security=true";
            SqlConnection dbCon = new SqlConnection(connectionString);
            dbCon.Open();

            Console.Write("Search Product: ");
            string pattern = Console.ReadLine();

            SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE CHARINDEX(@pattern, ProductName) > 0", dbCon);
            command.Parameters.AddWithValue("@pattern", pattern);

            using (dbCon)
            {
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var productName = reader["ProductName"];
                            Console.WriteLine(" -> {0}", productName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Product not found!");
                    }
                    
                }
            }
        }
    }
}
