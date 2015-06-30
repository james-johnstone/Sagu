using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using SaguModel.DAL.Mappings;

namespace SaguModel.DAL
{
    public class SaguModelContext : DbContext
    {
        public DbSet<Explorer> Explorers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<ExploredArea> ExploredAreas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExplorerMapping());
            modelBuilder.Configurations.Add(new AreaMapping());
            modelBuilder.Configurations.Add(new ExplorerAreaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
