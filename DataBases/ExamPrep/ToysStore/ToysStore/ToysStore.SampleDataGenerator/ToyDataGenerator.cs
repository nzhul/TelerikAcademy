using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysStore.Data;
using System.Linq;

namespace ToysStore.SampleDataGenerator
{
    internal class ToyDataGenerator : DataGenerator, IDataGenerator
    {
        public ToyDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }
        public override void Generate()
        {
            var ageRangeIds = this.Database.AgeRanges.Select(a => a.Id).ToList();
            var manufacturerIds = this.Database.Manufacturers.Select(m => m.Id).ToList();
            var categoryIds = this.Database.Categories.Select(c => c.Id).ToList();

            Console.WriteLine("Adding Toys:");
            for (int i = 0; i < this.Count; i++)
            {
                var newToy = new Toy
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50),
                    Type = this.Random.GetRandomStringWithRandomLength(5, 50),
                    Price = this.Random.GetRandomNumber(10, 500),
                    Color = this.Random.GetRandomNumber(1, 5) == 5 ? null : this.Random.GetRandomStringWithRandomLength(5, 50),
                    ManufacturerId = manufacturerIds[this.Random.GetRandomNumber(0, manufacturerIds.Count - 1)],
                    AgeRangeId = ageRangeIds[this.Random.GetRandomNumber(0, manufacturerIds.Count - 1)],
                };

                if (categoryIds.Count > 0)
                {
                    var uniqueCategoryIds = new HashSet<int>();
                    var categoriesInToy = this.Random.GetRandomNumber(1, Math.Min(10, categoryIds.Count));

                    while (uniqueCategoryIds.Count != categoriesInToy)
                    {
                        uniqueCategoryIds.Add(categoryIds[this.Random.GetRandomNumber(0, categoryIds.Count - 1)]);
                    }

                    foreach (var uniqueCategoryId in uniqueCategoryIds)
                    {
                        newToy.Categories.Add(this.Database.Categories.Find(uniqueCategoryId));
                    }
                }

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Toys.Add(newToy);
            }
            Console.WriteLine();
            Console.WriteLine("Toys added!");
        }
    }
}