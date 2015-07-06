using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.DTO
{
    public class ExploredArea
    {
        public Guid Id { get; set; }
        [Required]
        public Area Area { get; set; }
        public Guid ExplorerId { get; set; }
        [Range(0.0,100)]
        public double AmountExplored { get; set; }
    }
}
