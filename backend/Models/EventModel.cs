namespace backend.Models
{
    // DTO for creating an event
    public class CreateEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public int OrganizerID { get; set; }
        public int TicketsAvailable { get; set; }
        public decimal TicketPrice { get; set; }
    }

    // DTO for updating an event
    public class UpdateEventDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public int TicketsAvailable { get; set; }
        public decimal TicketPrice { get; set; }
    }

    // Response object for returning event data
    public class EventResponse
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public int OrganizerID { get; set; }
        public int TicketsAvailable { get; set; }
        public decimal TicketPrice { get; set; }
    }

    // Event entity model
   
}
