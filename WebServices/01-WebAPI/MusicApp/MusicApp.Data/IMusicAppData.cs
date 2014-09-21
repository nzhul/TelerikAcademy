using MusicApp.Data.Repositories;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Data
{
    public interface IMusicAppData
    {

        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        void SaveChanges();
    }
}
