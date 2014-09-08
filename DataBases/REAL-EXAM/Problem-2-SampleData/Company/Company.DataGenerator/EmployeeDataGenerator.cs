using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataGenerator
{
    internal class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities toyStoreEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var departmentIds = this.Database.Departments.Select(a => a.Id).ToList();

            Console.WriteLine("Adding Employees:");
            for (int i = 0; i < this.Count; i++)
            {
                var newEmployee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Salary = this.Random.GetRandomNumber(50000, 200000),
                    DepartmentId = departmentIds[this.Random.GetRandomNumber(0, departmentIds.Count - 1)]
                };

                if (i >= 1)
                {
                    bool hasManager = this.Random.GetRandomNumber(0, 100) <= 95;
                    if (hasManager)
                    {
                        newEmployee.ManagerId = i;
                    }
                }

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Employees.Add(newEmployee);
            }
            Console.WriteLine();
            Console.WriteLine("Employees added!");
        }
    }
}
