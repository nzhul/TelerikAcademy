using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicApp.Web.Models
{
    public class ArtistModel
    {

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}