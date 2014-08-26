// 02. Write a program that retrieves the name and description of all categories in the Northwind DB.
namespace GetNameAndDescription
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
                Console.WriteLine("FETCHING CATEGORIES AND DESCRIPTION:");
                Console.WriteLine("------------------------------------");
                SqlCommand cmdCategoryNameDescription = new SqlCommand(
                  "SELECT CategoryName, Description FROM Categories", dbCon);
                SqlDataReader reader = cmdCategoryNameDescription.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string categoryDescription = (string)reader["Description"];
                        Console.WriteLine("{0}: \n\t{1}\n", categoryName, categoryDescription);
                    }
                }
            }
        }
    }
}
