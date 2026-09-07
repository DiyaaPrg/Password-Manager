using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordsManagement.Global
{
    public class clsUtil
    {
        public static string GeneratePassword(int length, bool includeLowercase = true,  bool includeUppercase = true, bool includeNumbers = true,
            bool includeSymbols = true)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "0123456789";
            string symbols = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            string allowedChars = "";

            if (includeLowercase)
                allowedChars += lowercase;

            if (includeUppercase)
                allowedChars += uppercase;

            if (includeNumbers)
                allowedChars += numbers;

            if (includeSymbols)
                allowedChars += symbols;

            if (string.IsNullOrEmpty(allowedChars))
                return "";

            char[] password = new char[length];

            for (int i = 0; i < length; i++)
            {
                int index = RandomNumberGenerator.GetInt32(allowedChars.Length);
                password[i] = allowedChars[index];
            }

            return new string(password);
        }


    }
}
