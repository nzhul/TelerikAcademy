namespace CategoriesRowCount
{
    using CategoriesRowCount.Properties;
    using System.Data.SqlClient;

    public class Program
    {
        static void Main()
        {
            SqlConnection db = 
                new SqlConnection("Server=SQLEXPRESS; Database=NORTHWIND; Integrated Security=true");

            db.Open();
            using (db)
            {
                SqlCommand rowCount = new SqlCommand("SELECT COUNT(*) FROM Categories", db);
                System.Console.WriteLine("Number of rows in Categories Table: {0}", rowCount.ExecuteScalar());
            }
        }
    }
}
