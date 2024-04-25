using AutoMapper;
using backend.Entities;
using backend.Models;

namespace backend.Profile
{
    public class TicketProfile : AutoMapper.Profile
    {
        public TicketProfile()
        {
            CreateMap<CreateTicketDto, Ticket>().ReverseMap();
            CreateMap<UpdateTicketDto, Ticket>();
            CreateMap<Ticket, TicketResponse>();
        }
    }
}
