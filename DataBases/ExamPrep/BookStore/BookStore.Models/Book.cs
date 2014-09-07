namespace BookStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Book
    {
        private ICollection<Review> reviews;
        private ICollection<Author> authors;

        public Book()
        {
            this.reviews = new HashSet<Review>();
            this.authors = new HashSet<Author>();
        }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [StringLength(13, MinimumLength = 13)]
        public string ISBN { get; set; }

        public decimal? Price { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Review> Reviews 
        { 
            get { return this.reviews; } 
            set { this.reviews = value; } 
        }

        public virtual ICollection<Author> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }
    }
}
