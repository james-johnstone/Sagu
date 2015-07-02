using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.Model;

namespace Sagu.DAL.Mappings
{
    public class ExplorerAreaMapping : EntityTypeConfiguration<ExploredArea>
    {
        public ExplorerAreaMapping()
        {
            HasRequired(a => a.Area);
            HasRequired(a => a.Explorer).WithMany(e => e.ExploredAreas);
        }
    }
}
