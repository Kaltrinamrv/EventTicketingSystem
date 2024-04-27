using backend.Entities;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    public interface IPaymentService
    {

        Task<Payment> ProcessPayment(PaymentProcessDto payment);
        Task<Payment> GetPaymentResponse(int paymentId);
        
    }
}
