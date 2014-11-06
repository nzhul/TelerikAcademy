using Application.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Controllers
{
    public class HomeController : BaseController
    {
        // This request is cached for 1 hour!!!
        //[OutputCache(Duration=60*60)]
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageLaptops"] == null)
            {
                var listOfLaptops = this.Data.Laptops.All()
                    .OrderByDescending(x => x.Votes.Count())
                    .Take(8)
                    .Select(x => new HomePageLaptopViewModel
                    {
                        Id = x.ID,
                        Manufacturer = x.Manufacturer.Name,
                        ImageUrl = x.ImageUrl,
                        Model = x.Model,
                        Price = x.Price
                    });
                this.HttpContext.Cache.Add("HomePageLaptops", listOfLaptops.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }



            return View(this.HttpContext.Cache["HomePageLaptops"]);
        }
    }
}