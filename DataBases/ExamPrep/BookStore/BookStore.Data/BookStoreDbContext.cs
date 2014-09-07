namespace BookStore.Data
{
    using BookStore.Data.Migrations;
    using BookStore.Models;
    using System.Data.Entity;

    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
            : base("BookStoreConnection") 
        {
            Database.SetInitializer( new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
        }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Review> Reviews { get; set; }
        public IDbSet<Author> Authors { get; set; }

    }
}
