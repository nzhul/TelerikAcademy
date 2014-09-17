using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunniesCraft.Models
{
    public class AirCraft
    {
        private ICollection<Bunny> bunnies;

        public AirCraft()
        {
            this.bunnies = new HashSet<Bunny>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Model { get; set; }

        public virtual ICollection<Bunny> Bunnies
        {
            get { return this.bunnies; }
            set { this.bunnies = value; }
        }
        
    }
}
