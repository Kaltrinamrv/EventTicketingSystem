using backend.Entities;
using System.Collections.Generic;
using System.Linq;
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

        public void ProcessPayment(int ticketId, decimal amount)
        {
          

            var payment = new Payment
            {
                PaymentID = GeneratePaymentId(),
                TicketId = ticketId,
                Amount = amount,
                PaymentDate = DateTime.Now
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


