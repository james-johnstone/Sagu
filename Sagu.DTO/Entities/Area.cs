﻿using System;
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
        [Required]
        public int Order { get; set; }
        public AreaImage Image { get; set; }
        public IEnumerable<Animal> Animals { get; set; }
        public IEnumerable<Monster> Monsters { get; set; }
    }
}
