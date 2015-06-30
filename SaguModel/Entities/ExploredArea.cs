using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaguModel
{
    public class ExploredArea
    {
        public Guid ID { get; set; }
        public Guid ExplorerId { get; set; }
        public Explorer Explorer { get; set; }
        public Guid AreaId { get; set; }
        public Area Area { get; set; }
        public double AmountExplored { get; set; }
    }
}
