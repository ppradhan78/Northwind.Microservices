using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Entities
{
    public class Region
    {
        [Key]
        public int RegionID { get; set; }
        public string? RegionDescription { get; set; }

    }
}
