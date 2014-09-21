namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using TicTacToe.Data;

    [Authorize]
    public class GamesController : ApiController
    {

        private ITicTacToeData data;

        public GamesController()
            :this(new TicTacToeData(new TicTacToeDbContext()))
        {

        }
        public GamesController(ITicTacToeData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetUsersCount()
        {
            var count = this.data.Users.All().Count();
            return Ok(count);
        }
    }
}
