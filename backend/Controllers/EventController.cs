using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    public class EventController
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

            // GET: api/Event
            [HttpGet]
            public ActionResult<IEnumerable<Event>> GetEvents()
            {
                return _dbContext.Events.ToList();
            }

            // GET: api/Event/5
            [HttpGet("{id}")]
            public ActionResult<Event> GetEvent(int id)
            {
                var ev = _dbContext.Events.Find(id); //named event to ev to ignore the confilct

                if (ev == null)
                {
                    return NotFound();
                }

                return ev;
            }

            // POST: api/Event
            [HttpPost]
            public ActionResult<Event> PostEvent(Event ev)
            {
                _dbContext.Events.Add(ev);
                _dbContext.SaveChanges();

                return CreatedAtAction("GetEvent", new { id = ev.EventID }, ev);
            }

            // PUT: api/Event/5
            [HttpPut("{id}")]
            public IActionResult PutEvent(int id, Event ev)
            {
                if (id != ev.EventID)
                {
                    return BadRequest();
                }

                _dbContext.Entry(ev).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return NoContent();
            }

            // DELETE: api/Event/5
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

        }
    }
}

