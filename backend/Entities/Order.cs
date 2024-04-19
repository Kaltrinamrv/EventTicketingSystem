using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int EventID { get; set; }

        [Required]
        public int TicketID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
    }
}