using Articles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Articles.Web.Models
{
    public class ArticlesDetailsModel
    {
        public ArticlesDetailsModel(Article article)
        {
            this.Id = article.Id;
            this.Title = article.Title;
            this.Content = article.Content;
            this.Category = article.Category.Name;
            this.DateCreated = article.DateCreated;
            this.Tags = article.Tags.Select(t => t.Name).ToArray();
            this.Comments = article.Comments.AsQueryable().Select(CommentModel.FromComment).ToArray();
            this.Likes = article.Likes.AsQueryable().Select(LikeModel.FromLike).ToArray();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public string Category { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<string> Tags { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<LikeModel> Likes { get; set; }

    }
}