using AutoMapper;
using Magi.Models;
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

            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
        }
    }
}
