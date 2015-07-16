using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.Model;

namespace Sagu.DAL.Mappings
{
    public class AnimalMapping : EntityTypeConfiguration<Animal>
    {
        public AnimalMapping()
        {
            HasRequired(a => a.Area).WithMany(a => a.Animals).HasForeignKey(a => a.AreaId);
        }
    }

    public class MonsterMapping : EntityTypeConfiguration<Monster>
    {
        public MonsterMapping()
        {
            HasRequired(m => m.Area).WithMany(a => a.Monsters).HasForeignKey(m => m.AreaId);
        }
    }
}
