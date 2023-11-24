using PruebaTecnica.Models;

namespace PruebaTecnica.Service.IRepository
{
    public interface ITenisRepository
    {
        public Task<IList<Tenis>> GetTenis();
        public Task<Tenis> GetTenisById(int id);
        public Task<int> UpdateTenis(int id, Tenis Tenis);
        public Task PostTenis(Tenis Tenis);
        public Task<int> DeleteTenisById(int id);
    }
}
