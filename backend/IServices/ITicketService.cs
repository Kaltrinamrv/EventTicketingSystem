using backend.Entities;
using backend.Models;
using System.Collections.Generic;

namespace backend.IServices
{
    public interface ITicketService
    {
        TicketResponse CreateTicket(CreateTicketDto ticketDto);
        bool DeleteTicket(int id);
        IEnumerable<TicketResponse> GetAllTickets();
        TicketResponse GetTicketById(int ticketId);
        TicketResponse UpdateTicket(int ticketId, UpdateTicketDto ticketDto);
        
    }
}
