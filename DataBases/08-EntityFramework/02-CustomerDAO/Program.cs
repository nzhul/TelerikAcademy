namespace CustomerDAO
{
    using NorthwindDataModel.Data;

    public class Program
    {
        static void Main()
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                DAO.AddCustomer("ZZZWW", "StamatCompany");
                //DAO.UpdateCustomer("ZZZWW", "NewCompanyName");
                //DAO.DeleteCustomer("ZZZWW");
            }
        }
    }
}
