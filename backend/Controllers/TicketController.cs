using AutoMapper;
using backend.IServices;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        [HttpGet] //funksionon
        public ActionResult<IEnumerable<TicketResponse>> GetTickets()
        {
            var tickets = _ticketService.GetAllTickets();
            var ticketResponses = _mapper.Map<IEnumerable<TicketResponse>>(tickets);
            return Ok(ticketResponses);
        }

        [HttpGet("{id}")] //funksionon
        public ActionResult<TicketResponse> GetTicketById(int id)
        {
            var ticket = _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound("Ticket not found");
            }
            var ticketResponse = _mapper.Map<TicketResponse>(ticket);
            return Ok(ticketResponse);
        }

        [HttpPost] //funksionon
        public ActionResult<TicketResponse> CreateTicket(CreateTicketDto createTicketDto)
        {
            var ticket = _ticketService.CreateTicket(createTicketDto);
            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.TicketID }, ticket);
        }
        
        [HttpPut("{id}")] //nuk bon me bo update ticket id se osht key
        public IActionResult UpdateTicket(int id, UpdateTicketDto updateTicketDto)
        {
            var ticketResponse = _ticketService.UpdateTicket(id, updateTicketDto);
            if (ticketResponse == null)
            {
                return NotFound("Failed to Update!");
            }
            return Ok("Updated!");
        }

        [HttpDelete("{id}")] //funksionon
        public IActionResult DeleteTicket(int id)
        {
            var success = _ticketService.DeleteTicket(id);
            if (!success)
            {
                return NotFound("Failed!");
            }
            return Ok("Deleted successfully");
        }
    }
}
