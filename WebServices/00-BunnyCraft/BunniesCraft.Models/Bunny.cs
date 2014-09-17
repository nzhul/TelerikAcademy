namespace BunniesCraft.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bunny
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Name { get; set; }

        [Range(0, 100)]
        public double Health { get; set; }

        public int? AircraftId { get; set; }
        public virtual AirCraft Aircraft { get; set; }

        [Required]
        public ColorType Color { get; set; }

    }
}
