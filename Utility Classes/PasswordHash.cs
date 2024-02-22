using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeycardMenagmentSystem.Utility_Classes
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var hasher = new SHA256Managed())
            {
                var unhashed = System.Text.Encoding.Unicode.GetBytes(password);
                var hashedBytes = hasher.ComputeHash(unhashed);
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
