using Articles.Data;
using Articles.Models;
using Articles.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Articles.Web.Controllers
{
    public class CommentsController : BaseApiController
    {

        public CommentsController()
            : this(new ArticlesData(new ApplicationDbContext()))
        {

        }

        public CommentsController(IArticlesData data)
            : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(int id, CommentModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var comment = new Comment
            {
                ArticleId = id,
                AuthorId = userId,
                Content = model.Content,
                DateCreated = DateTime.Now
            };

            this.data.Comments.Add(comment);
            this.data.SaveChanges();
            return Ok();
        }
    }
}
