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
        
        public string VotedById { get; set; }

        [Required]
        public virtual ApplicationUser VotedBy { get; set; }
        
        public int LaptopId { get; set; }

        [Required]
        public virtual Laptop Laptop { get; set; }
    }
}
