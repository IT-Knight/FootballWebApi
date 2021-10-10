using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FootballWebApi.Helpers
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return BitConverter.ToString(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(password))).Replace("-", "");
        }
    }
}
