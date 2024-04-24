using backend.Entities;
using System;
using System.Collections.Generic;

namespace backend.Services
{
    public class PaymentService
    {
        private readonly List<Payment> _payments;

        public PaymentService()
        {
            _payments = new List<Payment>();
        }

        public void ProcessPayment(int ticketId, int orderId, decimal amount, int userId)
        {
            var payment = new Payment
            {
                PaymentID = GeneratePaymentId(),
                TicketID = ticketId,
                OrderID = orderId,
                Amount = amount,
                PaymentDate = DateTime.Now,
                UserID = userId
            };

            _payments.Add(payment);
            Console.WriteLine($"Payment processed successfully. Payment ID: {payment.PaymentID}");
        }

        public List<Payment> GetPayments()
        {
            return new List<Payment>(_payments);
        }

        private int GeneratePaymentId()
        {
            return _payments.Count + 1;
        }

       

    }
}
