﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.Model
{
    public class AreaImage
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Area Area { get; set; }
    }
}
