using backend.Models;

namespace backend.IServices
{
    public interface IUserService
    {
        UserResponse CreateUser(CreateUserDto userDto);
        IEnumerable<UserResponse> GetAllUsers();
        UserResponse GetUserById(int userId);
        UserResponse UpdateUser(int userId, UpdateUserDto userDto);
        bool DeleteUser(int userId);
        UserResponse Authenticate(string email, string password);
    }
}
