using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WorkOutAppApi.Client.Helpers
{
    public class Utility
    {
        public static string Encrypt(string password)
        {
            var provider = new SHA256Managed();
            string salt = "this1sApAssW0rdSalt";
            byte[] bytes = provider.ComputeHash(Encoding.UTF32.GetBytes(salt + password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
