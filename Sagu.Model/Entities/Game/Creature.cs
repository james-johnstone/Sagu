using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.Model
{
    public abstract class Creature
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Kana { get; set; }
        public bool IsUnique { get; set; }
        public double EncounterRate { get; set; }
    }
}
