namespace Cars.Importer
{
    using System;
    using Cars.Data;
    using System.IO;
    using Cars.Models;
    using Newtonsoft.Json.Linq;
    using System.Xml.Linq;
    class Program
    {
        static void Main()
        {
            // Working!
            var db = new CarsDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;

            for (int i = 0; i <= 4; i++)
            {
                var filePath = "../../../../JSONData/data." + i + ".json";
                var jsonText = File.ReadAllText(filePath);

                JArray allCars = JArray.Parse(jsonText);

                Console.WriteLine("Adding cars from file: {0}", filePath);
                int counter = 0;
                foreach (var car in allCars)
                {
                    Manufacturer newManufacturer = new Manufacturer
                    {
                        Name = car["ManufacturerName"].ToString()
                    };


                    Dealer newDealer = new Dealer
                    {
                        Name = car["Dealer"]["Name"].ToString()
                    };
                    newDealer.Cities.Add(new City { Name = car["Dealer"]["City"].ToString() });

                    Car newCar = new Car
                    {
                        Model = car["Model"].ToString(),
                        TransmisionType = int.Parse(car["TransmissionType"].ToString()),
                        Price = decimal.Parse(car["Price"].ToString()),
                        Year = int.Parse(car["Year"].ToString()),
                        Manufacturer = newManufacturer,
                        Dealer = newDealer
                    };

                    newManufacturer.Cars.Add(newCar);
                    newDealer.Cars.Add(newCar);

                    db.Manufacturers.Add(newManufacturer);
                    db.Dealers.Add(newDealer);
                    db.Cars.Add(newCar);
                    Console.Write(".");

                    if (counter % 100 == 0)
                    {
                        db.SaveChanges();
                    }

                    counter++;
                }
                db.SaveChanges();
                Console.WriteLine("\nFile Read Complete -> All Cars where added successfuly!");
                Console.WriteLine("\n");
            }
            db.Configuration.AutoDetectChangesEnabled = false;
        }
    }
}
