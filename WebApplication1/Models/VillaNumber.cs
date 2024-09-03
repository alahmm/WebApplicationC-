using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magi.Models
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] //we do not want database to generate it
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
