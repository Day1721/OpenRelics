using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFiller.DbClasses
{
    class RelicsDbContext : DbContext
    {
        private class DbInitializer : DropCreateDatabaseAlways<RelicsDbContext>
        { }

        static RelicsDbContext()
        {
            Database.SetInitializer<RelicsDbContext>(new DbInitializer());
            using (var db = new RelicsDbContext())
                db.Database.Initialize(false);
        }

        public DbSet<Relic> Relics { get; set; }

        public DbSet<Connection> Connections { get; set; }
    }
}
