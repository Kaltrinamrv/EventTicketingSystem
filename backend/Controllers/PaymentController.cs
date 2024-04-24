using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using backend.Models;

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
        public IActionResult ProcessPayment([FromBody] CreatePaymentDto paymentRequest)
        {
            try
            {
                _paymentService.ProcessPayment(paymentRequest.TicketID, paymentRequest.Amount, paymentRequest.UserID);
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
                List<PaymentResponse> paymentResponses = payments.Select(p => new PaymentResponse
                {
                    PaymentID = p.PaymentID,
                    TicketID = p.TicketID,
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate,
                    UserID = p.UserID
                }).ToList();
                return Ok(paymentResponses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}


public class PaymentRequest
    {
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
    }





