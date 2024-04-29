using backend.Entities;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
   
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }     
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }  
        public DateTime DateOfBirth { get; set; }   
        public string Address { get; set; }  
        public string PhoneNumber { get; set; }
    }

   
    public class UpdateUserDto
    {
      
        public string Username { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }  
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    
    public class UserResponse
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
       
        public string Token { get; set; } 
    }

   
    public class UserLoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}
