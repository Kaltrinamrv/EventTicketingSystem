using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using backend.Entities;
using backend.IServices;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//USERI KOMPLET OKAY INCLUDIN HASH EDHE TOKEN TEK LOGIN 
namespace backend.Controllers
{
    [Authorize]
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
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserResponse>> Register(CreateUserDto userDto)
        {
            var user = await _userService.CreateUser(userDto);
            return Ok(user);
        }

        [AllowAnonymous]
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
                
                return StatusCode(500, "An error occurred while retrieving users.");
            }
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            var userResponseDto = _mapper.Map<UserResponse>(user);
            if (user == null)
                return NotFound("User not found!");
            return Ok(user); 
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDto userDto)
        {
            var updatedUser = await _userService.UpdateUser(id, userDto);
            if (updatedUser == null)
                return NotFound("Failed!");

            return Ok(updatedUser);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result)
                return NotFound("User not found");

            return Ok("Deleted successfully!");
        }
    }
}
