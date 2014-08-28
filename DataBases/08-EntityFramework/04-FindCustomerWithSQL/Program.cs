namespace FindCustomerWithSQL
{
    using System;
    using NorthwindDataModel.Data;

    public class Program
    {
        public static void Main()
        {
            FindAllCustomers(1997, "Canada");
        }

        private static void FindAllCustomers(int orderDate, string shipDestination)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                string customersQuery = @"SELECT c.ContactName from Customers
                                    c INNER JOIN Orders o ON o.CustomerID = c.CustomerID 
                                    WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";
                object[] queryParams = { orderDate, shipDestination };

                var customersResult = db.Database.SqlQuery<string>(customersQuery, queryParams);

                foreach (var customer in customersResult)
                {
                    Console.WriteLine("Customer: {0}", customer);
                }
            }
        }
    }
}
