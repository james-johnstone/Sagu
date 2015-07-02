using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sagu.DTO
{
    public class Explorer
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public  IEnumerable<ExploredArea> ExploredAreas { get; set; }
    }
}
