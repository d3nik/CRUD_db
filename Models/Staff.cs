using System.ComponentModel.DataAnnotations;

namespace CRUD_db.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string HireDate { get; set; }
        public string StoreId { get; set; }
    }
}
