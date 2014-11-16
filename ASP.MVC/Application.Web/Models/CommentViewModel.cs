using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string AuthorUserName { get; set; }
        public string Content { get; set; }
    }
}