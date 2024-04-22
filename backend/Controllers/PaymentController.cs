using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{


    

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public IActionResult ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                _paymentService.ProcessPayment(paymentRequest.TicketId, paymentRequest.Amount);
                return Ok("Payment processed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("payments")]
        public IActionResult GetPayments()
        {
            try
            {
                List<Payment> payments = _paymentService.GetPayments();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }

    public class PaymentRequest
    {
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
    }


}


