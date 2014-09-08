namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using Company.Data;
    internal class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var departmentsToBeAdded = new HashSet<string>();
            while (departmentsToBeAdded.Count != this.Count)
            {
                departmentsToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(5, 50));
            }

            int index = 0;
            Console.WriteLine("Adding Manufacturers:");
            foreach (var departmentName in departmentsToBeAdded)
            {
                var newDepartment = new Department
                {
                    Name = departmentName,
                };

                this.Database.Departments.Add(newDepartment);

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    Database.SaveChanges();
                }
                index++;
            }
            Console.WriteLine();
            Console.WriteLine("Departments Added!");
        }
    }
}
