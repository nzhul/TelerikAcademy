using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Articles.Web.Models
{
    public class CommentModel
    {
        public static Expression<Func<Comment, CommentModel>> FromComment
        {
            get
            {
                return c => new CommentModel
                {
                    AuthorName = c.Author.UserName,
                    Content = c.Content,
                    DateCreated = c.DateCreated,
                    Id = c.Id,
                    ArticleId = c.ArticleId
                };
            }
        }

        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }

        public int ArticleId { get; set; }

    }
}