

namespace backend.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }     
        public int EventID { get; set; }
        public Event Event { get; set; }
        public bool IsAvailable { get; set; }
        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }

    }
}
