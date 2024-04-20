using backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>(); 
        }

        // Create a new user
        public UserResponse CreateUser(CreateUserDto userDto)
        {
            var newUser = new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                DateOfBirth = userDto.DateOfBirth,
                Address = userDto.Address,
                PhoneNumber = userDto.PhoneNumber
            };

            _users.Add(newUser);

            return MapUserToUserResponse(newUser);
        }

        public IEnumerable<UserResponse> GetAllUsers()
        {
            return _users.Select(u => MapUserToUserResponse(u));
        }

        public UserResponse GetUserById(int userId)
        {
            var user = _users.FirstOrDefault(u => u.UserID == userId);
            if (user == null)
                return null; 

            return MapUserToUserResponse(user);
        }

        // Update a user
        public UserResponse UpdateUser(int userId, UpdateUserDto userDto)
        {
            var userToUpdate = _users.FirstOrDefault(u => u.UserID == userId);
            if (userToUpdate == null)
                return null;

            userToUpdate.Username = userDto.Username;
            userToUpdate.Email = userDto.Email;
            userToUpdate.FirstName = userDto.FirstName;
            userToUpdate.LastName = userDto.LastName;
            userToUpdate.DateOfBirth = userDto.DateOfBirth;
            userToUpdate.Address = userDto.Address;
            userToUpdate.PhoneNumber = userDto.PhoneNumber;

            return MapUserToUserResponse(userToUpdate);
        }

        // Delete a user
        public bool DeleteUser(int userId)
        {
            var userToDelete = _users.FirstOrDefault(u => u.UserID == userId);
            if (userToDelete == null)
                return false; 

            _users.Remove(userToDelete); 
            return true;
        }

        private UserResponse MapUserToUserResponse(User user)
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
