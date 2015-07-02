using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.DTO
{
    public class Area
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0.0, double.MaxValue)]
        public int Size { get; set; }
    }
}
