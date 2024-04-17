using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        [MaxLength(255)]
        public string Location { get; set; }

        [Required]
        public int OrganizerID { get; set; }

        [Required]
        public int TicketsAvailable { get; set; }

        [Required]
        public decimal TicketPrice { get; set; }
    }
}