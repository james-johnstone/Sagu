﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagu.Services
{
    public static class ModelExtensions
    {
        public static DTO.Explorer AsDTO(this Model.Explorer explorer)
        {
            return new DTO.Explorer()
            {
                Id = explorer.Id,
                Name = explorer.Name,
                ExploredAreas = explorer.ExploredAreas.Select(e => e.AsDTO())
            };
        }

        public static DTO.ExploredArea AsDTO(this Model.ExploredArea exploredArea)
        {
            return new DTO.ExploredArea()
            {
                Id = exploredArea.Id,
                AmountExplored = exploredArea.AmountExplored,
                Area = exploredArea.Area.AsDTO()
            };
        }

        public static DTO.Area AsDTO(this Model.Area area)
        {
            return new DTO.Area()
            {
                Id = area.Id,
                Name = area.Name,
                Size = area.Size
            };
        }

        public static Model.Explorer AsEntity(this DTO.Explorer explorer)
        {
            return new Sagu.Model.Explorer()
            {
                Id = explorer.Id,
                Name = explorer.Name
            };
        }
    }
}
