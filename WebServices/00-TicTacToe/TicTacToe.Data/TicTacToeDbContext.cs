using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;
using System.Data.Entity;
using TicTacToe.Data.Migrations;

namespace TicTacToe.Data
{
    public class TicTacToeDbContext : IdentityDbContext<User>
    {
        public TicTacToeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicTacToeDbContext, Configuration>());
        }

        public static TicTacToeDbContext Create()
        {
            return new TicTacToeDbContext();
        }
    }
}
