using System;
using System.Security.Cryptography;

namespace Guestbook.Web.ControllersHelpers
{
    public class PasswordHelpers
    {
        public static string Hash(string password)
        {
            return $"$HASH|V1${1000}${password}";
        }

        public static bool Verify(string password, string hashedPassword)
        {
            // Extract iteration and Base64 string
            var splittedHashString = hashedPassword.Replace("$HASH|V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            if (base64Hash == password) return true;
            return false;
        }
    }
}

