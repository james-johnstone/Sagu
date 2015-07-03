using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.Model;

namespace Sagu.DAL.Mappings
{
    public class AreaImageMapping : EntityTypeConfiguration<AreaImage>
    {
        public AreaImageMapping()
        {
            HasRequired(a => a.Area).WithOptional(a => a.Image).WillCascadeOnDelete(true);
            Property(a => a.FileName).IsRequired();
            Property(a => a.FileName).HasMaxLength(255);
        }
    }
}
