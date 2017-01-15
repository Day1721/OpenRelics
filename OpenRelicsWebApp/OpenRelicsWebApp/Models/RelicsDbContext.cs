using System.Data.Entity;

namespace OpenRelicsWebApp.Models
{
    class RelicsDbContext : DbContext
    {
        public DbSet<Relic> Relics { get; set; }

        public DbSet<Connection> Connections { get; set; }
    }
}
