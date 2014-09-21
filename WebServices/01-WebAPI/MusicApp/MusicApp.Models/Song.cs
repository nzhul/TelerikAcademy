namespace MusicApp.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Song
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

        public int? ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int? AlbumId { get; set; }

        public virtual Artist Album { get; set; }
    }
}
