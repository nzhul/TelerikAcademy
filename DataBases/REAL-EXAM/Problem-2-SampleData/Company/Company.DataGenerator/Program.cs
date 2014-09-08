using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new DepartmentDataGenerator(random, db, 100),
                new EmployeeDataGenerator(random, db, 2000),
                new ProjectDataGenerator(random, db, 2000),
                new EmployeeProjectRelationDataGenerator(random, db, 2000),
                new ReportDataGenerator(random, db, 250000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
