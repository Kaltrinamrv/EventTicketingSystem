using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Account
    {
        [Key]
        public int UserID { get; set; }

        public string PaymentInformation { get; set; }

        public int AccountID { get; set; }
    }
}