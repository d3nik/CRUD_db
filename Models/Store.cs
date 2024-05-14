using System.ComponentModel.DataAnnotations;

namespace CRUD_db.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        [Required]
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
    }
}
