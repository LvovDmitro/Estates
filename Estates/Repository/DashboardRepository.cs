using Estates.Data;
using Estates.Interfaces;
using Estates.Models;
using Microsoft.EntityFrameworkCore;

namespace Estates.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)  
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Room>> GettAllUserRooms()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userRooms = _context.Rooms.Where(r => r.AppUserId == curUser);
            return userRooms.ToList();
        }

        public async Task<List<Flat>> GettAllUserFlats()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userFlats = _context.Flats.Where(r => r.AppUserId == curUser);
            return userFlats.ToList();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
