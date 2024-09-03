using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace Magi.Models
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] //we do not want database to generate it
        public int VillaNo { get; set; }
        [ForeignKey("Villa")]   //foreign key to villa table
        public int VillaID { get; set; }   // after that add new migration then run update-database

        public Villa Villa { get; set; }  //navigation to the foreign key

        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
