namespace TicTacToe.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TicTacToe.Data.Repository;
    using TicTacToe.Models;
    public interface ITicTacToeData
    {
        IRepository<User> Users { get; }
        IRepository<Game> Games { get; }

        int SaveChanges();
    }
}
