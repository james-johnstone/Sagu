using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.Model
{
    public class Area
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Size { get; set; }
        public AreaImage Image { get; set; }
    }
}
