using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.DAL;
using System.Data.Entity;

namespace Sagu.Services
{
    public class AreaService
    {
        public IEnumerable<DTO.Area> GetAreas()
        {
            using (var context = new SaguContext())
            {
                return GetAreaObjectMaps().Select(a => a.AsDTO());
            }
        }

        public DTO.Area GetArea(Guid id)
        {
            using (var context = new SaguContext())
            {
                return GetAreaObjectMaps().FirstOrDefault(a => a.Id == id).Get(a => a.AsDTO());
            }
        }

        private IEnumerable<Sagu.Model.Area> GetAreaObjectMaps()
        {
            using (var context = new SaguContext())
            {
                return context.Areas
                                .Include(a => a.Image)
                                .Include(a => a.Animals)
                                .Include(a => a.Monsters)
                                .ToList();
            }
        }

        public DTO.Area CreateArea(DTO.Area area)
        {
            using (var context = new SaguContext())
            {
                var newArea = context.Areas.Add(area.AsEntity());
                context.SaveChanges();

                return newArea.AsDTO();
            }
        }

        public DTO.Area UpdateArea(DTO.Area area)
        {
            using (var context = new SaguContext())
            {
                var areaToUpdate = context.Areas.Include(a => a.Image).FirstOrDefault(a => a.Id == area.Id);

                if (areaToUpdate == null)
                    throw new KeyNotFoundException();

                areaToUpdate.Image = area.Image.Get(i => i.AsEntity()) ?? areaToUpdate.Image;
                context.Entry(areaToUpdate).CurrentValues.SetValues(area);

                context.SaveChanges();

                return area;
            }
        }

        public void DeleteArea(Guid id)
        {
            using (var context = new SaguContext())
            {
                var areaToRemove = context.Areas.Find(id);

                if (areaToRemove == null)
                    throw new KeyNotFoundException();

                context.Areas.Remove(areaToRemove);
                context.SaveChanges();
            }
        }
    }
}
