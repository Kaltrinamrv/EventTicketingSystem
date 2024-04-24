using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Services;
using System.Net.Sockets;

namespace backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class TicketsController : ControllerBase
    {

        private readonly ProjectDbContext _dbContext;

        public TicketsController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Ticket
        [HttpGet]
        public ActionResult<IEnumerable<TicketResponse>> GetTickets()
        {
            // return _dbContext.Tickets.ToList();
            var tickets = _dbContext.Tickets.ToList();
            var ticketResponses = tickets.Select(ticket => MapToTicketResponse(ticket)).ToList();
            return Ok(ticketResponses);
        }

        // GET: api/Ticket/5
        [HttpGet("{id}")]
        public IActionResult GetTicket(int id)
        {
            var ticket = _dbContext.Tickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }

            var ticketResponse = MapToTicketResponse(ticket);
            return Ok(ticketResponse);
        }

        // POST: api/Ticket
        [HttpPost]
        public ActionResult<TicketResponse> PostTicket(CreateTicketDto createTicketDto)
        {
            var ticket = MapToTicket(createTicketDto);
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();


            var ticketResponse = MapToTicketResponse(ticket);
            return CreatedAtAction("GetTicket", new { id = ticket.TicketID }, ticket);
        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public IActionResult PutTicket(int id, UpdateTicketDto updateTicketDto)
        {
            var ticket = _dbContext.Tickets.FirstOrDefault(t => t.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            // Update Ticket
            ticket.TicketType = updateTicketDto.TicketType;
            ticket.Price = updateTicketDto.Price;
            ticket.QuantityAvailable = updateTicketDto.QuantityAvailable;
            ticket.SaleStartDate = updateTicketDto.SaleStartDate;
            ticket.SaleEndDate = updateTicketDto.SaleEndDate;

            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Ticket/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var ticket = _dbContext.Tickets.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // Helper method, maps CreateTicket to Ticket
        private Ticket MapToTicket(CreateTicketDto createTicketDto)
        {
            return new Ticket
            {
                EventID = createTicketDto.EventID,
                UserID = createTicketDto.UserID,
                TicketType = createTicketDto.TicketType,
                Price = createTicketDto.Price,
                QuantityAvailable = createTicketDto.QuantityAvailable,
                SaleStartDate = createTicketDto.SaleStartDate,
                SaleEndDate = createTicketDto.SaleEndDate,
            };
        }

        // Helper method, maps Ticket to TicketResponse
        private TicketResponse MapToTicketResponse(Ticket ticket)
        {
            return new TicketResponse
            {
                TicketID = ticket.TicketID,
                EventID = ticket.EventID,
                UserID = ticket.UserID,
                TicketType = ticket.TicketType,
                Price = ticket.Price,
                QuantityAvailable = ticket.QuantityAvailable,
                SaleStartDate = ticket.SaleStartDate,
                SaleEndDate = ticket.SaleEndDate,
            };
        }

    }
}

