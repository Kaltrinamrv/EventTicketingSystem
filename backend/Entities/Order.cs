using System.Text.Json.Serialization;

namespace backend.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int EventID { get; set; }
        [JsonIgnore]
        public Event Event { get; set; }
        public int TicketQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
       
    }
}
