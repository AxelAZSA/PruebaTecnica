using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;
using PruebaTecnica.Service.IRepository;

namespace PruebaTecnica.Service.Repositorios
{
    public class ZapatosRepository : IZapatosRepository
    {
        private DbIContext _context;

        public ZapatosRepository(DbIContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteZapatoById(int id)
        {
            var ZapatoDb = await _context.Zapatos.FindAsync(id);

            _context.Entry(ZapatoDb).State = EntityState.Deleted;

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

        public async Task<Zapatos> GetZapatoById(int id)
        {
            return await _context.Zapatos.FirstOrDefaultAsync(b => b.id == id);
        }

        public async Task<IList<Zapatos>> GetZapatos()
        {
            return await _context.Zapatos.ToListAsync();
        }

        public async Task<int> UpdateZapato(int id, Zapatos Zapato)
        {
            var ZapatoDb = await _context.Zapatos.FindAsync(id);
            ZapatoDb = Zapato;

            _context.Entry(ZapatoDb).State = EntityState.Modified;

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

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task PostZapato(Zapatos Zapato)
        {
            await _context.Zapatos.AddAsync(Zapato);
            await Save();
        }
    }
}
