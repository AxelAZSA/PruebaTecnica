using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data
{
    public class DbIContext : DbContext
    {
        public DbIContext(DbContextOptions<DbIContext> options): base(options) { }
        public DbSet<Tenis> Tenis => Set<Tenis>();
        public DbSet<Botas> Botas => Set<Botas>();
        public DbSet<Zapatos> Zapatos => Set<Zapatos>();

    }
}
