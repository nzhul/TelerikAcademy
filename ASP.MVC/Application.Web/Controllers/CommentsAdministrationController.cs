using Application.Web.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Controllers
{
    public class CommentsAdministrationController : BaseController
    {
        // GET: CommentsAdministration
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadAllComments([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Comments.All().Select(x => new CommentViewModel
            {
                Id = x.ID,
                Content = x.Content,
                AuthorUserName = x.Author.UserName
            });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateComment([DataSourceRequest] DataSourceRequest request, CommentViewModel comment)
        {
            var commentDb = this.Data.Comments.Find(comment.Id);

            commentDb.Content = comment.Content;
            this.Data.SaveChanges();

            return Json(new[] {comment}.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyComment([DataSourceRequest] DataSourceRequest request, CommentViewModel comment)
        {
            this.Data.Comments.Delete(comment.Id);
            this.Data.SaveChanges();
            return Json(new[] { comment }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}