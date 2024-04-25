using System;

namespace backend.Models
{
    // DTO for creating an order
    public class CreateOrderDto
    {
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int TicketQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }

    // DTO for updating an order
    public class UpdateOrderDto
    {
        public int TicketQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }

    // Response object for returning order data
    public class OrderResponse
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int EventID { get; set; }
        public int TicketQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
