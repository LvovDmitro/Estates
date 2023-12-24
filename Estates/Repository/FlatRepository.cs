using Estates.Data;
using Estates.Interfaces;
using Estates.Models;
using Microsoft.EntityFrameworkCore;

namespace Estates.Repository
{
    public class FlatRepository : IFlatRepository
    {
        private readonly ApplicationDbContext _context;

        public FlatRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Flat flat)
        {
            _context.Add(flat);
            return Save();
        }

        public bool Delete(Flat flat)
        {
            _context.Remove(flat);
            return Save();
        }

        public async Task<IEnumerable<Flat>> GetAll()
        {
            return await _context.Flats.ToListAsync();
        }

        public async Task<Flat> GetByIdAsync(int id)
        {
            return await _context.Flats.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Flat> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Flats.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Flat>> GetFlatByCity(string city)
        {
            return await _context.Flats.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Flat flat)
        {
            _context.Update(flat);
            return Save();
        }
    }
}
