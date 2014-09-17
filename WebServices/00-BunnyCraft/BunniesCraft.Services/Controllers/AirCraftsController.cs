namespace BunniesCraft.Services.Controllers
{
    using BunniesCraft.Data.Repositories;
    using System.Web.Http;
    using BunniesCraft.Models;
    using System.Linq;
    using BunniesCraft.Services.Models;
    public class AirCraftsController : ApiController
    {
        private IRepository<AirCraft> aircrafts;

        public AirCraftsController()
            : this(new Repository<AirCraft>())
        {

        }
        public AirCraftsController(IRepository<AirCraft> aircrafts)
        {
            this.aircrafts = aircrafts;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var aircrafts = this.aircrafts.All().Select(a => new AirCraftModel
            {
                Id = a.Id,
                Model = a.Model
            });
            return Ok(aircrafts);
        }

        [HttpPost]
        public IHttpActionResult Create(AirCraftModel aircraft)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAirCraft = new AirCraft
            {
                Model = aircraft.Model
            };

            this.aircrafts.Add(newAirCraft);
            this.aircrafts.SaveChanges();
            return Ok(newAirCraft);
        }
    }
}
