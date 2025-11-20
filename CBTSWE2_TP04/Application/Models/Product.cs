using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product { 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0, Double.MaxValue)]
        public double Price { get; set; }
        [Required]
        [Range(0, 999)]
        public int QtyStock { get; set; }
    }
}
