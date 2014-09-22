namespace Articles.Data
{
    using Articles.Data.Repositories;
    using Articles.Models;
    public interface IArticlesData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Article> Articles { get; }
        IRepository<Category> Categories { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Like> Likes { get; }
        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
