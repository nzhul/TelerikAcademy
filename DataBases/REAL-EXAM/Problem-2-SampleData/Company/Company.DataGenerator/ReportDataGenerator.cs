namespace Company.DataGenerator
{
    using Company.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class ReportDataGenerator : DataGenerator, IDataGenerator
    {
        public ReportDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var employeesIds = this.Database.Employees.Select(a => a.Id).ToList();

            Console.WriteLine("Adding Reports:");
            for (int i = 0; i < this.Count; i++)
            {
                var newReport = new Report
                {
                    Text = "Blank",
                    CreatedOn = DateTime.Now,
                    EmployeeId = employeesIds[this.Random.GetRandomNumber(0, employeesIds.Count - 1)]
                };

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Reports.Add(newReport);
            }
            Console.WriteLine();
            Console.WriteLine("Projects added!");
        }
    }
}
