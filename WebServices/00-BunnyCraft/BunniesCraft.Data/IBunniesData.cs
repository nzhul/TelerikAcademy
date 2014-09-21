using BunniesCraft.Data.Repositories;
using BunniesCraft.Models;
namespace BunniesCraft.Data
{
    public interface IBunniesData
    {

        IRepository<Bunny> Bunnies { get; }

        IRepository<AirCraft> AirCrafts { get; }

        void SaveChanges();
    }
}
