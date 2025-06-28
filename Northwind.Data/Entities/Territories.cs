using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Entities
{
    public class Territories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TerritoryID { get; set; }
        public string? TerritoryDescription { get; set; }
        public int? RegionID { get; set; }

    }
}
