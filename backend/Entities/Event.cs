using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Event
    {
        
        public int EventID { get; set; }

        public string Name { get; set; }

 
        public string Description { get; set; }

     
        public DateTime DateAndTime { get; set; }

      
        public string Location { get; set; }

        public int OrganizerID { get; set; }

        public int TicketsAvailable { get; set; }

        
        public decimal TicketPrice { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
