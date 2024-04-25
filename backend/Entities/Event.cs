using System.ComponentModel.DataAnnotations;
using System.Data;

namespace backend.Entities
{
    public class Event
    {
      //  public int OrderID { get; set; }
        
        //public int UserID { get; set; }

        
        public int EventID { get; set; }
        public int TicketQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        
    }
}
