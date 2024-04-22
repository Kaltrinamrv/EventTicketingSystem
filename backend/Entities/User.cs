﻿using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class User
    {
        
        public int UserID { get; set; }

       
        public string Username { get; set; }

       
        public string Password { get; set; }

        public string Email { get; set; }

      
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

       
        public string Address { get; set; }

    
        public string PhoneNumber { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public ICollection<Payment>? Accounts { get; set; }
    }
}
