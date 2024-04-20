namespace backend.Models
{
    // DTO for creating an account
    public class CreateAccountDto
    {
        public int UserID { get; set; }
        public string PaymentInformation { get; set; }
    }

    // DTO for updating an account
    public class UpdateAccountDto
    {
        public string PaymentInformation { get; set; }
    }

    // Response object for returning account data
    public class AccountResponse
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public string PaymentInformation { get; set; }
    }

    // Account entity model
    public class Account
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public string PaymentInformation { get; set; }
    }
}
