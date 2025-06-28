using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Data.Entities
{
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(90)]
        public string CategoryName { get; set; }
        [MaxLength(5000)]
        public string? Description { get; set; }

        public byte[]? Picture { get; set; }
    }
}
