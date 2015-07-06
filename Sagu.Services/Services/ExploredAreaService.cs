using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.DAL;

namespace Sagu.Services
{
    public class ExploredAreaService
    {
        public IEnumerable<DTO.ExploredArea> GetExploredAreas(Guid explorerId)
        {
            using (var context = new SaguContext())
            {
                var explorer = context.Explorers.Find(explorerId);

                return explorer.ExploredAreas.Select(a => a.AsDTO());
            }
        }

        public DTO.ExploredArea GetExploredArea(Guid id)
        {
            using (var context = new SaguContext())
            {
                return context.ExploredAreas.Find(id).Get(a => a.AsDTO());
            }
        }

        public DTO.ExploredArea CreateExploredArea(DTO.ExploredArea area)
        {
            using (var context = new SaguContext())
            {
                var newArea = context.ExploredAreas.Add(area.AsEntity());
                context.SaveChanges();

                return newArea.AsDTO();
            }
        }

        public DTO.ExploredArea UpdateExploredArea(DTO.ExploredArea area)
        {
            using (var context = new SaguContext())
            {
                var areaToUpdate = context.ExploredAreas.Find(area.Id);

                if (areaToUpdate == null)
                    throw new KeyNotFoundException();

                areaToUpdate.AmountExplored = area.AmountExplored;
                context.SaveChanges();

                return areaToUpdate.AsDTO();
            }
        }
    }
}
