using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Entities
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int EmployeeID { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }
        public DateTime? OrderDate { get; set; }

        [MaxLength(90)]
        public string? Address { get; set; }
        [MaxLength(90)]
        public string? ShipRegion { get; set; }
        [MaxLength(90)]
        public string? ShipCity { get; set; }
        [MaxLength(90)]
        public string? ShipAddress { get; set; }
        [MaxLength(90)]
        public string? ShipName { get; set; }
        [MaxLength(90)]
        public int? Freight { get; set; }

        [MaxLength(90)]
        public string? ShipPostalCode { get; set; }

        [MaxLength(90)]
        public int? ShipVia { get; set; }

        [MaxLength(90)]
        public string? ShipCountry { get; set; }

    }
}
