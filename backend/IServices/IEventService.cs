using backend.Models;
using System.Collections.Generic;

namespace backend.IServices
{
    public interface IEventService
    {
        EventResponse CreateEvent(CreateEventDto eventDto);
        IEnumerable<EventResponse> GetAllEvents();
        EventResponse GetEventById(int eventId);
        EventResponse UpdateEvent(int eventId, UpdateEventDto eventDto);
        bool DeleteEvent(int eventId);
        Task<IEnumerable<EventResponse>> SearchEvents(string query);
    }
}
