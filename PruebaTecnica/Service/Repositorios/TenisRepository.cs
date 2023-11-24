using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;
using PruebaTecnica.Service.IRepository;

namespace PruebaTecnica.Service.Repositorios
{
    public class TenisRepository : ITenisRepository
    {
        private DbIContext _context;

        public TenisRepository(DbIContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteTenisById(int id)
        {
            var TenisDb = await _context.Tenis.FindAsync(id);

            _context.Entry(TenisDb).State = EntityState.Deleted;

            try
            {
                await Save();
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public  async Task<IList<Tenis>> GetTenis()
        {
            return await _context.Tenis.ToListAsync();
        }

        public async Task<Tenis> GetTenisById(int id)
        {
            return await _context.Tenis.FirstOrDefaultAsync(b => b.id == id);
        }

        public async Task<int> UpdateTenis(int id, Tenis Tenis)
        {
            var TenisDb = await _context.Tenis.FindAsync(id);
            TenisDb = Tenis;

            _context.Entry(TenisDb).State = EntityState.Modified;

            try
            {
                await Save();
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public async Task PostTenis(Tenis Tenis)
        {
            await _context.Tenis.AddAsync(Tenis);
            await Save();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
    
}
