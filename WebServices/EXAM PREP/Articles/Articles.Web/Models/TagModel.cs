using Articles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Articles.Web.Models
{
    public class TagModel
    {
        public static Expression<Func<Tag, TagModel>> FromTag
        {
            get
            {
                return t => new TagModel
                {
                    Id = t.Id,
                    Name = t.Name
                };
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
