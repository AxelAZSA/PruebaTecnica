using PruebaTecnica.Interfaces;

namespace PruebaTecnica.Models
{
    public class Botas : ICalzado
    {
        public int id { get; set; }
        public string modelo { get; set; }
        public decimal precio { get; set; }
        public int talla { get; set; }
        public string marca { get; set; }
    }
}
