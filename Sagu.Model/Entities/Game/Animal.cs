﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.Model
{
    public class Animal : Creature
    {
        public Guid AreaId { get; set; }
        public Area Area { get; set; }
        public SkillAttribute Attrbiutes { get; set; }
    }
}
