using Articles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Articles.Web.Models
{
    public class ArticleModel
    {
        public ArticleModel()
        {
            this.Tags = new HashSet<TagModel>();
        }

        public static Expression<Func<Article, ArticleModel>> FromArticle
        {
            get
            {
                return a => new ArticleModel
                {
                    Id = a.Id,
                    AuthorName = a.Author.UserName,
                    Title = a.Title,
                    Content = a.Content,
                    Category = a.Category.Name,
                    DateCreated = a.DateCreated,
                    Tags = a.Tags.AsQueryable().Select(TagModel.FromTag)
                };
            }
        }

        public int Id { get; set; }

        public string AuthorName { get; set; }

        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Category { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<TagModel> Tags { get; set; }
    }
}