namespace CustomerDAO
{
    using System;
    using System.Linq;
    using NorthwindDataModel.Data;
    using System.Data;
    public static class DAO
    {
        public static void AddCustomer(string customerID, string companyName)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                Customer newCustomer = new Customer()
                {
                    CustomerID = customerID,
                    CompanyName = companyName
                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                Console.WriteLine("Customer with ID:{0} and CompanyName: {1} Recorded Successfully", customerID, companyName);
            }
        }

        public static void DeleteCustomer(string customerID)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                Customer customerToRemove = FindCustomerById(customerID);
                db.Entry(customerToRemove).State = EntityState.Deleted;
                db.Customers.Remove(customerToRemove);
                db.SaveChanges();
                Console.WriteLine("Customer with ID:{0} DELETED Successfully", customerID);
            }
        }

        public static void UpdateCustomer(string customerID, string newCompanyName)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                Customer customerToUpdate = FindCustomerById(customerID);
                db.Entry(customerToUpdate).State = EntityState.Modified;
                customerToUpdate.CompanyName = newCompanyName;
                db.SaveChanges();
                Console.WriteLine("Customer with ID:{0} UPDATED Successfully", customerID);
            }
        }

        private static Customer FindCustomerById(string customerID)
        {
            NorthwindEntities db = new NorthwindEntities();

            using (db)
            {
                Customer searchedCustomer = db.Customers.First(c=>c.CustomerID == customerID);
                return searchedCustomer;
            }
        }
    }
}
