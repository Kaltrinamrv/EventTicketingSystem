using System;
using System.Security.Cryptography;
using System.Text;
using backend.IServices;

namespace backend.Services
{
   

    public class PasswordHashService : IPasswordHashService
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;

        public string HashPassword(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, SaltSize, 10000, HashAlgorithmName.SHA512))
            {
                byte[] key = algorithm.GetBytes(KeySize);
                byte[] salt = algorithm.Salt;

                byte[] hash = new byte[SaltSize + KeySize];
                Array.Copy(salt, 0, hash, 0, SaltSize);
                Array.Copy(key, 0, hash, SaltSize, KeySize);

                return Convert.ToBase64String(hash);
            }
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            using (var algorithm = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA512))
            {
                byte[] keyToCheck = algorithm.GetBytes(KeySize);
                for (int i = 0; i < KeySize; i++)
                {
                    if (keyToCheck[i] != hashBytes[i + SaltSize])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

    }
}
