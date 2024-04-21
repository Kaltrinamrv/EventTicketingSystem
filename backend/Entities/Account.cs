using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Account
    {
       
        public int UserID { get; set; }
        public User User { get; set; }



        public string PaymentInformation { get; set; }

        public int AccountID { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}