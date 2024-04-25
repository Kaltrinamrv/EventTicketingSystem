using AutoMapper;
using backend.IServices;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> GetUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                var userResponses = _mapper.Map<IEnumerable<UserResponse>>(users);
                return Ok(userResponses);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while retrieving users.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponse> GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while retrieving the user.");
            }
        }

        [HttpPost]
        public ActionResult<UserResponse> CreateUser(CreateUserDto createUserDto)
        {
            try
            {
                var user = _userService.CreateUser(createUserDto);
                return CreatedAtAction(nameof(GetUserById), new { id = user.UserID }, user);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while creating the user.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            try
            {
                var updatedUser = _userService.UpdateUser(id, updateUserDto);
                if (updatedUser == null)
                    return NotFound();
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while updating the user.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var result = _userService.DeleteUser(id);
                if (!result)
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while deleting the user.");
            }
        }

        [HttpPost("login")]
        public ActionResult<UserResponse> Login(UserLoginRequest loginRequest)
        {
            try
            {
                // Validate the login request
                if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                {
                    return BadRequest("Invalid login request.");
                }

                // Authenticate the user
                var user = _userService.Authenticate(loginRequest.Email, loginRequest.Password);

                if (user == null)
                {
                    return Unauthorized("Invalid email or password.");
                }

                // Return user information
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while processing the login request.");
            }
        }
    }
}
