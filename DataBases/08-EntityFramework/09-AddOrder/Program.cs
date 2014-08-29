namespace AddOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindDataModel.Data;
    using System.Transactions;
    public class Program
    {
        static void Main()
        {
            AddOrder("TestOrderZZZ", 12, 23, 0.1m, 0.05f);
        }

        private static void AddOrder(string shipName, short amount, int productID, decimal unitPrice, float discount)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                TransactionScope scope = new TransactionScope();
                using (scope)
                {
                    try
                    {
                        Order newOrder = new Order { ShipName = shipName };
                        db.Orders.Add(newOrder);
                        db.SaveChanges();

                        var result = db.Orders.Where(x => x.ShipName == shipName);

                        using (NorthwindEntities dbContext = new NorthwindEntities())
                        {
                            foreach (var item in result)
                            {
                                Order_Detail newDetail = new Order_Detail
                                {
                                    OrderID = item.OrderID,
                                    ProductID = productID,
                                    UnitPrice = unitPrice,
                                    Discount = discount,
                                    Quantity = amount,
                                };

                                dbContext.Order_Details.Add(newDetail);
                                dbContext.SaveChanges();
                            }
                        }
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }
    }
}
