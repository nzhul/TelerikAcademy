using MusicApp.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MusicApp.Data
{
    public interface IMusicAppDbContext
    {
        IDbSet<Artist> Artists { get; set; }
        IDbSet<Album> Albums { get; set; }
        IDbSet<Song> Songs { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
