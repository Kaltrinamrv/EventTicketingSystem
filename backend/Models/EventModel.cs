using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class CreateEventDto
    {
        [Required]
        public int TicketQuantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Location { get; set; } 
        public string Organizer { get; set; }
    }

    public class UpdateEventDto
    {
        public int TicketQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
    }

    public class EventResponse
    {
        public int EventID { get; set; }
        public int TicketQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
    }
}
