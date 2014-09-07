namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ToysStore.Data;
    internal class AgeRangeDataGenerator: DataGenerator, IDataGenerator
    {
        public AgeRangeDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding AgeRanges:");
            int count = 0;
            for (int i = 0; i < this.Count / 5; i++)
            {
                for (int j = 1 + 1; j <= i + 5; j++)
                {
                    var newAgeRange = new AgeRanx
                    {
                        MinimumAge = i,
                        MaximumAge = j
                    };

                    this.Database.AgeRanges.Add(newAgeRange);

                    count++;

                    if (count % 100 == 0)
                    {
                        this.Database.SaveChanges();
                    }

                    if (count == this.Count)
                    {
                        Console.WriteLine();
                        Console.WriteLine("AgeRanges added!");
                        return;
                    }
                }
            }
        }
    }
}
