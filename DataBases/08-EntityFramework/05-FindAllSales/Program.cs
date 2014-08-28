namespace FindAllSales
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindDataModel.Data;

    public class Program
    {
        static void Main()
        {
            FindSales(1996, 1996, "AK");
        }

        private static void FindSales(int startDate, int endDate, string region)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                var searchResult =
                    from order in db.Orders
                    join orderDetails in db.Order_Details
                    on order.OrderID equals orderDetails.OrderID
                    where order.ShipRegion == region
                    && order.OrderDate.Value.Year == startDate
                    && order.ShippedDate.Value.Year == endDate
                    select new
                    {
                        Amount = orderDetails.Quantity,
                        Region = order.ShipRegion,
                    };

                foreach (var customer in searchResult)
                {
                    Console.WriteLine("Amount: {0}, Region: {1}", customer.Amount, customer.Region);
                }
            }
        }
    }
}
