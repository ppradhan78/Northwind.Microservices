using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Entities
{
    public class Shippers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShipperID { get; set; }

        [MaxLength(90)]
        public string CompanyName { get; set; }


        [MaxLength(90)]
        public string Phone { get; set; }
        

    }
}
