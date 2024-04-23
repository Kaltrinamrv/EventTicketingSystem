using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ProjectDbContext _dbContext;

        public EventsController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Events
        [HttpGet]
        public ActionResult<IEnumerable<EventResponse>> GetEvents()
        {
            var events = _dbContext.Events.ToList();
            var eventResponses = events.Select(ev => MapToEventResponse(ev)).ToList();
            return Ok(eventResponses);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var ev = _dbContext.Events.Find(id);

            if (ev == null)
            {
                return NotFound();
            }

            var eventResponse = MapToEventResponse(ev);
            return Ok(eventResponse);
        }

        // POST: api/Events
        [HttpPost]
        public ActionResult<EventResponse> PostEvent(CreateEventDto createEventDto)
        {
            var ev = MapToEvent(createEventDto);
            _dbContext.Events.Add(ev);
            _dbContext.SaveChanges();

            var eventResponse = MapToEventResponse(ev);
            return CreatedAtAction(nameof(GetEvent), new { id = eventResponse.EventID }, eventResponse);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public IActionResult PutEvent(int id, UpdateEventDto updateEventDto)
        {
            var ev = _dbContext.Events.FirstOrDefault(e => e.EventID == id);

            if (ev == null)
            {
                return NotFound();
            }

            // Update event properties
            ev.Name = updateEventDto.Name;
            ev.Description = updateEventDto.Description;
            ev.DateAndTime = updateEventDto.DateAndTime;
            ev.Location = updateEventDto.Location;
            ev.TicketsAvailable = updateEventDto.TicketsAvailable;
            ev.TicketPrice = updateEventDto.TicketPrice;

            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var ev = _dbContext.Events.Find(id);
            if (ev == null)
            {
                return NotFound();
            }

            _dbContext.Events.Remove(ev);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // Helper method to map CreateEventDto to Event entity
        private Event MapToEvent(CreateEventDto createEventDto)
        {
            return new Event
            {
                Name = createEventDto.Name,
                Description = createEventDto.Description,
                DateAndTime = createEventDto.DateAndTime,
                Location = createEventDto.Location,
                OrganizerID = createEventDto.OrganizerID,
                TicketsAvailable = createEventDto.TicketsAvailable,
                TicketPrice = createEventDto.TicketPrice
            };
        }

        // Helper method to map Event entity to EventResponse DTO
        private EventResponse MapToEventResponse(Event ev)
        {
            return new EventResponse
            {
                EventID = ev.EventID,
                Name = ev.Name,
                Description = ev.Description,
                DateAndTime = ev.DateAndTime,
                Location = ev.Location,
                OrganizerID = ev.OrganizerID,
                TicketsAvailable = ev.TicketsAvailable,
                TicketPrice = ev.TicketPrice
            };
        }
    }
}
