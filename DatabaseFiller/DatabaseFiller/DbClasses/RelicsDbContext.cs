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
        public DbSet<Relic> Relics { get; set; }

        public DbSet<Connection> Connections { get; set; }
    }
}
