using System.Web.Http;
using System.Linq;
using BunniesCraft.Services.Models;
using BunniesCraft.Data;
using BunniesCraft.Models;

namespace BunniesCraft.Services.Controllers
{
    public class BunniesController : ApiController
    {
        private IBunniesData data;

        public BunniesController()
            : this(new BunniesData())
        {

        }
        public BunniesController(IBunniesData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var bunnies = this.data.Bunnies.All().Select(b => new BunnyModel
            {
                Id = b.Id,
                Name = b.Name,
                Health = b.Health,
                Color = b.Color,
                AirCraftId = b.AircraftId
            });
            return Ok(bunnies);
        }

        [HttpPut]
        public IHttpActionResult Create(BunnyModel bunny)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var newBunny = new Bunny
                {
                    Name = bunny.Name,
                    Health = bunny.Health,
                    Color = bunny.Color,
                };

                this.data.Bunnies.Add(newBunny);
                this.data.Bunnies.SaveChanges();

                bunny.Id = newBunny.Id;
                return Ok(newBunny);
            }
        }

        [HttpGet]
        public IHttpActionResult GetByAirCraftId(int id)
        {
            var bunniesByAirCraftId = this.data.Bunnies.All().Where(b => b.AircraftId == id)
                .Select(b => new BunnyModel 
                {
                    Id = b.Id,
                    Name = b.Name,
                    Health = b.Health,
                    Color = b.Color,
                    AirCraftId = b.AircraftId
                });
            return Ok(bunniesByAirCraftId);
        }
    }
}
