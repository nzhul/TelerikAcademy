using BC.Data.Repositories;
using BC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Data
{
    public interface IBCData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Game> Games { get; }
        IRepository<Guess> Guesses { get; }
        IRepository<Notification> Notifications { get; }
        int SaveChanges();
    }
}
