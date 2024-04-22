using System;

    namespace backend.Models
    {
        // DTO for creating a payment
        public class CreatePaymentDto
        {
            public int PaymentId { get; set; }
            public int TicketId { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        // DTO for updating a payment
        public class UpdatePaymentDto
        {
            public int PaymentId { get; set; }
            public int TicketId { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        // Response object for returning payment data
        public class PaymentResponse
        {
            public int PaymentId { get; set; }
            public int TicketId { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }

        // Payment entity model
        public class Payment
        {
            public int PaymentId { get; set; }
            public int TicketId { get; set; }
            public decimal Amount { get; set; }
            public DateTime PaymentDate { get; set; }
        }
    }


