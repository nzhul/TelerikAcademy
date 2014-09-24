using BC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BC.Web.Models
{
    public class GameModel
    {
        public static Expression<Func<Game, GameModel>> FromGame
        {
            get
            {
                return g => new GameModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Blue = g.BluePlayer.UserName,
                    Red = g.RedPlayer.UserName,
                    GameState = g.State,
                    DateCreated = g.DateCreated,
                    Number = g.RedNumber
                };
            }
        }

        public GameModel()
        {

        }
        public GameModel(Game game)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.Blue = "No blue player yet";
            //this.Red = game.RedPlayer.UserName;
            this.GameState = game.State;
            this.DateCreated = game.DateCreated;
            this.Number = game.RedNumber;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Blue { get; set; }
        public string Red { get; set; }
        public GameState GameState { get; set; }
        public DateTime DateCreated { get; set; }
        public string Number { get; set; }

    }
}