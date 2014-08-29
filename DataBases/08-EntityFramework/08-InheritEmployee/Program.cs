namespace InheritEmployee
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
            Employee extendedEmployee = new Employee();
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                extendedEmployee = db.Employees.Find(1);

                foreach (var item in extendedEmployee.Territories)
                {
                    Console.WriteLine("Territory description - {0}", item.TerritoryDescription);
                }
            }
        }
    }
}
