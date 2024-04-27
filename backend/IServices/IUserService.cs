using backend.Entities;
using backend.Models;

namespace backend.IServices
{
    public interface IUserService
    {
        IEnumerable<UserResponse> GetAllUsers();
        Task<UserResponse> GetUserById(int userId);
        Task<UserResponse> CreateUser(CreateUserDto userDto);
        Task<UserResponse> UpdateUser(int userId, UpdateUserDto userDto);
        Task<bool> DeleteUser(int userId);
        Task<UserResponse> AuthenticateUser(UserLoginRequest loginRequest);
    }
}
