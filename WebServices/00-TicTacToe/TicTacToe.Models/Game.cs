namespace TicTacToe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Game
    {

        public Game()
        {
            this.Id = Guid.NewGuid();
            this.Board = "---------";
            this.State = GameState.WaitingForSecondPayer;
        }
        public Guid Id { get; set; }

        [StringLength(9)]
        [Column(TypeName="char")]
        public string Board { get; set; }
        public GameState State { get; set; }

        public string FirstPlayerId { get; set; }

        [Required]
        public virtual User FirstPlayer { get; set; }
        public string SecondPlayerId { get; set; }
        public virtual User SecondPLayer { get; set; }


    }
}
