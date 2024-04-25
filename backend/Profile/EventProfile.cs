using AutoMapper;
using backend.Entities;
using backend.Models;

namespace backend.Profile
{
    public class EventProfile : AutoMapper.Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
            CreateMap<Event, EventResponse>();
        }
    }
}
