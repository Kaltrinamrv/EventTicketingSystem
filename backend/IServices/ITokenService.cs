using backend.Entities;
using backend.Models;
using System.Security.Claims;

namespace backend.IServices
{
    public interface ITokenService
    {
        string GenerateToken(int id);
        ClaimsPrincipal VerifyToken(string token);
    }
}
