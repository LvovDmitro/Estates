using Estates.Models;

namespace Estates.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Room>> GettAllUserRooms();
        Task<List<Flat>> GettAllUserFlats();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser appUser);
        bool Save();
    }
}
