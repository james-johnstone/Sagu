using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaguModel.DAL.Mappings
{
    public class ExplorerMapping : EntityTypeConfiguration<Explorer>
    {
        public ExplorerMapping()
        {
            Property(e => e.Name).HasMaxLength(20);
        }
    }
}
