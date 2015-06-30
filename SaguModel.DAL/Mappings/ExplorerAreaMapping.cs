using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaguModel.DAL.Mappings
{
    public class ExplorerAreaMapping : EntityTypeConfiguration<ExploredArea>
    {
        public ExplorerAreaMapping()
        {
            HasRequired(a => a.Explorer).WithMany(e => e.ExploredAreas);
        }
    }
}
