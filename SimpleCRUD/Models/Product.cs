using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCRUD.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName   { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public decimal Stock { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

    }
} 
