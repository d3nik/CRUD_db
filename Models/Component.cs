using System.ComponentModel.DataAnnotations;

namespace CRUD_db.Models
{
    public class Component
    {
        public int ComponentId { get; set; }
        [Required]
        public string Type { get; set; }
        public string BrandId { get; set; }
        public string? Model { get; set; }
        public string? Specs { get; set; }
        public string Price { get; set; }
        public string? QuantityInStock { get; set; }
    }
}
