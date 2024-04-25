using System;
using System.Threading.Tasks;
using backend.Entities;
using backend.DataAccess;

namespace backend.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ProjectDbContext _context; // Assuming you have DbContext named ApplicationDbContext

        public PaymentService(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> ProcessPayment(Payment payment)
        {
            // Here you can implement your payment processing logic.
            // For example, you can save the payment to the database and perform any necessary business logic.
            // For demonstration purposes, let's just save the payment to the database and return it.
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> GetPaymentResponse(int paymentId)
        {
            // Here you can implement logic to retrieve payment response by paymentId.
            // For demonstration purposes, let's just retrieve the payment from the database by its ID.
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null)
            {
                // Payment not found, you may throw an exception or return null based on your application logic.
                return null;
            }
            // Simulating some response logic, let's just set the payment date to the current date.
            payment.PaymentDate = DateTime.Now;
            await _context.SaveChangesAsync(); // Save changes to update the payment date
            return payment;
        }
    }
}
