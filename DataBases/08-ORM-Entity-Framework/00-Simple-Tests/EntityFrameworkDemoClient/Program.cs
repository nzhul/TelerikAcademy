using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Client
{
    class Program
    {
        static void Main()
        {
            using(var db = new NORTHWNDEntities())
            {
                var region = db.Regions.Find(6);
                region.RegionDescription = "Stamat";
                db.SaveChanges();
            }
        }
    }
}
