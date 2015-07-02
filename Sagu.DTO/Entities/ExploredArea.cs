using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.DTO
{
    public class ExploredArea
    {
        public Guid Id { get; set; }
        public Area Area { get; set; }
        public double AmountExplored { get; set; }
    }
}
