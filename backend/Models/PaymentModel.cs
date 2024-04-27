namespace backend.Models
{

    public class PaymentProcessDto
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
    public class PaymentResponseDto
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Message { get; set; }
    }
}
