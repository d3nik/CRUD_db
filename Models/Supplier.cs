using System.ComponentModel.DataAnnotations;

namespace CRUD_db.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Contact { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
