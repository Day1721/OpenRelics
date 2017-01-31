using System.Data.Entity;

namespace OpenRelicsWebApp.Models
{
    class RelicsDbContext : DbContext
    {
        private class DbInitializer : IDatabaseInitializer<RelicsDbContext>
        {
            public void InitializeDatabase(RelicsDbContext context)
            {
                
            }
        }

        static RelicsDbContext()
        {
            Database.SetInitializer(new DbInitializer());
            using (var db = new RelicsDbContext())
                db.Database.Initialize(false);
        }

        public DbSet<Relic> Relics { get; set; }

        public DbSet<Connection> Connections { get; set; }
    }
}
