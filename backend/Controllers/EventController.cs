using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
   //[Authorize] //- Authorization from login
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
        //[AllowAnonymous] funksionon
        [HttpPost]
        public IActionResult CreateEvent(CreateEventDto eventDto)
        {
            var createdEvent = _eventService.CreateEvent(eventDto);
            var response = _mapper.Map<EventResponse>(createdEvent);
            return CreatedAtAction(nameof(GetEventById), new { eventId = response.EventID }, response);
        }
        //[AllowAnonymous] funksionon
        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _eventService.GetAllEvents();
            var response = _mapper.Map<IEnumerable<EventResponse>>(events);
            return Ok(response);
        }
        //[AllowAnonymous] funksionon
        [HttpGet("{eventId}")]
        public IActionResult GetEventById(int eventId)
        {
            var eventItem = _eventService.GetEventById(eventId);
            if (eventItem == null)
                return NotFound();

            var response = _mapper.Map<EventResponse>(eventItem);
            return Ok(response);
        }
       // [AllowAnonymous] funksionon
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
        //[AllowAnonymous] funksionon
        [HttpDelete("{eventId}")]
        public IActionResult DeleteEvent(int eventId)
        {
            var isDeleted = _eventService.DeleteEvent(eventId);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
       public async Task<IActionResult> SearchEvents(string query)
       {
            try
            {
                var searchResult = await _eventService.SearchEvents(query);
                return Ok(_mapper.Map<IEnumerable<EventResponse>>(searchResult));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
