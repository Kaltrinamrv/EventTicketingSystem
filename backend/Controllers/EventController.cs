using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateEvent(CreateEventDto eventDto)
        {
            var createdEvent = _eventService.CreateEvent(eventDto);
            var response = _mapper.Map<EventResponse>(createdEvent);
            return CreatedAtAction(nameof(GetEventById), new { eventId = response.EventID }, response);
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _eventService.GetAllEvents();
            var response = _mapper.Map<IEnumerable<EventResponse>>(events);
            return Ok(response);
        }

        [HttpGet("{eventId}")]
        public IActionResult GetEventById(int eventId)
        {
            var eventItem = _eventService.GetEventById(eventId);
            if (eventItem == null)
                return NotFound();

            var response = _mapper.Map<EventResponse>(eventItem);
            return Ok(response);
        }

        [HttpPut("{eventId}")]
        public IActionResult UpdateEvent(int eventId, UpdateEventDto eventDto)
        {
            try
            {
                var updatedEvent = _eventService.UpdateEvent(eventId, eventDto);
                var response = _mapper.Map<EventResponse>(updatedEvent);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{eventId}")]
        public IActionResult DeleteEvent(int eventId)
        {
            var isDeleted = _eventService.DeleteEvent(eventId);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
