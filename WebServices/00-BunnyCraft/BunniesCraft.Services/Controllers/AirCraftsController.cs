namespace BunniesCraft.Services.Controllers
{
    using System.Web.Http;
    using System.Linq;
    using BunniesCraft.Models;
    using BunniesCraft.Services.Models;
    using BunniesCraft.Data;
    public class AirCraftsController : ApiController
    {
        private IBunniesData data;

        public AirCraftsController()
            : this(new BunniesData())
        {

        }
        public AirCraftsController(IBunniesData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var aircrafts = this.data.AirCrafts.All().Select(a => new AirCraftModel
            {
                Id = a.Id,
                Model = a.Model
            });
            return Ok(aircrafts);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var airCraft = this.data.AirCrafts.All().FirstOrDefault(a=>a.Id == id);
            if (airCraft == null)
            {
                return BadRequest("AirCraft does not exists - invalid ID");
            }
            return Ok(airCraft);
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

            this.data.AirCrafts.Add(newAirCraft);
            this.data.AirCrafts.SaveChanges();

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

            var existingAirCraft = this.data.AirCrafts.All().FirstOrDefault(a => a.Id == id);
            if (existingAirCraft == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            existingAirCraft.Model = airCraft.Model;
            this.data.AirCrafts.SaveChanges();

            return Ok(airCraft);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAirCraft = this.data.AirCrafts.All().FirstOrDefault(a => a.Id == id);
            if (existingAirCraft == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            this.data.AirCrafts.Delete(existingAirCraft);
            this.data.AirCrafts.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddBunny(int id, int bunnyId)
        {
            var theAirCraft = this.data.AirCrafts.All().FirstOrDefault(a => a.Id == id);
            if (theAirCraft == null)
            {
                BadRequest("Such aircraft does not exists!");
            }

            var theBunny = this.data.Bunnies.All().FirstOrDefault(b => b.Id == bunnyId);
            if (theBunny == null)
            {
                return BadRequest("Such bunny does not exists! - invalid ID");
            }

            theAirCraft.Bunnies.Add(theBunny);
            theBunny.AircraftId = id;
            this.data.Bunnies.SaveChanges();
            
            return Ok("Success");
        }
    }
}
