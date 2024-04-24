namespace backend.Models
{
    // DTO for creating a ticket
    public class CreateTicketDto
    {
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
    }

    // DTO for updating a ticket
    public class UpdateTicketDto
    {
        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
    }

    // Response object for returning ticket data
    public class TicketResponse
    {
        public int TicketID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public string TicketType { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime SaleEndDate { get; set; }
    }

    // Ticket entity model
  
}
