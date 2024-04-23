using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.DataAccess;
using Microsoft.EntityFrameworkCore;
using backend.Services;
using backend.Models;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProjectDbContext _dbContext;

        public UsersController(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var user = _dbContext.Users
                .FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized("Email or password did not match");
            }

            var token = TokenService.GenerateToken(user.UserID);
            return Ok(new Dictionary<string, string>() { { "token", token } });
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> GetUsers()
        {
            var users = _dbContext.Users.ToList();
            var userResponses = users.Select(user => MapToUserResponse(user)).ToList();
            return Ok(userResponses);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id, [FromQuery] string token)
        {
            var principal = TokenService.VerifyToken(token);

            if (principal == null)
            {
                return Unauthorized();
            }

            var idClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (idClaim == null || !int.TryParse(idClaim.Value, out var userId))
            {
                return Unauthorized();
            }

            if (id != userId)
            {
                return Unauthorized("You are not authorized to access this resource");
            }

            var user = _dbContext.Users.FirstOrDefault(u => u.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            var userResponse = MapToUserResponse(user);
            return Ok(userResponse);
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<UserResponse> CreateUser(CreateUserDto createUserDto)
        {
            var user = MapToUser(createUserDto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var userResponse = MapToUserResponse(user);
            return CreatedAtAction(nameof(GetUserById), new { id = userResponse.UserID }, userResponse);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.UserID)
            {
                return BadRequest();
            }

            var user = _dbContext.Users.FirstOrDefault(u => u.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            // Update user properties
            user.Username = updateUserDto.Username;
            user.Email = updateUserDto.Email;
            user.Password = updateUserDto.Password;
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.DateOfBirth = updateUserDto.DateOfBirth;
            user.Address = updateUserDto.Address;
            user.PhoneNumber = updateUserDto.PhoneNumber;

            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // Helper method to map CreateUserDto to User entity
        private User MapToUser(CreateUserDto createUserDto)
        {
            return new User
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                DateOfBirth = createUserDto.DateOfBirth,
                Address = createUserDto.Address,
                PhoneNumber = createUserDto.PhoneNumber
            };
        }

        // Helper method to map User entity to UserResponse DTO
        private UserResponse MapToUserResponse(User user)
        {
            return new UserResponse
            {
                UserID = user.UserID,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
