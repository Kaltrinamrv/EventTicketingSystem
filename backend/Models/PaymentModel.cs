using System;

    namespace backend.Models
    {
        // DTO for creating a payment
        public class CreatePaymentDto
        {
            public int PaymentID { get; set; }
            public int TicketID { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        // DTO for updating a payment
        public class UpdatePaymentDto
        {
            public int PaymentID { get; set; }
            public int TicketID { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        // Response object for returning payment data
        public class PaymentResponse
        {
            public int PaymentID { get; set; }
            public int TicketID { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        // Payment entity model
       
    }


