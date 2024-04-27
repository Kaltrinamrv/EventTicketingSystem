using System.Threading.Tasks;
using AutoMapper;
using backend.Entities;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.IServices;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpPost("process")] //funksionon
        public async Task<IActionResult> ProcessPayment(PaymentProcessDto paymentDto)
        {
            
            var processedPayment = await _paymentService.ProcessPayment(paymentDto);
            var payment = _mapper.Map<Payment>(paymentDto);
            var processedPaymentDto = _mapper.Map<PaymentProcessDto>(processedPayment);
            return Ok(processedPaymentDto);
        }

        [HttpGet("response/{paymentId}")] //funksionon
        public async Task<IActionResult> GetPaymentResponse(int paymentId)
        {
            var paymentResponse = await _paymentService.GetPaymentResponse(paymentId);
            var paymentResponseDto = _mapper.Map<PaymentResponseDto>(paymentResponse);
            if (paymentResponseDto == null)
                return NotFound();
            return Ok(paymentResponseDto);
        }
    }
}
