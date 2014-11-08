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
                    Weight = x.Weight
                }).FirstOrDefault();
            return View(viewModel);
        }

        public ActionResult KendoList()
        {
            return View();
        }

        public JsonResult GetLaptops([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllLaptops().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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