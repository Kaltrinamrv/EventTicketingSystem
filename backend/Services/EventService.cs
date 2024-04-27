using backend.Entities;
using backend.IServices;
using backend.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using backend.DataAccess;
using Microsoft.EntityFrameworkCore;


namespace backend.Services
{
    public class EventService : IEventService
    {
        private readonly ProjectDbContext _context;
        private readonly IMapper _mapper;

        public EventService(IMapper mapper, ProjectDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public EventResponse CreateEvent(CreateEventDto eventDto)
        {
            var newEvent = _mapper.Map<Event>(eventDto);
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return _mapper.Map<EventResponse>(newEvent);
        }

        public IEnumerable<EventResponse> GetAllEvents()
        {
            var events = _context.Events.ToList();
            return _mapper.Map<IEnumerable<EventResponse>>(events);

        }

        public EventResponse GetEventById(int eventId)
        {
            var eventItem = _context.Events.FirstOrDefault(e => e.EventID == eventId);
            return _mapper.Map<EventResponse>(eventItem);
        }

        public EventResponse UpdateEvent(int eventId, UpdateEventDto eventDto)
        {
            var eventToUpdate = _context.Events.FirstOrDefault(e => e.EventID == eventId);
            if (eventToUpdate == null)
                throw new ApplicationException("Event not found.");

            _mapper.Map(eventDto, eventToUpdate);
            _context.SaveChanges();

            return _mapper.Map<EventResponse>(eventToUpdate);
        }

        public bool DeleteEvent(int eventId)
        {
            var eventToDelete = _context.Events.FirstOrDefault(e => e.EventID == eventId);
            if (eventToDelete == null)
                return false;

            _context.Events.Remove(eventToDelete);
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<EventResponse>> SearchEvents(string query)
        {
            var lowercaseQuery = query.ToLower();

            var searchResult = await _context.Events
                                            .Where(e => e.Name.ToLower().Contains(lowercaseQuery) ||
                                                        e.Location.ToLower().Contains(lowercaseQuery))
                                            .ToListAsync();

            return _mapper.Map<IEnumerable<EventResponse>>(searchResult);
        }

    }
}
