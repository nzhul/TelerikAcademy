using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Vote
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string VotedById { get; set; }
        
        public virtual ApplicationUser VotedBy { get; set; }

        [Required]
        public int LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
