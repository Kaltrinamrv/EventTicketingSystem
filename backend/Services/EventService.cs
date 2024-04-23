using backend.Models;
using System.Collections.Generic;
using System.Linq;
using backend.Entities;
namespace backend.Services
{
    public class EventService
    {
        private readonly List<Event> _events;

        public EventService()
        {
            _events = new List<Event>(); 
        }

        // Create a new event
        public EventResponse CreateEvent(CreateEventDto eventDto)
        {
            var newEvent = new Event
            {
                Name = eventDto.Name,
                Description = eventDto.Description,
                DateAndTime = eventDto.DateAndTime,
                Location = eventDto.Location,
                OrganizerID = eventDto.OrganizerID,
                TicketsAvailable = eventDto.TicketsAvailable,
                TicketPrice = eventDto.TicketPrice
            };

            _events.Add(newEvent);

            return MapEventToEventResponse(newEvent);
        }

        public IEnumerable<EventResponse> GetAllEvents()
        {
            return _events.Select(e => MapEventToEventResponse(e));
        }

        public EventResponse GetEventById(int eventId)
        {
            var eventItem = _events.FirstOrDefault(e => e.EventID == eventId);
            if (eventItem == null)
                return null; 

            return MapEventToEventResponse(eventItem);
        }

        // Update an event
        public EventResponse UpdateEvent(int eventId, UpdateEventDto eventDto)
        {
            var eventToUpdate = _events.FirstOrDefault(e => e.EventID == eventId);
            if (eventToUpdate == null)
                return null;

            eventToUpdate.Name = eventDto.Name;
            eventToUpdate.Description = eventDto.Description;
            eventToUpdate.DateAndTime = eventDto.DateAndTime;
            eventToUpdate.Location = eventDto.Location;
            eventToUpdate.TicketsAvailable = eventDto.TicketsAvailable;
            eventToUpdate.TicketPrice = eventDto.TicketPrice;

            return MapEventToEventResponse(eventToUpdate);
        }

        // Delete an event
        public bool DeleteEvent(int eventId)
        {
            var eventToDelete = _events.FirstOrDefault(e => e.EventID == eventId);
            if (eventToDelete == null)
                return false; 

            _events.Remove(eventToDelete); 
            return true;
        }

        private EventResponse MapEventToEventResponse(Event eventItem)
        {
            return new EventResponse
            {
                EventID = eventItem.EventID,
                Name = eventItem.Name,
                Description = eventItem.Description,
                DateAndTime = eventItem.DateAndTime,
                Location = eventItem.Location,
                OrganizerID = eventItem.OrganizerID,
                TicketsAvailable = eventItem.TicketsAvailable,
                TicketPrice = eventItem.TicketPrice
            };
        }
    }
}
