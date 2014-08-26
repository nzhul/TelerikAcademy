// 03. Write a program that retrieves from the Northwind database all product categories
// and the names of the products in each category. Can you do this with a single SQL query (with table join)?
namespace CategoriesAndProducts
{
    using System;
    using System.Collections.Generic;
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
                Console.WriteLine("FETCHING CATEGORIES AND PRODUCTS:");
                Console.WriteLine("------------------------------------");
                SqlCommand cmdCategoriesAndProducts = new SqlCommand(
                  @"SELECT p.ProductName, c.CategoryName
                    FROM Products p INNER JOIN Categories c
                    ON p.CategoryID = c.CategoryID
                    ORDER BY CategoryName", dbCon);
                SqlDataReader reader = cmdCategoriesAndProducts.ExecuteReader();

                var finalResult = new Dictionary<string, HashSet<string>>(); 
                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        string categoryName = (string)reader["CategoryName"];
                        if (!finalResult.ContainsKey(categoryName))
                        {
                            finalResult[categoryName] = new HashSet<string>();
                        }

                        finalResult[categoryName].Add(productName);
                        
                    }
                }
                PrintResult(finalResult);
            }
        }

        private static void PrintResult(Dictionary<string, HashSet<string>> finalResult)
        {
            foreach (var category in finalResult)
            {
                Console.WriteLine("Category: {0}", category.Key);
                foreach (var productName in category.Value)
                {
                    Console.WriteLine(" -> {0}", productName);
                }

                Console.WriteLine();
            }
        }
    }
}
