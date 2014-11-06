using Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        Random rand = new Random();
        public List<Manufacturer> ManufacturersSeed { get; set; }
        public List<Laptop> LaptopsSeed { get; set; }
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ManufacturersSeed = new List<Manufacturer>();
            this.LaptopsSeed = new List<Laptop>();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.AddInitialManufacturers(context);
            this.AddInitialLaptops(context);
        }

        private void AddInitialLaptops(ApplicationDbContext context)
        {
            if (!context.Laptops.Any())
            {
                ApplicationUser user = new ApplicationUser() {UserName = "TestUser", Email = "TestMail@test.com"};
                for (int i = 0; i < 10; i++)
                {
                    var laptop = new Laptop();
                    laptop.HardDiskSize = rand.Next(10, 1000);
                    laptop.ImageUrl = "http://www.laptop.bg/system/images/32155/thumb/B5400.jpg?1390207159";
                    laptop.Manufacturer = ManufacturersSeed[rand.Next(0, ManufacturersSeed.Count)];
                    laptop.Model = "thinkpad";
                    laptop.MonitorSize = 15.4;
                    laptop.Price = rand.Next(600, 3000);
                    laptop.RamMemorySize = rand.Next(1, 16);
                    laptop.Weight = 3;

                    var votesCount = rand.Next(0, 10);
                    for (int j = 0; j < votesCount; j++)
                    {
                        laptop.Votes.Add(new Vote { Laptop = laptop, VotedBy = user });
                    }
                    context.Laptops.Add(laptop);
                }

                context.SaveChanges();
            }
        }

        private void AddInitialManufacturers(ApplicationDbContext context)
        {
            if (!context.Manufacturers.Any())
            {
                var Manufacturer1 = new Manufacturer() { Name = "Dell" };
                var Manufacturer2 = new Manufacturer() { Name = "HP" };
                var Manufacturer3 = new Manufacturer() { Name = "Lenovo" };
                var Manufacturer4 = new Manufacturer() { Name = "Aser" };
                var Manufacturer5 = new Manufacturer() { Name = "Asus" };
                context.Manufacturers.Add(Manufacturer1); ManufacturersSeed.Add(Manufacturer1);
                context.Manufacturers.Add(Manufacturer2); ManufacturersSeed.Add(Manufacturer2);
                context.Manufacturers.Add(Manufacturer3); ManufacturersSeed.Add(Manufacturer3);
                context.Manufacturers.Add(Manufacturer4); ManufacturersSeed.Add(Manufacturer4);
                context.Manufacturers.Add(Manufacturer5); ManufacturersSeed.Add(Manufacturer5);
                context.SaveChanges();
            }
        }
    }
}
