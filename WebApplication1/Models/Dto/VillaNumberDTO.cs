using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Dto
{
    public class VillaNumberDTO
    {

        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
