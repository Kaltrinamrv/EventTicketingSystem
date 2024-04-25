using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    // DTO for creating a user
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

    // DTO for updating a user
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

    // Response object for returning user data
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

    // Request object for user login
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
