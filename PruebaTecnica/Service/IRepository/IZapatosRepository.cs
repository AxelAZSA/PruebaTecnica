using PruebaTecnica.Models;

namespace PruebaTecnica.Service.IRepository
{
    public interface IZapatosRepository
    {
        public Task<IList<Zapatos>> GetZapatos();
        public Task<Zapatos> GetZapatoById(int id);
        public Task PostZapato(Zapatos Zapato);
        public Task<int> UpdateZapato(int id, Zapatos Zapato);
        public Task<int> DeleteZapatoById(int id);
    }
}
