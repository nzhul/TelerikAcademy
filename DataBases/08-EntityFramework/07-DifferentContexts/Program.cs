namespace DifferentContexts
{
    using NorthwindDataModel.Data;

    class Program
    {
        static void Main()
        {
            using (NorthwindEntities dbFirst = new NorthwindEntities())
            {
                using (NorthwindEntities dbSecond = new NorthwindEntities())
                {
                    dbFirst.Customers.Add(new Customer() { CustomerID = "xswde", CompanyName = "CONFLICTTEST" });
                    dbSecond.Customers.Add(new Customer() { CustomerID = "xldde", CompanyName = "CONFLICTTEST2" });
                    dbSecond.SaveChanges();
                    dbFirst.SaveChanges();
                    dbSecond.SaveChanges();
                }
            }
        }
    }
}
