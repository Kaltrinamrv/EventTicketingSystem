using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    public class TicketController
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
            public ActionResult<IEnumerable<Ticket>> GetTickets()
            {
                return _dbContext.Tickets.ToList();
            }

            // GET: api/Ticket/5
            [HttpGet("{id}")]
            public ActionResult<Ticket> GetTicket(int id)
            {
                var ticket = _dbContext.Tickets.Find(id);

                if (ticket == null)
                {
                    return NotFound();
                }

                return ticket;
            }

            // POST: api/Ticket
            [HttpPost]
            public ActionResult<Ticket> PostTicket(Ticket ticket)
            {
                _dbContext.Tickets.Add(ticket);
                _dbContext.SaveChanges();

                return CreatedAtAction("GetTicket", new { id = ticket.TicketID }, ticket);
            }

            // PUT: api/Ticket/5
            [HttpPut("{id}")]
            public IActionResult PutTicket(int id, Ticket ticket)
            {
                if (id != ticket.TicketID)
                {
                    return BadRequest();
                }

                _dbContext.Entry(ticket).State = EntityState.Modified;
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

        }
    }
}

