using System;
using System.ComponentModel.DataAnnotations;

namespace Cars.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        public int TransmisionType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
