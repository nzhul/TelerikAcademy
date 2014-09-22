using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using Articles.Data.Migrations;

namespace Articles.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<Alert> Alerts { get; set; }
    }
}
