using System.Threading.Tasks;
using AutoMapper;
using backend.Entities;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using backend.Models;

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

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            var processedPayment = await _paymentService.ProcessPayment(payment);
            var processedPaymentDto = _mapper.Map<PaymentDto>(processedPayment);
            return Ok(processedPaymentDto);
        }

        [HttpGet("response/{paymentId}")]
        public async Task<IActionResult> GetPaymentResponse(int paymentId)
        {
            var paymentResponse = await _paymentService.GetPaymentResponse(paymentId);
            var paymentResponseDto = _mapper.Map<PaymentDto>(paymentResponse);
            if (paymentResponseDto == null)
                return NotFound();
            return Ok(paymentResponseDto);
        }
    }
}
