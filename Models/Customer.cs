using System.ComponentModel.DataAnnotations;

namespace CRUD_db.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
