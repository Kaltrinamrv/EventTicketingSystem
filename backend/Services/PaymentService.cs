using System;
using System.Threading.Tasks;
using backend.Entities;
using backend.DataAccess;

namespace backend.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ProjectDbContext _context; //paymenti nuk punon?

        public PaymentService(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> ProcessPayment(Payment payment)
        {
            
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> GetPaymentResponse(int paymentId)
        {
           
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null)
            {
               
                return null; 
            }
            
            payment.PaymentDate = DateTime.Now;
            await _context.SaveChangesAsync(); 
            return payment;
        }
    }
}
