using System.Threading.Tasks;
using backend.Entities;
using backend.Models;

namespace backend.IServices
{
    public interface IAuthService
    {
        Task<User> Authenticate(string email, string password);
        string GenerateJwtToken(User user);
    }
}
