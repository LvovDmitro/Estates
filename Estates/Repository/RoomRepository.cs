using Estates.Data;
using Estates.Interfaces;
using Estates.Models;
using Microsoft.EntityFrameworkCore;

namespace Estates.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Room rooms)
        {
            _context.Add(rooms);
            return Save();
        }

        public bool Delete(Room rooms)
        {
            _context.Remove(rooms);
            return Save();
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllRoomsByCity(string city)
        {
            return await _context.Rooms.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _context.Rooms.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<Room> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Rooms.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Room rooms)
        {
            _context.Update(rooms);
            return Save();
        }


    }
}
