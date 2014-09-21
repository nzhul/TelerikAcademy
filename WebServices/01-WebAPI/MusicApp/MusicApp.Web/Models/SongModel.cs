using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Web.Models
{
    public class SongModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int Length { get; set; }

        public string Producer { get; set; }
    }
}