using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Sagu.DAL.Mappings;
using Sagu.Model;
using Sagu.DAL.Migrations;

namespace Sagu.DAL
{
    public class SaguContext : DbContext
    { 
        public DbSet<Explorer> Explorers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<ExploredArea> ExploredAreas { get; set; }
        public DbSet<AreaImage> AreaImages { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Creature> Creatures { get; set; }
        public DbSet<SkillAttribute> Attributes { get; set; }

        public SaguContext()
            : base("Sagu")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SaguContext, Configuration>());

            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExplorerMapping());
            modelBuilder.Configurations.Add(new AreaMapping());
            modelBuilder.Configurations.Add(new ExplorerAreaMapping());
            modelBuilder.Configurations.Add(new AreaImageMapping());
            modelBuilder.Configurations.Add(new AnimalMapping());

            modelBuilder.Entity<Animal>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Animals");
            });

            modelBuilder.Entity<Monster>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Monsters");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
