using Estates.Models;

namespace Estates.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAll();
        Task<Room> GetByIdAsync(int id);
        Task<Room> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Room>> GetAllRoomsByCity(string city);
        bool Add(Room rooms);
        bool Update(Room rooms);
        bool Delete(Room rooms);
        bool Save();
    }
}
