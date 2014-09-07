namespace ToysStore.SampleDataGenerator
{
    using System;
    using System.Collections.Generic;
    using ToysStore.Data;
    internal class ManufacturerDataGenerator : DataGenerator, IDataGenerator
    {
        public ManufacturerDataGenerator(IRandomDataGenerator randomDataGenerator, ToysStoreEntities toyStoreEntities, int countOfGeneratedObjects)
            :base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var manufacturersToBeAdded = new HashSet<string>();
            while (manufacturersToBeAdded.Count != this.Count)
            {
                manufacturersToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(5, 50));
            }

            int index = 0;
            Console.WriteLine("Adding Manufacturers:");
            foreach (var manufactureName in manufacturersToBeAdded)
            {
                var newManufacturer = new Manufacturer
                {
                    Name = manufactureName,
                    Country = this.Random.GetRandomStringWithRandomLength(2, 100)
                };

                this.Database.Manufacturers.Add(newManufacturer);

                if (index % 100 == 0)
                {
                    Console.Write(".");
                    Database.SaveChanges();
                }
                index++;
            }
            Console.WriteLine();
            Console.WriteLine("Manufacturers Added!");
        }
    }
}
