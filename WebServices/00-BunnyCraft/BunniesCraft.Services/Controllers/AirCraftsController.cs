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
        private IRepository<Bunny> bunnies;

        public AirCraftsController()
            : this(new Repository<AirCraft>(), new Repository<Bunny>())
        {

        }
        public AirCraftsController(IRepository<AirCraft> airCrafts, IRepository<Bunny> bunnies)
        {
            this.aircrafts = airCrafts;
            this.bunnies = bunnies;
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
        public IHttpActionResult Create(AirCraftModel airCraft)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAirCraft = new AirCraft
            {
                Model = airCraft.Model
            };

            this.aircrafts.Add(newAirCraft);
            this.aircrafts.SaveChanges();

            airCraft.Id = newAirCraft.Id;
            return Ok(newAirCraft);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AirCraftModel airCraft)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAirCraft = this.aircrafts.All().FirstOrDefault(a => a.Id == id);
            if (existingAirCraft == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            existingAirCraft.Model = airCraft.Model;
            this.aircrafts.SaveChanges();

            return Ok(airCraft);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAirCraft = this.aircrafts.All().FirstOrDefault(a => a.Id == id);
            if (existingAirCraft == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            this.aircrafts.Delete(existingAirCraft);
            this.aircrafts.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddBunny(int id, int bunnyId)
        {
            var theAirCraft = this.aircrafts.All().FirstOrDefault(a => a.Id == id);
            if (theAirCraft == null)
            {
                return BadRequest("Such airCraft does not exists! - invalid ID");
            }

            var theBunny = this.bunnies.All().FirstOrDefault(b => b.Id == id);
            if (theBunny == null)
            {
                return BadRequest("Such bunny does not exists! - invalid ID");
            }

            //theAirCraft.Bunnies.Add(theBunny);
            theBunny.AircraftId = id;
            this.bunnies.SaveChanges();
            
            return Ok();
        }
    }
}
