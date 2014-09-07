using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysStore.Data;

namespace ToysStore.SampleDataGenerator
{
    internal class CategoryDataGenerator : DataGenerator, IDataGenerator
    {
        public CategoryDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }
        public override void Generate()
        {
            Console.WriteLine("Adding categories");
            for (int i = 0; i < this.Count; i++)
            {
                var newCategory = new Category
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50)
                };

                this.Database.Categories.Add(newCategory);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    Database.SaveChanges();
                }
            }
            Console.WriteLine();
            Console.WriteLine("Categories added!");
        }
    }
}
