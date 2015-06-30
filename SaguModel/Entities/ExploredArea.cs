using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaguModel
{
    public class ExploredArea
    {
        public Guid Id { get; set; }
        public Guid ExplorerId { get; set; }
        public Guid AreaId { get; set; }

        public Explorer Explorer { get; set; }
        public Area Area { get; set; }
        public double AmountExplored { get; set; }
    }
}
