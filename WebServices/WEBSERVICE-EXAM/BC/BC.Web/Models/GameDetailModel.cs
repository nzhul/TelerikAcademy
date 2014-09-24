namespace BC.Web.Models
{
    using BC.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class GameDetailModel
    {
        public GameDetailModel(Game game)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.DateCreaded = game.DateCreated;
            this.Red = game.RedPlayer.UserName;
            if (game.BluePlayer != null)
            {
                this.Blue = game.BluePlayer.UserName;
            }
            else
            {
                this.Blue = "No blue player yet";
            }
            this.YourNumber = game.RedNumber;
            this.YourGuesses = game.Guesses.AsQueryable()
                .Where(g=>g.UserId == game.RedPlayerId)
                .Select(GuessModel.FromGuess).ToArray();
            this.OpponentGuesses = game.Guesses.AsQueryable()
                .Where(g => g.UserId != game.RedPlayerId)
                .Select(GuessModel.FromGuess).ToArray();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreaded { get; set; }
        public string Red { get; set; }
        public string Blue { get; set; }
        public string YourNumber { get; set; }
        public ICollection<GuessModel> YourGuesses { get; set; }
        public ICollection<GuessModel> OpponentGuesses { get; set; }
    }
}