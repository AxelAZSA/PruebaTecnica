using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;
using PruebaTecnica.Service.IRepository;

namespace PruebaTecnica.Service.Repositorios
{
    public class BotasRepository : IBotasRepository
    {
        private DbIContext _context;

        public BotasRepository(DbIContext context)
        {
            _context = context;
        }
        public async Task<int> DeleteBotaById(int id)
        {
            var botaDb = await _context.Botas.FindAsync(id);

            _context.Entry(botaDb).State = EntityState.Deleted;

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

        public async Task<Botas> GetBotaById(int id)
        {
            return await _context.Botas.FirstOrDefaultAsync(b=>b.id==id);
        }

        public async Task<IList<Botas>> GetBotas()
        {
            return await _context.Botas.ToListAsync();
        }

        public async Task<int> UpdateBota(int id, Botas bota)
        {
            var botaDb = await _context.Botas.FindAsync(id);
            botaDb = bota;

            _context.Entry(botaDb).State = EntityState.Modified;

            try
            {
                await Save();
                return id;
            }catch (Exception ex) 
            {
                return -1;
            }
        }
        public async Task PostBotas(Botas Botas)
        {
            await _context.Botas.AddAsync(Botas);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
