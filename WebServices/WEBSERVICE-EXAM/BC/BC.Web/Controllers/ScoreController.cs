namespace BC.Web.Controllers
{
    using BC.Data;
    using BC.Web.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    public class ScoreController : BaseApiController
    {
        public ScoreController()
            : this(new BCData(new BCDbContext()))
        {

        }

        public ScoreController(IBCData data)
            : base(data)
        {
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            var users = GetAllSorted()
                .Take(10);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        private IEnumerable<UserScoreModel> GetAllSorted()
        {
            return this.data.Users.All()
                .OrderByDescending(u => u.UserRank)
                .Select(UserScoreModel.FromUserScoreModel);
        }
    }
}
