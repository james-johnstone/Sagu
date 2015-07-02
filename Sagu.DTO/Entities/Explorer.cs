using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.DTO
{
    public class Explorer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public  IEnumerable<ExploredArea> ExploredAreas { get; set; }
    }
}
