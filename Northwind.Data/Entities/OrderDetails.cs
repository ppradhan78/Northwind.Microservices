using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Entities
{
    [PrimaryKey(nameof(OrderID), nameof(ProductID))]
    public class OrderDetails
    {

        [Key]
        [Column(Order = 1)] // Defines the order of the key columns (optional, but good practice)
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 2)] // Defines the order of the key columns (optional, but good practice)
        public int? ProductID { get; set; }

        public int? UnitPrice { get; set; }
        public int? Quantity { get; set; }

        public int? Discount { get; set; }

    }
}
