using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Entities
{
    public class Employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(90)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(90)]
        public string FirstName { get; set; }

        
        [MaxLength(90)]
        public string? Title { get; set; }

        
        [MaxLength(90)]
        public string? TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        
        [MaxLength(90)]
        public string? Address { get; set; }

        
        [MaxLength(90)]
        public string? City { get; set; }

        
        [MaxLength(90)]
        public string? Region { get; set; }

        
        [MaxLength(90)]
        public string? PostalCode { get; set; }
        
        [MaxLength(90)]
        public string? Country { get; set; }
        
        [MaxLength(90)]
        public string? HomePhone { get; set; }
        
        [MaxLength(90)]
        public string? Extension { get; set; }
        public byte[]? Photo { get; set; }

        public string? Notes { get; set; }

        [MaxLength(90)]
        public string? ReportsTo { get; set; }

        [MaxLength(90)]
        public string? PhotoPath { get; set; }

    }
}
