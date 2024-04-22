using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Payment
    {
       
      
        public int PaymentId { get; set; }
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        

        public Payment()
        {
            PaymentDate = DateTime.Now;
        }
    }

}