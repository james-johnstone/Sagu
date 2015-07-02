using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.Services
{
    public static class ModelExtensions
    {
        public static Sagu.DTO.Explorer AsDTO(this Sagu.Model.Explorer explorer)
        {
            return new DTO.Explorer()
            {
                Id = explorer.Id,
                Name = explorer.Name,
                ExploredAreas = explorer.ExploredAreas.Select(e => e.AsDTO())
            };
        }

        public static Sagu.DTO.ExploredArea AsDTO(this Sagu.Model.ExploredArea exploredArea)
        {
            return new DTO.ExploredArea()
            {
                Id = exploredArea.Id,
                AmountExplored = exploredArea.AmountExplored,
                Area = exploredArea.Area.AsDTO()
            };
        }

        public static Sagu.DTO.Area AsDTO(this Sagu.Model.Area area)
        {
            return new DTO.Area()
            {
                Id = area.Id,
                Name = area.Name,
                Size = area.Size
            };
        }

        public static Sagu.Model.Explorer AsEntity(this Sagu.DTO.Explorer explorer)
        {
            return new Sagu.Model.Explorer()
            {
                Id = explorer.Id,
                Name = explorer.Name
            };
        }
    }
}
