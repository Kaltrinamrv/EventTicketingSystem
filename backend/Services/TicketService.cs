using backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    public class TicketService
    {
        private readonly List<Ticket> _tickets;

        public TicketService()
        {
            _tickets = new List<Ticket>(); 
        }

        // Create a new ticket
        public TicketResponse CreateTicket(CreateTicketDto ticketDto)
        {
            var newTicket = new Ticket
            {
                EventID = ticketDto.EventID,
                TicketType = ticketDto.TicketType,
                Price = ticketDto.Price,
                QuantityAvailable = ticketDto.QuantityAvailable,
                SaleStartDate = ticketDto.SaleStartDate,
                SaleEndDate = ticketDto.SaleEndDate
            };

            _tickets.Add(newTicket);

            return MapTicketToTicketResponse(newTicket);
        }

        public IEnumerable<TicketResponse> GetAllTickets()
        {
            return _tickets.Select(t => MapTicketToTicketResponse(t));
        }

        public TicketResponse GetTicketById(int ticketId)
        {
            var ticket = _tickets.FirstOrDefault(t => t.TicketID == ticketId);
            if (ticket == null)
                return null;

            return MapTicketToTicketResponse(ticket);
        }

        // Update a ticket
        public TicketResponse UpdateTicket(int ticketId, UpdateTicketDto ticketDto)
        {
            var ticketToUpdate = _tickets.FirstOrDefault(t => t.TicketID == ticketId);
            if (ticketToUpdate == null)
                return null; 

            ticketToUpdate.TicketType = ticketDto.TicketType;
            ticketToUpdate.Price = ticketDto.Price;
            ticketToUpdate.QuantityAvailable = ticketDto.QuantityAvailable;
            ticketToUpdate.SaleStartDate = ticketDto.SaleStartDate;
            ticketToUpdate.SaleEndDate = ticketDto.SaleEndDate;

            return MapTicketToTicketResponse(ticketToUpdate);
        }

        // Delete a ticket
        public bool DeleteTicket(int ticketId)
        {
            var ticketToDelete = _tickets.FirstOrDefault(t => t.TicketID == ticketId);
            if (ticketToDelete == null)
                return false; 

            _tickets.Remove(ticketToDelete); 
            return true;
        }

        private TicketResponse MapTicketToTicketResponse(Ticket ticket)
        {
            return new TicketResponse
            {
                TicketID = ticket.TicketID,
                EventID = ticket.EventID,
                TicketType = ticket.TicketType,
                Price = ticket.Price,
                QuantityAvailable = ticket.QuantityAvailable,
                SaleStartDate = ticket.SaleStartDate,
                SaleEndDate = ticket.SaleEndDate
            };
        }
    }
}
