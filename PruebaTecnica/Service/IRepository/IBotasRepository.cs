using PruebaTecnica.Models;

namespace PruebaTecnica.Service.IRepository
{
    public interface IBotasRepository
    {
        public Task<IList<Botas>> GetBotas();
        public Task<Botas> GetBotaById(int id);
        public Task<int> UpdateBota(int id, Botas bota);
        public Task PostBotas(Botas Botas);
        public Task<int> DeleteBotaById(int id);
    }
}
