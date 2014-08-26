namespace CategoriesRowCount
{
    using CategoriesRowCount.Properties;
    using System.Data.SqlClient;

    public class Program
    {
        static void Main()
        {
            SqlConnection db = 
                new SqlConnection("Server=KAKADU5-PC\\SQLEXPRESS; Database=Northwind; Integrated Security=true");

            db.Open();
            using (db)
            {
                SqlCommand rowCount = new SqlCommand("SELECT COUNT(*) FROM Categories", db);
                System.Console.WriteLine("Number of rows in Categories Table: {0}", rowCount.ExecuteScalar());
            }
        }
    }
}
