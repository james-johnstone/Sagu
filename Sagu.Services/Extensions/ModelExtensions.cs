using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Sagu.Services
{
    public static class ModelExtensions
    {
        static ModelExtensions()
        {
            Mapper.CreateMap<DTO.Explorer, Model.Explorer>().ReverseMap();

            Mapper.CreateMap<DTO.ExploredArea, Model.ExploredArea>()
                .ForMember(a => a.Area, opt => opt.Ignore())
                .ForMember(a => a.AreaId, opt => opt.MapFrom(src => src.Area.Id))
                .ReverseMap();

            Mapper.CreateMap<DTO.Area, Model.Area>().ReverseMap();
            Mapper.CreateMap<DTO.AreaImage, Model.AreaImage>().ReverseMap();
            Mapper.CreateMap<DTO.Animal, Model.Animal>().ReverseMap();
        }

        public static DTO.Explorer AsDTO(this Model.Explorer explorer)
        {
            return Mapper.Map<DTO.Explorer>(explorer);
        }

        public static DTO.ExploredArea AsDTO(this Model.ExploredArea exploredArea)
        {
            return Mapper.Map<DTO.ExploredArea>(exploredArea);
        }

        public static DTO.Area AsDTO(this Model.Area area)
        {
            return Mapper.Map<DTO.Area>(area);
        }

        public static DTO.AreaImage AsDTO(this Model.AreaImage image)
        {
            return Mapper.Map<DTO.AreaImage>(image);
        }

        public static DTO.Animal AsDTO(this Model.Animal animal)
        {
            return Mapper.Map<DTO.Animal>(animal);
        }

        public static Model.Explorer AsEntity(this DTO.Explorer explorer)
        {
            return Mapper.Map<Model.Explorer>(explorer);
        }

        public static Model.Area AsEntity(this DTO.Area area)
        {
            return Mapper.Map<Model.Area>(area);
        }

        public static Model.AreaImage AsEntity(this DTO.AreaImage image)
        {
            return Mapper.Map<Model.AreaImage>(image);
        }

        public static Model.ExploredArea AsEntity(this DTO.ExploredArea exploredArea)
        {
            return Mapper.Map<Model.ExploredArea>(exploredArea);
        }
    }
}
