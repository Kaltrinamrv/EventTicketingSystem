// Import necessary namespaces
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Entities;
using backend.IServices;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<UserResponse>> Authenticate(UserLoginRequest loginRequest)
        {
            var user = await _userService.AuthenticateUser(loginRequest);
            if (user == null)
                return Unauthorized(new { message = "Incorrect email or password." });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(CreateUserDto userDto)
        {
            var user = await _userService.CreateUser(userDto);
            return Ok(user);
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
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving users.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid user ID.");

            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDto userDto)
        {
            if (id <= 0)
                return BadRequest("Invalid user ID.");

            var updatedUser = await _userService.UpdateUser(id, userDto);
            if (updatedUser == null)
                return NotFound("User not found.");

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid user ID.");

            var result = await _userService.DeleteUser(id);
            if (!result)
                return NotFound("User not found.");

            return Ok("User deleted successfully!");
        }
    }
}
