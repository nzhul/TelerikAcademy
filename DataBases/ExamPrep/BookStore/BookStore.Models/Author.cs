namespace BookStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Author
    {
        private ICollection<Review> reviews;
        private ICollection<Book> books;

        public Author()
        {
            this.reviews = new HashSet<Review>();
            this.books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Review> Reviews 
        { 
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
