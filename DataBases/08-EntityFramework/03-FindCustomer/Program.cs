namespace FindCustomer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindDataModel.Data;

    class Program
    {
        public static void Main()
        {
            FindAllCustomers(1997, "Canada");
        }

        public static void FindAllCustomers(int orderDate, string shipDestination)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                var customers =
                    from order in db.Orders
                    where order.OrderDate.Value.Year == orderDate && order.ShipCountry == shipDestination
                    select order;

                foreach (var customer in customers)
                {
                    Console.WriteLine("Customer: {0}", customer.Customer.ContactName);
                }
            }
        }
    }
}
