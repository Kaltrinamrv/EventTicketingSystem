using AutoMapper;
using backend.DataAccess;
using backend.Entities;
using backend.IServices;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services   //funksionon komplet perveq put, a me leju me update ticketid??
{
    public class TicketService : ITicketService
    {
        private readonly ProjectDbContext _context;
        private readonly IMapper _mapper;

        public TicketService(IMapper mapper, ProjectDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public TicketResponse CreateTicket(CreateTicketDto ticketDto)
        {
            var newTicket = _mapper.Map<Ticket>(ticketDto);
            _context.Tickets.Add(newTicket);
            _context.SaveChanges();  //eventi me numer ekzistues funksionon tek ticketa, sepse nese nuk ekziston nje eveent smundesh me ble ticket
            return _mapper.Map<TicketResponse>(newTicket);
        }

        public IEnumerable<TicketResponse> GetAllTickets()
        {
            var tickets = _context.Tickets.ToList();

            return _mapper.Map<IEnumerable<TicketResponse>>(tickets);
        }

        public TicketResponse GetTicketById(int ticketId)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.TicketID == ticketId);
            return _mapper.Map<TicketResponse>(ticket);
        }

        public TicketResponse UpdateTicket(int ticketId, UpdateTicketDto ticketDto)
        {
            var ticketToUpdate = _context.Tickets.FirstOrDefault(t => t.TicketID == ticketId);
            if (ticketToUpdate == null)
                throw new ApplicationException("Ticket not found.");

            _mapper.Map(ticketDto, ticketToUpdate);
            _context.SaveChanges();

            return _mapper.Map<TicketResponse>(ticketToUpdate);
        }

        public bool DeleteTicket(int ticketId)
        {
            var ticketToDelete = _context.Tickets.FirstOrDefault(t => t.TicketID == ticketId);
            if (ticketToDelete == null)
            {
                
                return false;
            }

            try
            {
                _context.Tickets.Remove(ticketToDelete);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error deleting ticket: {ex.Message}");
                
                return false;
            }
        }

    }
}
