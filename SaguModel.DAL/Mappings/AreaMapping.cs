using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaguModel.DAL.Mappings
{
    public class AreaMapping : EntityTypeConfiguration<Area>
    {
        public AreaMapping()
        {
            Property(a => a.Name).HasMaxLength(20);
        }
    }
}
