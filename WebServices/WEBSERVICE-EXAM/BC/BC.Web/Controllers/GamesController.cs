namespace BC.Web.Controllers
{
    using BC.Data;
    using BC.Models;
    using BC.Web.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    public class GamesController : BaseApiController
    {

        const int defaultPageSize = 10;
        public GamesController()
            : this(new BCData(new BCDbContext()))
        {

        }

        public GamesController(IBCData data)
            : base(data)
        {
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(0);
        }

        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            var games = GetAllSorted()
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize);
            if (games == null)
            {
                return NotFound();
            }
            return Ok(games);
        }

        private IEnumerable<GameModel> GetAllSorted()
        {
            return this.data.Games.All()
                .OrderByDescending(g => g.State)
                .ThenByDescending(g => g.Name)
                .ThenByDescending(g => g.DateCreated)
                .ThenByDescending(g => g.RedPlayer.UserName)
                .Select(GameModel.FromGame);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            var game = this.data.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            var gamesDetailModel = new GameDetailModel(game);

            return Ok(gamesDetailModel);
        }


        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(GameModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var redPlayer = this.data.Users.Find(userId);

            var newGame = new Game
            {
                Name = model.Name,
                DateCreated = DateTime.Now,
                RedPlayerId = userId,
                RedPlayer = redPlayer,
                //BluePlayerId = null,
                RedNumber = model.Number,
                //BlueNumber = null,
                State = GameState.WaitingForOpponent

            };

            this.data.Games.Add(newGame);
            this.data.SaveChanges();

            // Make new Guess on creating the game
            this.Guess(newGame.Id, new GuessModel { Number = newGame.RedNumber });

            var gameModel = new GameModel(newGame);
            gameModel.Red = redPlayer.UserName;

            // Send notification to the creator of the game
            string notificationMessage = "You have created new game with Name: " + newGame.Name;
            SendNotification(newGame.Id, userId, "GameCreated", notificationMessage);

            return Ok(gameModel);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult Join(int id, GameModel model)
        {
            // MAKE SURE YOU ARE NOT THE CREATOR OF THE GAME!
            var currentUserId = this.User.Identity.GetUserId();

            var game = this.data.Games
                .All()
                .Where(g => g.State == GameState.WaitingForOpponent && g.RedPlayerId != currentUserId)
                .FirstOrDefault();

            if (game == null)
            {
                return NotFound();
            }

            var bluePlayer = this.data.Users.Find(currentUserId);
            game.BluePlayerId = currentUserId;
            game.BluePlayer = bluePlayer;
            game.State = GameState.TurnBlue;
            this.data.SaveChanges();

            this.Guess(game.Id, new GuessModel { Number = model.Number });
            var joinGameResultModel = new JoinGameModel(game.Name);

            // Send notification to the creator of the game about new player Joining his game
            string notificationMessage = bluePlayer.UserName + " joined your game " + game.Name;
            SendNotification(game.Id, currentUserId, "GameJoined", notificationMessage);

            return Ok(joinGameResultModel);
        }


        [HttpPost]
        [Authorize]
        public IHttpActionResult Guess(int id, GuessModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var author = this.data.Users.Find(userId);
            var newGuess = new Guess
            {
                UserId = userId,
                User = author,
                GameId = id,
                Number = model.Number,
                DateMade = DateTime.Now,
                CowsCount = 0,
                BullsCount = 0
            };


            this.data.Guesses.Add(newGuess);
            this.data.SaveChanges();

            var guessModel = new GuessModel(newGuess);

            // Send Notification to the guess maker
            string notificationMessage = "You have made new guess ("+model.Number+") on game №: " + id;
            SendNotification(id, userId, "GuessMade", notificationMessage);

            return Ok(guessModel);
        }

        private void SendNotification(int gameId, string userId, string type, string message)
        {
            var receiver = this.data.Users.Find(userId);
            var game = this.data.Games.All()
                .Where(a => a.Id == gameId)
                .FirstOrDefault();

            if (game == null)
            {
                throw new ArgumentException("Game do not exists");
            }

            var newNotification = new Notification
            {
                Message = message,
                DateCreated = DateTime.Now,
                Type = type,
                State = NotificationState.Unread,
                GameId = gameId,
                Game = game,
                UserId = userId,
                User = receiver
            };

            this.data.Notifications.Add(newNotification);
            receiver.Notifications.Add(newNotification);
            this.data.SaveChanges();
        }
    }
}
