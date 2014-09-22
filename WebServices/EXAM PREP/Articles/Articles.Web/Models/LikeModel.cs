using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Articles.Web.Models
{
    public class LikeModel
    {
        public static Expression<Func<Like, LikeModel>> FromLike
        {
            get
            {
                return l => new LikeModel
                {
                    AuthorName = l.Author.UserName,
                    Id = l.Id
                };
            }
        }

        public int Id { get; set; }
        public string AuthorName { get; set; }


    }
}