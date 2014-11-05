using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Laptop
    {
        private ICollection<Comment> comments { get; set; }
        private ICollection<Vote> votes { get; set; }
        public Laptop()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        [Key]
        public int ID { get; set; }
        public int ManufacturerId { get; set; }

        [Required]
        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Measured in inches
        /// </summary>
        [Required]
        public double MonitorSize { get; set; }

        /// <summary>
        /// Measured in GB
        /// </summary>
        [Required]
        public int HardDiskSize { get; set; }

        /// <summary>
        /// Measured in GB
        /// </summary>
        [Required]
        public int RamMemorySize { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Measured in Chinese Yuan
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Measured in kg
        /// </summary>
        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

    }
}
