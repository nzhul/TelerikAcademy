using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Models;
using Cars.Data.Migrations;

namespace Cars.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("CarsConnection") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }
        public IDbSet<Car> Cars { get; set; }
        public IDbSet<City> Cities { get; set; }
        public IDbSet<Dealer> Dealers { get; set; }
        public IDbSet<Manufacturer> Manufacturers { get; set; }
    }
}
