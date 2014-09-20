using BunniesCraft.Data.Repositories;
using BunniesCraft.Models;
using System.Web.Http;
using System.Linq;
using BunniesCraft.Services.Models;

namespace BunniesCraft.Services.Controllers
{
    public class BunniesController : ApiController
    {
        private IRepository<Bunny> bunnies;

        public BunniesController()
            : this(new Repository<Bunny>())
        {

        }

        public BunniesController(IRepository<Bunny> bunnies)
        {
            this.bunnies = bunnies;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var bunnies = this.bunnies.All().Select(b => new BunnyModel
            {
                Id = b.Id,
                Name = b.Name,
                Health = b.Health,
                Color = b.Color
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

                this.bunnies.Add(newBunny);
                this.bunnies.SaveChanges();

                bunny.Id = newBunny.Id;
                return Ok(newBunny);
            }
        }
    }
}
