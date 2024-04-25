using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using backend.DataAccess; 
using backend.Entities;
using backend.Helpers;
using backend.IServices;
using backend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services
{
    public class UserService : IUserService
    {
        private readonly ProjectDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper, ProjectDbContext context, IPasswordHashService passwordHashService, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _passwordHashService = passwordHashService;
            _configuration = configuration;
        }

        public UserResponse Authenticate(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null && _passwordHashService.VerifyPassword(password, user.Password))
            {
                var token = GenerateToken(user);
                var userResponse = _mapper.Map<UserResponse>(user);
                userResponse.Token = token;
                return userResponse;
            }

            return null;
        }

        public UserResponse CreateUser(CreateUserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto));

            if (_context.Users.Any(u => u.Email == userDto.Email))
                throw new ApplicationException("Email is already in use.");

            string hashedPassword = _passwordHashService.HashPassword(userDto.Password);

            var newUser = _mapper.Map<User>(userDto);
            newUser.Password = hashedPassword;

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var userResponse = _mapper.Map<UserResponse>(newUser);
            userResponse.Token = GenerateToken(newUser);
            return userResponse;
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public UserResponse GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserID == userId);
            return _mapper.Map<UserResponse>(user);
        }

        public UserResponse UpdateUser(int userId, UpdateUserDto userDto)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.UserID == userId);
            if (userToUpdate == null)
                throw new ApplicationException("User not found.");

            userToUpdate.Username = userDto.Username;
            userToUpdate.Email = userDto.Email;
            userToUpdate.FirstName = userDto.FirstName;
            userToUpdate.LastName = userDto.LastName;
            userToUpdate.DateOfBirth = userDto.DateOfBirth;
            userToUpdate.Address = userDto.Address;
            userToUpdate.PhoneNumber = userDto.PhoneNumber;

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                string hashedPassword = _passwordHashService.HashPassword(userDto.Password);
                userToUpdate.Password = hashedPassword;
            }

            _context.SaveChanges();

            var updatedUserResponse = _mapper.Map<UserResponse>(userToUpdate);
            updatedUserResponse.Token = GenerateToken(userToUpdate);
            return updatedUserResponse;
        }

        public bool DeleteUser(int userId)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.UserID == userId);
            if (userToDelete == null)
                return false;

            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    // Add other claims as needed
                }),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["JwtSettings:ExpirationHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
