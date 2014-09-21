using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Detach(T entity);
        void SaveChanges();
    }
}
