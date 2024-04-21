using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Order
    {
        
        public int OrderID { get; set; }
        public User User { get; set; }



       
        public int UserID { get; set; }


        
        public int EventID { get; set; }

        public Event Event { get; set; }

        
        public int TicketID { get; set; }

        public Ticket Ticket { get; set;}
        


        public int AccountID { get; set; }
        public Account Account { get; set; }


        public int Quantity { get; set; }

        
        public decimal TotalPrice { get; set; }

      
        public DateTime OrderDate { get; set; }


    }
}