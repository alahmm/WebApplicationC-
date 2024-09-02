using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace Magi
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 
            CreateMap<T, VillaDTO> ();
            CreateMap<VillaDTO, T> ();

            CreateMap<T, VillaDTOCreate> ().ReverseMap();

            CreateMap<T, VillaDTOUpdate>().ReverseMap();
        }
    }
}
