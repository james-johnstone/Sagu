using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.Model;

namespace Sagu.DAL.Mappings
{
    public class AreaMapping : EntityTypeConfiguration<Area>
    {
        public AreaMapping()
        {
            Property(a => a.Name).IsRequired();
            Property(a => a.Name).HasMaxLength(20);
        }
    }
}
