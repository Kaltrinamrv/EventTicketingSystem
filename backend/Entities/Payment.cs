using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Payment
    {
       
      
        public int PaymentID { get; set; }
        public int TicketID { get; set; }
        public int OrderID { get; set; }    
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int UserID { get; set; }


        public User User { get; set; }


        public Payment()
        {
            PaymentDate = DateTime.Now;
        }
    }

}
