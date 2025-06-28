using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Entities
{
    public class Customers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(5)]
        public string CustomerID { get; set; }

        [MaxLength(90)]
        public string CompanyName { get; set; }

        [MaxLength(90)]
        public string? ContactName { get; set; }

        [MaxLength(90)]
        public string? ContactTitle { get; set; }

        [MaxLength(70)]
        public string? Address { get; set; }

        [MaxLength(90)]
        public string? City { get; set; }

        [MaxLength(90)]
        public string? Region { get; set; }


        [MaxLength(30)]
        public string? PostalCode { get; set; }

        [MaxLength(90)]
        public string? Country { get; set; }

        [MaxLength(30)]
        public string? Phone { get; set; }

        [MaxLength(30)]
        public string? Fax { get; set; }

    }
}
