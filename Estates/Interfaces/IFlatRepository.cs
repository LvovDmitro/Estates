using Estates.Models;

namespace Estates.Interfaces
{
    public interface IFlatRepository
    {
        Task<IEnumerable<Flat>> GetAll();
        Task<Flat> GetByIdAsync(int id);
        Task<Flat> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Flat>> GetFlatByCity(string city);
        bool Add(Flat flat);
        bool Update(Flat flat);
        bool Delete(Flat flat);
        bool Save();
    }
}
