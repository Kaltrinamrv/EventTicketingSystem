using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace backend.Models
{
	// DTO for creating a user
	public class CreateUserDto
	{
        public int UserID { get; set; }
        public string Username { get; set; }
		public string Email { get; set; }
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
        public int UserID { get; set; }
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
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

	// User entity model
	public class User
	{
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
