﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.DAL;

namespace Sagu.Services
{
    public class AreaService
    {
        public IEnumerable<DTO.Area> GetAreas()
        {
            using (var context = new SaguContext())
            {
                return context.Areas.ToList().Select(a => a.AsDTO());
            }
        }

        public DTO.Area GetArea(Guid id)
        {
            using (var context = new SaguContext())
            {
                return context.Areas.Find(id).Get(a => a.AsDTO());
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
                var areaToUpdate = context.Areas.Find(area.Id);

                if (areaToUpdate == null)
                    throw new KeyNotFoundException();

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
