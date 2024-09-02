using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.Dto;

namespace Magi
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 
            CreateMap<Villa, VillaDTO> ();
            CreateMap<VillaDTO, Villa> ();

            CreateMap<Villa, VillaDTOCreate> ().ReverseMap();

            CreateMap<Villa, VillaDTOUpdate>().ReverseMap();
        }
    }
}
