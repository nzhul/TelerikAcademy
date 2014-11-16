using Application.Models;
using Application.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Application.Web.Controllers
{
    public class LaptopsController : BaseController
    {
        const int PageSize = 5;
        private IQueryable<LaptopViewModel> GetAllLaptops()
        {
            var data = this.Data.Laptops.All()
                .Select(x => new LaptopViewModel
                {
                    Id = x.ID,
                    ImageUrl = x.ImageUrl,
                    Manufacturer = x.Manufacturer.Name,
                    Model = x.Model,
                    Price = x.Price
                }).OrderBy(x => x.Id);

            return data;
        }
        public ActionResult Details(int id)
        {
            var userId = this.User.Identity.GetUserId();

            var viewModel = this.Data.Laptops.All()
                .Where(x => x.ID == id)
                .Select(x => new LaptopDetailsViewModel
                {
                    Id = x.ID,
                    AdditionalParts = x.AdditionalParts,
                    Comments = x.Comments.Select(c => new CommentViewModel { AuthorUserName = c.Author.UserName, Content = c.Content }),
                    Description = x.Description,
                    HardDiskSize = x.HardDiskSize,
                    ImageUrl = x.ImageUrl,
                    ManufacturerName = x.Manufacturer.Name,
                    Model = x.Model,
                    MonitorSize = x.MonitorSize,
                    Price = x.Price,
                    RamMemorySize = x.RamMemorySize,
                    Weight = x.Weight,
                    VotesCount = x.Votes.Count(),
                    UserCanVote = !x.Votes.Any(v => v.VotedById == userId)
                }).FirstOrDefault();

            return View(viewModel);
        }

        public ActionResult Vote(int id)
        {
            var userId = this.User.Identity.GetUserId();
            var canVote = !this.Data.Votes.All().Any(x => x.LaptopId == id && x.VotedById == userId);
            if (canVote)
            {
                this.Data.Laptops.Find(id).Votes.Add(new Vote
                {
                    LaptopId = id,
                    VotedById = userId
                });

                this.Data.SaveChanges();
            }

            var votes = this.Data.Laptops.Find(id).Votes.Count();

            return Content(votes.ToString());
        }

        public ActionResult KendoList()
        {
            return View();
        }

        public JsonResult GetLaptops([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllLaptops().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLaptopModelData(string text)
        {
            var result = this.Data.Laptops
                .All()
                .Where(x => x.Model.ToLower().Contains(text.ToLower()))
                .Select(x => new  
                {
                    Model = x.Model
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(SubmitSearchModel submitModel)
        {
            var result = this.Data.Laptops.All();
            if (!String.IsNullOrEmpty(submitModel.ModelSearch))
            {
                result = result.Where(x => x.Model.ToLower().Contains(submitModel.ModelSearch.ToLower()));
            }
            if (submitModel.ManufSearch != "All")
            {
                result = result.Where(x => x.Manufacturer.Name.ToLower() == submitModel.ManufSearch);
            }
            if (submitModel.PriceSearch != 0)
            {
                result = result.Where(x => x.Price < submitModel.PriceSearch);
            }

            var endResult = result.Select(x => new LaptopViewModel
                {
                    Id = x.ID,
                    Model = x.Model,
                    Manufacturer = x.Manufacturer.Name,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price
                });

            return View(endResult);
        }

        public JsonResult GetLaptopManufacturerData()
        {
            var result = this.Data.Manufacturers.All()
                .Select(x => new 
                { 
                    ManufacturerName = x.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult List(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);
            var viewModel = GetAllLaptops().Skip((pageNumber - 1) * PageSize).Take(PageSize);

            ViewBag.Pages = Math.Ceiling((double)GetAllLaptops().Count() / PageSize);
            return View(viewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var currentUserName = this.User.Identity.GetUserName();
                var currentUserId = this.User.Identity.GetUserId();

                this.Data.Comments.Add(new Comment() {
                    AuthorId = currentUserId,
                    Content = commentModel.Comment,
                    LaptopId = commentModel.LaptopId
                });
                this.Data.SaveChanges();

                var viewModel = new CommentViewModel
                {
                    AuthorUserName = currentUserName,
                    Content = commentModel.Comment
                };
                return PartialView("_CommentPartial", viewModel);
            }
            else
            {
                // HttpResponceMessage needs using: using System.Net.Http;
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
            }
        }
    }
}