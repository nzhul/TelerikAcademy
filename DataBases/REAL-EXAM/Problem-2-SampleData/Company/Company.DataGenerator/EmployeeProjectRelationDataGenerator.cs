using Company.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataGenerator
{
    internal class EmployeeProjectRelationDataGenerator: DataGenerator, IDataGenerator
    {
        public EmployeeProjectRelationDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var employeesIds = this.Database.Employees.Select(a => a.Id).ToList();
            var projectsIds = this.Database.Projects.Select(r => r.Id).ToList();

            Console.WriteLine("Adding Employee-Project Relations:");
            for (int i = 0; i < this.Count; i++)
            {
                var newRelation = new EmployeeProject
                {
                    EmployeeId = employeesIds[this.Random.GetRandomNumber(0, employeesIds.Count - 1)],
                    ProjectId = projectsIds[this.Random.GetRandomNumber(0, projectsIds.Count - 1)],
                    StartingDate = DateTime.Now.AddDays(this.Random.GetRandomNumber(-10, 0)),
                    EndingDate = DateTime.Now.AddDays(this.Random.GetRandomNumber(0, 10))
                };

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.EmployeeProjects.Add(newRelation);
            }
            Console.WriteLine();
            Console.WriteLine("Relations added!");
        }
    }
}
