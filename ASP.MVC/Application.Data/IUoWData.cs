using Application.Data.Repositories;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface IData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Manufacturer> Manufacturers { get; }
        IRepository<Laptop> Laptops { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
