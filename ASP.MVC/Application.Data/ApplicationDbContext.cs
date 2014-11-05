using Application.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("LaptopSystemConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Laptop> Laptops { get; set; }
        public IDbSet<Manufacturer> Manufacturers { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Vote> Votes { get; set; }
    }
}
