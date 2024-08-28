using WebApplication1.Models.Dto;

namespace WebApplication1.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villas = new List<VillaDTO>
            {
                new VillaDTO { Id = 1,Name = "Pool",Occupancy=4,Sqft=100 },
                new VillaDTO { Id = 2, Name = "Beach",Occupancy=3,Sqft=300 }
            };
    }
}
