using System;
using System.Threading.Tasks;
using backend.Entities;
using backend.DataAccess;
using AutoMapper;
using backend.IServices;
using backend.Models;

namespace backend.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly ProjectDbContext _context;
        

        public PaymentService(IMapper mapper, ProjectDbContext context)
        {
            _mapper = mapper;
            _context = context;
            

        }

        public async Task<Payment> ProcessPayment(PaymentProcessDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
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
