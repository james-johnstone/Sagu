using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.Model;

namespace Sagu.DAL.Mappings
{
    public class ExplorerMapping : EntityTypeConfiguration<Explorer>
    {
        public ExplorerMapping()
        {
            Property(e => e.Level).IsRequired();
            Property(e => e.Name).IsRequired();
            Property(e => e.Name).HasMaxLength(20);
        }
    }
}
