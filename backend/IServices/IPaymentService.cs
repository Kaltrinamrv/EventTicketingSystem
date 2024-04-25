using backend.Entities;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IPaymentService
    {
        Task<Payment> ProcessPayment(Payment payment);
        Task<Payment> GetPaymentResponse(int paymentId);
    }
}
