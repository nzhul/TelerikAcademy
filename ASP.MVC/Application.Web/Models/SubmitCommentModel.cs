using Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Web.Models
{
    public class SubmitCommentModel
    {
        [Required]
        [ShouldNotContainEmail]
        public string Comment { get; set; }

        [Required]
        public int LaptopId { get; set; }
    }
}