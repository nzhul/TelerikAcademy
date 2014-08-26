// 04. Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
namespace InsertNewProduct
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

            var productName = "Monster Energy Drink";
            var supplierId = 18;
            var categoryId = 2;
            var quantityPerUnit = "16 - 500 g tins";
            var unitPrice = 85.0d;
            var unitsInStock = 2000;
            var unitsInOrder = 700;
            var reorderLevel = 30;
            var discontinued = 0;

            SqlCommand command = GenerateCommand(dbCon, productName, supplierId, categoryId, 
                quantityPerUnit, unitPrice, unitsInStock, unitsInOrder, reorderLevel, discontinued);

            using (dbCon)
            {
                Console.WriteLine("INSERTING NEW PODUCT:");
                Console.WriteLine("--------------------");

                var result = command.ExecuteNonQuery();
                Console.WriteLine("({0} row(s) affected)", result); 
            }
        }

        private static SqlCommand GenerateCommand(SqlConnection dbCon, string productName, 
            int supplierId, int categoryId, string quantityPerUnit, double unitPrice, 
            int unitsInStock, int unitsInOrder, int reorderLevel, int discontinued)
        {
            SqlCommand command =
                new SqlCommand(@"INSERT INTO Products
                             VALUES (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, 
                                     @unitsInStock, @unitsInOrder, @reorderLevel, @discontinued)", dbCon);

            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@supplierId", supplierId);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            command.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            command.Parameters.AddWithValue("@unitPrice", unitPrice);
            command.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            command.Parameters.AddWithValue("@unitsInOrder", unitsInOrder);
            command.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            command.Parameters.AddWithValue("@discontinued", discontinued);
            return command;
        }
    }
}
