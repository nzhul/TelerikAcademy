using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IMusicAppDbContext context;
        private IDbSet<T> set;

        public Repository()
            : this(new MusicAppDbContext())
        {

        }
        public Repository(IMusicAppDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }
        public IQueryable<T> All()
        {
            return this.set;
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }


        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
