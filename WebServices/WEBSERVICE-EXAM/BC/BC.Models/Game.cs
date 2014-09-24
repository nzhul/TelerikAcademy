using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Models
{
    public class Game
    {
        public Game()
        {
            this.State = GameState.WaitingForOpponent;
            this.Guesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public GameState State { get; set; }
        public DateTime DateCreated { get; set; }

        public string BluePlayerId { get; set; }

        public virtual ApplicationUser BluePlayer { get; set; }

        public string RedPlayerId { get; set; }
        public virtual ApplicationUser RedPlayer { get; set; }

        public string BlueNumber { get; set; }
        public string RedNumber { get; set; }

        public virtual ICollection<Guess> Guesses { get; set; }
    }
}
