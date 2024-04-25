using System;
using System.Security.Cryptography;
using System.Text;

namespace backend.IServices
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }


}
