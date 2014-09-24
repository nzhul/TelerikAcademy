using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.Models;
using BC.Data.Migrations;

namespace BC.Data
{
    public class BCDbContext : IdentityDbContext<ApplicationUser>
    {
        public BCDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BCDbContext, Configuration>());
        }

        public static BCDbContext Create()
        {
            return new BCDbContext();
        }

        public IDbSet<Game> Games { get; set; }
        public IDbSet<Guess> Guesses { get; set; }
        public IDbSet<Notification> Notifications { get; set; }
    }
}
