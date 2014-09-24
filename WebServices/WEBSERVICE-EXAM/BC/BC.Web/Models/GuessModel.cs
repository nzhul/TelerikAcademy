using BC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BC.Web.Models
{
    public class GuessModel
    {
        public static Expression<Func<Guess, GuessModel>> FromGuess
        {
            get
            {
                return g => new GuessModel
                {
                    Id = g.Id,
                    UserId = g.UserId,
                    Username = g.User.UserName,
                    GameId = g.GameId,
                    Number = g.Number,
                    DateMade = g.DateMade,
                    CowsCount = g.CowsCount,
                    BullsCount = g.BullsCount,
                };
            }
        }

        public GuessModel()
        {

        }

        public GuessModel(Guess guess)
        {
            this.Id = guess.Id;
            UserId = guess.UserId;
            Username = guess.User.UserName;
            GameId = guess.GameId;
            Number = guess.Number;
            DateMade = guess.DateMade;
            CowsCount = guess.CowsCount;
            BullsCount = guess.BullsCount;
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }

        public int GameId { get; set; }

        public string Number { get; set; }
        public DateTime DateMade { get; set; }
        public int CowsCount { get; set; }
        public int BullsCount { get; set; }
    }
}