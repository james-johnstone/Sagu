﻿using System;
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
