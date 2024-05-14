using System.ComponentModel.DataAnnotations;

namespace CRUD_db.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        public int OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
    }
}
