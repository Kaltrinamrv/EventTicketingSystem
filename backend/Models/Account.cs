namespace backend.Models
{
    public class Account
    {
        [Key]
        public int UserID { get; set; }

        public string PaymentInformation { get; set; }
    }
}