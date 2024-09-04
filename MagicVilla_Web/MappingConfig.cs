using AutoMapper;
using MagicVilla_Web.Models.Dto;


namespace MagicVilla_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 

            CreateMap<VillaDTO, VillaDTOCreate> ().ReverseMap();

            CreateMap<VillaDTO, VillaDTOUpdate>().ReverseMap();

            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();

            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
