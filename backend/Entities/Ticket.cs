using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        [Required]
        public int EventID { get; set; }

        [Required]
        [MaxLength(50)]
        public string TicketType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int QuantityAvailable { get; set; }

        [Required]
        public DateTime SaleStartDate { get; set; }

        [Required]
        public DateTime SaleEndDate { get; set; }
    }
}