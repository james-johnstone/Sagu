using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.Model
{
    public class Explorer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExploredArea> ExploredAreas { get; set; }


        public Explorer()
        {
            ExploredAreas = new List<ExploredArea>();
        }
    }
}
