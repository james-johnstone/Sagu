using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.DAL;
using System.Data.Entity;

namespace Sagu.Services
{
    public class ExploredAreaService
    {
        public IEnumerable<DTO.ExploredArea> GetExploredAreas(Guid explorerId)
        {
            using (var context = new SaguContext())
            {
                return context.ExploredAreas.Include(a => a.Area).Where(a => a.ExplorerId == explorerId).ToList().Select(a => a.AsDTO());
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
                context.ExploredAreas.Add(area.AsEntity());
                context.SaveChanges();

                return area;
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

                return area;
            }
        }
    }
}
