using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public virtual ApplicationUser Author { get; set; }

        public int LaptopId { get; set; }

        [Required]
        public virtual Laptop Laptop { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
