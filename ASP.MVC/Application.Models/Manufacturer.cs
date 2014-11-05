using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Manufacturer
    {
        private ICollection<Laptop> laptops { get; set; }
        public Manufacturer()
        {
            this.laptops = new HashSet<Laptop>();
        }
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Laptop> Laptops
        { 
            get { return this.laptops; } 
            set { this.laptops = value; } 
        }
        
    }
}
