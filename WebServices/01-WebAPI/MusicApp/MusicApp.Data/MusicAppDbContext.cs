namespace MusicApp.Data
{
    using System.Data.Entity;
    using MusicApp.Models;
    using MusicApp.Data.Migrations;
    public class MusicAppDbContext: DbContext , IMusicAppDbContext
    {

        public MusicAppDbContext()
            :base("MusicAppConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicAppDbContext, Configuration>());
        }
        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
